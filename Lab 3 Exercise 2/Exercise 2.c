#include <msp430.h> 


/**
 * main.c
 */
volatile int stateStep = -1;
volatile char circ_buf[5];
volatile int first = 0;
volatile int last = 0;
volatile int size = 0;
volatile int state = 0;
volatile int speed = 0;
volatile int speedMode = 0;
volatile int temp = 0;

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

void moveCW(void)
{
    if(stateStep == 7){
        stateStep = 0;
    }else{
        stateStep++;
    }
    // Move forward one half-step, P#SEL0 can be switched from 1 to 0 if OFF
    switch(__even_in_range(stateStep,8))
      {
        case  0:                         // A1 ON
            P1OUT |= BIT5;
            P1OUT &= ~BIT4;
            P3OUT &= ~(BIT4 + BIT5);
            P1SEL0 &= ~BIT4;
            P1SEL0 |= BIT5;
            P3SEL0 &= ~(BIT4 + BIT5);
            while ((UCA0IFG & UCTXIFG)==0);
            UCA0TXBUF = 'a';
            break;
        case  1:                         // A1, B1 ON
            P1OUT |= BIT5;
            P1OUT &= ~BIT4;
            P3OUT &= ~(BIT4);
            P3OUT |= BIT5;
            P1SEL0 &= ~BIT4;
            P1SEL0 |= BIT5;
            P3SEL0 &= ~(BIT4);
            P3SEL0 |= BIT5;
            while ((UCA0IFG & UCTXIFG)==0);
            UCA0TXBUF = 'b';
            break;
        case  2:                         // B1 ON
            P1OUT &= ~(BIT4 + BIT5);
            P3OUT &= ~(BIT4);
            P3OUT |= BIT5;
            P1SEL0 &= ~(BIT4 + BIT5);
            P3SEL0 &= ~(BIT4);
            P3SEL0 |= BIT5;
            while ((UCA0IFG & UCTXIFG)==0);
            UCA0TXBUF = 'c';
            break;
        case  3:                         // B1, A2 ON
            P1OUT &= ~(BIT5);
            P1OUT |= BIT4;
            P3OUT &= ~(BIT4);
            P3OUT |= BIT5;
            P1SEL0 &= ~(BIT5);
            P1SEL0 |= BIT4;
            P3SEL0 &= ~(BIT4);
            P3SEL0 |= BIT5;
            while ((UCA0IFG & UCTXIFG)==0);
            UCA0TXBUF = 'd';
            break;
        case  4:                         // A2 ON
            P1OUT &= ~(BIT5);
            P1OUT |= BIT4;
            P3OUT &= ~(BIT4 + BIT5);
            P1SEL0 &= ~(BIT5);
            P1SEL0 |= BIT4;
            P3SEL0 &= ~(BIT4 + BIT5);
            while ((UCA0IFG & UCTXIFG)==0);
            UCA0TXBUF = 'e';
            break;
        case  5:                         // A2, B2 ON
            P1OUT &= ~(BIT5);
            P1OUT |= BIT4;
            P3OUT &= ~(BIT5);
            P3OUT |= BIT4;
            P1SEL0 &= ~(BIT5);
            P1SEL0 |= BIT4;
            P3SEL0 |= BIT4;
            P3SEL0 &= ~BIT5;
            while ((UCA0IFG & UCTXIFG)==0);
            UCA0TXBUF = 'f';
            break;
        case  6:                         // B2 ON
            P1OUT &= ~(BIT4 + BIT5);
            P3OUT &= ~(BIT5);
            P3OUT |= BIT4;
            P1SEL0 &= ~(BIT4 + BIT5);
            P3SEL0 |= BIT4;
            P3SEL0 &= ~BIT5;
            while ((UCA0IFG & UCTXIFG)==0);
            UCA0TXBUF = 'g';
            break;
        case  7:                         // A1, B2 ON
            P1OUT &= ~(BIT4);
            P1OUT |= BIT5;
            P3OUT &= ~(BIT5);
            P3OUT |= BIT4;
            P1SEL0 &= ~(BIT4);
            P1SEL0 |= BIT5;
            P3SEL0 |= BIT4;
            P3SEL0 &= ~BIT5;
            while ((UCA0IFG & UCTXIFG)==0);
            UCA0TXBUF = 'h';
            break;
      }
}

void moveCCW(void)
{
    if(stateStep == 0){
        stateStep = 7;
    }else{
        stateStep--;
    }
    // Move backward one half step
    switch(__even_in_range(stateStep,8))
      {
        case  0:                         // A1 ON
            P1OUT |= BIT5;
            P1OUT &= ~BIT4;
            P3OUT &= ~(BIT4 + BIT5);
            P1SEL0 &= ~BIT4;
            P1SEL0 |= BIT5;
            P3SEL0 &= ~(BIT4 + BIT5);
            while ((UCA0IFG & UCTXIFG)==0);
            UCA0TXBUF = 'a';
            break;
        case  1:                         // A1, B1 ON
            P1OUT |= BIT5;
            P1OUT &= ~BIT4;
            P3OUT &= ~(BIT4);
            P3OUT |= BIT5;
            P1SEL0 &= ~BIT4;
            P1SEL0 |= BIT5;
            P3SEL0 &= ~(BIT4);
            P3SEL0 |= BIT5;
            while ((UCA0IFG & UCTXIFG)==0);
            UCA0TXBUF = 'b';
            break;
        case  2:                         // B1 ON
            P1OUT &= ~(BIT4 + BIT5);
            P3OUT &= ~(BIT4);
            P3OUT |= BIT5;
            P1SEL0 &= ~(BIT4 + BIT5);
            P3SEL0 &= ~(BIT4);
            P3SEL0 |= BIT5;
            while ((UCA0IFG & UCTXIFG)==0);
            UCA0TXBUF = 'c';
            break;
        case  3:                         // B1, A2 ON
            P1OUT &= ~(BIT5);
            P1OUT |= BIT4;
            P3OUT &= ~(BIT4);
            P3OUT |= BIT5;
            P1SEL0 &= ~(BIT5);
            P1SEL0 |= BIT4;
            P3SEL0 &= ~(BIT4);
            P3SEL0 |= BIT5;
            while ((UCA0IFG & UCTXIFG)==0);
            UCA0TXBUF = 'd';
            break;
        case  4:                         // A2 ON
            P1OUT &= ~(BIT5);
            P1OUT |= BIT4;
            P3OUT &= ~(BIT4 + BIT5);
            P1SEL0 &= ~(BIT5);
            P1SEL0 |= BIT4;
            P3SEL0 &= ~(BIT4 + BIT5);
            while ((UCA0IFG & UCTXIFG)==0);
            UCA0TXBUF = 'e';
            break;
        case  5:                         // A2, B2 ON
            P1OUT &= ~(BIT5);
            P1OUT |= BIT4;
            P3OUT &= ~(BIT5);
            P3OUT |= BIT4;
            P1SEL0 &= ~(BIT5);
            P1SEL0 |= BIT4;
            P3SEL0 |= BIT4;
            P3SEL0 &= ~BIT5;
            while ((UCA0IFG & UCTXIFG)==0);
            UCA0TXBUF = 'f';
            break;
        case  6:                         // B2 ON
            P1OUT &= ~(BIT4 + BIT5);
            P3OUT &= ~(BIT5);
            P3OUT |= BIT4;
            P1SEL0 &= ~(BIT4 + BIT5);
            P3SEL0 |= BIT4;
            P3SEL0 &= ~BIT5;
            while ((UCA0IFG & UCTXIFG)==0);
            UCA0TXBUF = 'g';
            break;
        case  7:                         // A1, B2 ON
            P1OUT &= ~(BIT4);
            P1OUT |= BIT5;
            P3OUT &= ~(BIT5);
            P3OUT |= BIT4;
            P1SEL0 &= ~(BIT4);
            P1SEL0 |= BIT5;
            P3SEL0 |= BIT4;
            P3SEL0 &= ~BIT5;
            while ((UCA0IFG & UCTXIFG)==0);
            UCA0TXBUF = 'h';
            break;
      }
}

int main(void)
{
	WDTCTL = WDTPW | WDTHOLD;	// stop watchdog timer
	
    // Configure clocks
    CSCTL0 = 0xA500;                                        // Write password to modify CS registers
    CSCTL1 = DCOFSEL0 + DCOFSEL1;                           // DCO = 8 MHz
    CSCTL2 = SELM0 + SELM1 + SELA0 + SELA1 + SELS0 + SELS1; // MCLK = XTLK1, ACLK = XTLK1, SMCLK = XTLK1 add SELM1, SELA1, SELS1
    //CSCTL3 = BIT3;                                          // Divide 8MHz by 8 = 1MHz

    // Configure ports for UCA0
    P2SEL0 &= ~(BIT0 + BIT1);
    P2SEL1 |= BIT0 + BIT1;

    // Stepper Motor Pins (Outputs)
    P1DIR |= BIT4 + BIT5;
    P3DIR |= BIT4 + BIT5;
    P3OUT &= ~(BIT4 + BIT5);
    P1OUT &= ~(BIT4 + BIT5);

    // Need timers for motor input pins (P3.4 = TB1.1, P3.5 = TB1.2, P1.4 = TB0.1, P1.5 = TB0.2)
    // TB1 for pins 3.5 and 3.4
    TB1CTL |= TBCLR;               // Resets TB2
    TB1CTL |= MC__UP;              // Sets into UP Mode
    TB1CTL |= TBSSEL__ACLK;        // Set the ACLK (1MHz)
    TB1CTL |= ID_3;                // Divides input by 8 (125kHz)
    TB1CCTL1 |= OUTMOD_3;          // Selects set/reset output mode TB1.1
    TB1CCTL2 |= OUTMOD_3;          // Selects set/reset output mode TB1.2
    TB1CCR0 = 32000;                // Sets the PWM Period
    TB1CCR1 = 26000;                // Sets the PWM Duty cycle (25%)
    TB1CCR2 = 26000;                // Sets the PWM Duty cycle (25%)

    // TB0 for pins 1.5 and 1.4
    TB0CTL |= TBCLR;               // Resets TB2
    TB0CTL |= MC__UP;              // Sets into UP Mode
    TB0CTL |= TBSSEL__ACLK;        // Set the ACLK (1MHz)
    TB0CTL |= ID_3;                // Divides input by 8 (125kHz)
    TB0CCTL1 |= OUTMOD_3;          // Selects set/reset output mode TB1.1
    TB0CCTL2 |= OUTMOD_3;          // Selects set/reset output mode TB1.2
    TB0CCR0 = 32000;                // Sets the PWM Period
    TB0CCR1 = 26000;                // Sets the PWM Duty cycle (25%)
    TB0CCR2 = 26000;                // Sets the PWM Duty cycle (25%)

    // Configure UCA0
    UCA0CTLW0 = UCSSEL0;                             // UCSSEL0    9600 Baud Rate;
    UCA0BRW = 52;                                    // 52    208       9600 Baud Rate;
    UCA0MCTLW = 0x4900 + UCOS16 + UCBRF0;            // 0x4900 + UCOS16 + UCBRF0  9600 Baud Rate; UCBRF_5
    UCA0IE |= UCRXIE;                                // Enables interrupt upon receiving

    // global interrupt enable
    _EINT();

    int j;

    while (1)
    {
        if ((speedMode == 1) || (speedMode == 2))
        {
            if (speedMode == 1) moveCW();
            if (speedMode == 2) moveCCW();
            //__delay_cycles(speed); // Cant use without a constant
            for(j=0;j<speed;j++){
                _NOP();  // Function that does nothing
            }
        }
        //UCA0TXBUF = 'z';                            // Periodically outputs the char 'a'
        //__delay_cycles(1000000);
    }
	return 0;
}

#pragma vector = USCI_A0_VECTOR
__interrupt void USCI_A0_ISR(void)
{
    // Need a state machine (switch case statement)
    char RxByte;
    RxByte = UCA0RXBUF;
    circ_buf[last] = RxByte;

    if(last == 4){
        size = 1;
    }else{
        last++;
    }

    if (size == 1)
    {
        switch(state)
        {
        case 0:
            if(circ_buf[first] == 255) state = 1;
            else dequeue();
            break;
        case 1:
            if (circ_buf[first+1] == 1) //CW SPEED
            {
                speedMode = 1;
            }
            else if (circ_buf[first+1] == 2) //CCW SPEED
            {
                speedMode = 2;
            }
            else if (circ_buf[first+1] == 3) //CW MOVE
            {
                speedMode = 0;
                moveCW();
                dequeue();
            }
            else if (circ_buf[first+1] == 4) //CCW MOVE
            {
                speedMode = 0;
                moveCCW();
                dequeue();
            }
            else
            {
                speedMode = 0;
            }
            break;
        case 2:
            if (circ_buf[first+4] == 3)
            {
                circ_buf[first+2] = 255;
                circ_buf[first+3] = 255;
            }
            else if (circ_buf[first+4] == 1)
            {
                circ_buf[first+2] = 255;
            }
            else if (circ_buf[first+4] == 1)
            {
                circ_buf[first+3] = 255;
            }
            temp = circ_buf[first+2];
            speed = ((temp<<8)+circ_buf[first+3]);
            dequeue();
        }
    }
}
