#include <msp430.h> 
/**
 * main.c
 */

unsigned char circ_buffer[5];
volatile unsigned int start = 0;
volatile unsigned int end = 0;
volatile unsigned int data_count = 0;
volatile unsigned int databyte2;
volatile unsigned int databyte1;
volatile unsigned int databyte2_e;
volatile unsigned int databyte1_e;
volatile unsigned int commandbyte;
volatile unsigned int escapebyte;
volatile unsigned int combineddata = 0;
volatile unsigned int i = 0;

int main(void)
{
    // Need to write code so the PWM can be changed through C# program

	WDTCTL = WDTPW | WDTHOLD;	// stop watchdog timer

    P2DIR |= BIT1;        // P2.1 in output mode
    P2OUT |= BIT1;        // P2.1 to output HIGH
    P2SEL1 &= ~BIT1;
    P2SEL0 |= BIT1;

    P3DIR |= BIT7;        // P3.7 or P3.6 in output mode (controls direction)
    P3OUT |= BIT7;        // P3.7 or P3.6 to output HIGH (controls direction)

	// Setup ACLCK 8MHz from DCO
	CSCTL0 = 0xA500;                        // Write password to modify CS registers
	CSCTL1 = DCOFSEL0 + DCOFSEL1;           // DCO = 8 MHz
	CSCTL2 = SELA_3;                        // ACLK = DCO
	CSCTL3 = BIT3;                          // Divide 8MHz by 8 = 1MHz

    // Configure UCA0
    UCA0CTLW0 = UCSSEL0;                             // UCSSEL0    9600 Baud Rate;
    UCA0BRW = 52;                                    // 52    208       9600 Baud Rate;
    UCA0MCTLW = 0x4900 + UCOS16 + UCBRF0;            // 0x4900 + UCOS16 + UCBRF0  9600 Baud Rate; UCBRF_5
    UCA0IE |= UCRXIE;                                // Enables interrupt upon receiving

	// Setup Timer TB2
	TB2CTL |= TBCLR;               // Resets TB2
	TB2CTL |= MC__CONTINUOUS;      // Sets into UP Mode
	TB2CTL |= TBSSEL__ACLK;        // Set the ACLK (1MHz)
	TB2CTL |= ID_3;                // Divides input by 8 (125kHz)
	TB2CCTL1 |= OUTMOD_3;          // Selects set/reset output mode TB2.1

	TB2CCR0 = 0;                // Sets the PWM Duty cycle

    // global interrupt enable
    _EINT();

    while(1){
        // Finds the start byte
        if(circ_buffer[i] == 255 && end == 5){
            circ_buffer[i] = 0;
            // Extracts command byte (i+1)
            commandbyte = circ_buffer[i+1];
            circ_buffer[i+1] = 0;
            // Extracts data byte 1 (i +2)
            databyte1 = circ_buffer[i+2];
            circ_buffer[i+2] = 0;
            // Extracts data byte 2 (i + 3)
            databyte2 = circ_buffer[i+3];
            circ_buffer[i+3] = 0;
            //Extracts the escape byte (i+4)
            escapebyte = circ_buffer[i+4] = 0;
            if(escapebyte == 0x01){
                databyte1_e = 255;
            }else if(escapebyte == 0x02){
                databyte2_e = 255;
            }else{
                databyte1_e = databyte1;
                databyte2_e = databyte2;
            }
            circ_buffer[i+4] = 0;
            // Combines the two data points into a 16-bit numbers
            combineddata = (databyte1_e << 8) | (databyte2_e & 0xff);  // Combines two 8-bit numbers into a 16-bit number
            TB2CCR0 = combineddata;  // Changes the duty cycle of the square wave

            // Changes back databytes back to original values
            databyte1_e = databyte1;
            databyte2_e = databyte2;
        }
        if(i >= 4){
            i = 0;
        }
        else{
            i++;
        }
    }
	
	return 0;
}

#pragma vector = USCI_A0_VECTOR
__interrupt void USCI_A0_ISR(void)
{
    unsigned char RxByte;

    // Stores incoming byte into RxByte
    RxByte = UCA0RXBUF;

    // Stores byte into circular buffer;
    if(end == 5){
        end = 0;
    }
    circ_buffer[end] = RxByte;
    end++;
    data_count++;
}
