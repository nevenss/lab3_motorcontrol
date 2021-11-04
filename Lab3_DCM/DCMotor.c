#include <msp430.h> 


/**
 * main.c
 */
int main(void)
{
	WDTCTL = WDTPW | WDTHOLD;	// stop watchdog timer
	
    // Configure Clocks
        CSCTL0 = 0xA500;                        // Write password to modify CS registers
        CSCTL1 = DCOFSEL0 + DCOFSEL1;           // DCO = 8 MHz
        CSCTL2 = SELM0 + SELM1 + SELS0 + SELS1;//SELA0 + SELA1; // MCLK = DCO, ACLK = DCO, SMCLK = DCO
        CSCTL3 = DIVS_0;


	return 0;
}
