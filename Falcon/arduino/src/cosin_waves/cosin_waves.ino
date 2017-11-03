#include "falcon_interface.h"

void setup() 
{
  falcon::initSerial(9600);
}

double i = 0;

void loop() 
{
	/* create a double array */
	falcon::data data;

	/* fill array with values */
	data.indx0 = cos(i);
	data.indx1 = sin(i);

	/* publish data to Falcon Inspector */
	falcon::publish(data);

	/* update your data */
	i += 0.1;

	/* use delay to control data publishing rate */
	delay(50);
}
