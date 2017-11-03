#ifndef FALCON_INTERFACE_H
#define FALCON_INTERFACE_H

#define COM Serial
#define START_END_DELIM "|"
#define VALS_DELIM ","

namespace falcon
{
  struct data
  {
    double indx0 = 0,
           indx1 = 0,
           indx2 = 0,
           indx3 = 0,
           indx4 = 0,
           indx5 = 0,
           indx6 = 0,
           indx7 = 0,
           indx8 = 0,
           indx9 = 0;
  };
  
	static void initSerial(int baudrate)
	{
		COM.begin(baudrate);
	}

  /* publish data in "| , , |" format */
	static void publish(const data &data)
	{
		COM.print(START_END_DELIM);

	    COM.print(data.indx0);
		COM.print(VALS_DELIM);
	    COM.print(data.indx1);
	    COM.print(VALS_DELIM);
	    COM.print(data.indx2);
	    COM.print(VALS_DELIM);
	    COM.print(data.indx3);
	    COM.print(VALS_DELIM);
	    COM.print(data.indx4);
	    COM.print(VALS_DELIM);
	    COM.print(data.indx5);
	    COM.print(VALS_DELIM);
	    COM.print(data.indx6);
	    COM.print(VALS_DELIM);
	    COM.print(data.indx7);
	    COM.print(VALS_DELIM);
	    COM.print(data.indx8);
	    COM.print(VALS_DELIM);
	    COM.print(data.indx9);
		
		COM.println(START_END_DELIM);
	}
}


#endif
