#include <msp430.h> 

volatile char circ_buf[5];
volatile int first = 0;
volatile int last = 0;
volatile int size = 0;
volatile int state = 0;
volatile int input_count = 0;

void dequeue(void)
{
    circ_buf[0] = 0;
    circ_buf[1] = 0;
    circ_buf[2] = 0;
    circ_buf[3] = 0;
    circ_buf[4] = 0;
    first = 0;
    size = 0;
    last = 0;
}

int main(void)
{
    WDTCTL = WDTPW | WDTHOLD;   // stop watchdog timer

    // Configure LED1
    PJDIR |= BIT0;
    PJOUT &= ~BIT0;

    // Motor Pins
    P2DIR |= BIT2;        // P2.1 in output mode
    P2OUT &= ~BIT2;        // P2.1 to output LOW
    P2SEL1 &= ~BIT2;
    P2SEL0 |= BIT2;

    P3DIR |= BIT6 + BIT7;        // P3.7 or P3.6 in output mode (controls direction)
    P3OUT |= BIT6;        // P3.7 or P3.6 to output HIGH (controls direction)
    P3OUT &= ~BIT7;

    // Configure Clocks
    CSCTL0 = 0xA500;                        // Write password to modify CS registers
    CSCTL1 = DCOFSEL0 + DCOFSEL1;           // DCO = 8 MHz
    CSCTL2 = SELM0 + SELM1 + SELS0 + SELS1 + SELA0 + SELA1;//SELA0 + SELA1; // MCLK = DCO, ACLK = DCO, SMCLK = DCO
    CSCTL3 = DIVS_0;

    // Setup Timer TB2
        TB2CTL |= TBCLR;               // Resets TB2
        TB2CTL |= MC__CONTINOUS;      // Sets into CONTINUOUS Mode
        TB2CTL |= TBSSEL__ACLK;        // Set the ACLK (1MHz)
        TB2CTL |= ID_3;                // Divides input by 8 (125kHz)
        TB2CCTL0 |= OUTMOD_2;
        TB2CCTL2 |= OUTMOD_2;          // Selects set/reset output mode TB2.1
        TB2CCR0 = 0xFFFF;
        TB2CCR2 = 32000;                // Sets the PWM Duty cycle

    // Configure ports for UCA0
    P2SEL0 &= ~(BIT0 + BIT1);
    P2SEL1 |= BIT0 + BIT1;
    // Configure UCA0
    UCA0CTLW0 = UCSSEL__SMCLK;
    UCA0BRW = 52;
    UCA0MCTLW = 0x4900 + UCOS16 + UCBRF0;
    //UCA0BRW = 3;
    //UCA0MCTLW = 0x92;
    UCA0IE |= UCRXIE;

    //Set-up Timer
    TB1CTL |= TBCLR;
    TB1CTL |= MC__UP; //Control Register
    TB1CTL |= TBSSEL__ACLK;
    //Set-up both TB0CCRXs for comparison
    //250kHz
    TB1CCR1 = 250*8;
    TB1CCR0 = 500*8;
    //Set-up Capture/Compare Control Register
    TB1CCTL0 = OUTMOD_7;
    TB1CCTL1 = OUTMOD_7;
    //Set-up P3.4
    P3DIR |= BIT4;
    P3SEL0 |= BIT4;
    P3OUT &= ~BIT4;
    //Set-up P3.5
    P3DIR |= BIT5;
    P3OUT &= ~BIT5;
    P3SEL0 |= BIT5;

    // global interrupt enable
    __enable_interrupt();

    //int active_loop = 0;

    while (1)
    {
        while(size==0);
        //active_loop = 1;
        //STATE MACHINE
        switch(state)
        {
        case 0:
            if(circ_buf[first] == 255)  //CHECK FOR Start Byte - 0xFF
            {
                state = 1;
                //dequeue();
            }
            else
            {
                int i;
                dequeue();

                state = 0;
                //active_loop = 0;
            }
            break;
        case 1: //COMMAND
            if (circ_buf[first+1]==1) //CW
            {
                P3OUT |= BIT7;
                P3OUT &= ~BIT6;
            }
            else if (circ_buf[first+1]==2) //CCW
            {
                P3OUT |= BIT6;
                P3OUT &= ~BIT7;
            }
            else //OFF
            {
                P3OUT &= ~(BIT6 + BIT7);
            }
            //dequeue();
            state++;
            break;
        case 2: //ESCAPE BYTE
            if (circ_buf[first+4] == 3)
            {
                circ_buf[first+2] = 0xFF;
                circ_buf[first+3] = 0xFF;
            }
            else if (circ_buf[first+4] == 1) circ_buf[first+2] = 0xFF;
            else if (circ_buf[first+4] == 2) circ_buf[first+3] = 0xFF;
            int temp = circ_buf[first+2];
            int Freq = ((temp<<8) + circ_buf[first+3]);
            int combined = Freq;
            TB2CCR2 = combined;
            Freq = 65535 - Freq;
            TB1CCR1 = Freq/2;
            TB1CCR0 = Freq;
            while ((UCA0IFG & UCTXIFG)==0);
            UCA0TXBUF = (combined >> 8);
            while ((UCA0IFG & UCTXIFG)==0);
            UCA0TXBUF = (circ_buf[first+3]);
            state = 0;
            dequeue();
            //active_loop = 0;
            break;
        }
    }
    return 0;
}

#pragma vector = USCI_A0_VECTOR
__interrupt void USCI_A0_ISR(void)
{
    unsigned char RxByte;
    unsigned char TxByte;
    unsigned char Size_Error[12] = {"Size ErrorZ"};
    unsigned char Empty_Error[13] = {"Empty ErrorZ"};
    unsigned int error_counter = 0;
    RxByte = UCA0RXBUF;
    while ((UCA0IFG & UCTXIFG)==0);
    circ_buf[last] = RxByte;
    if(last==4)//Reset Last
    {
        size++;
    }
    else //Increment
    {
        last++;
    }
}

