/*******************************************************************************
* Copyright (c) 2018 Elhay Rauper
* All rights reserved.
*
* Redistribution and use in source and binary forms, with or without
* modification, are permitted (subject to the limitations in the disclaimer
* below) provided that the following conditions are met:
*
*     * Redistributions of source code must retain the above copyright notice,
*     this list of conditions and the following disclaimer.
*
*     * Redistributions in binary form must reproduce the above copyright
*     notice, this list of conditions and the following disclaimer in the
*     documentation and/or other materials provided with the distribution.
*
*     * Neither the name of the copyright holder nor the names of its
*     contributors may be used to endorse or promote products derived from this
*     software without specific prior written permission.
*
* NO EXPRESS OR IMPLIED LICENSES TO ANY PARTY'S PATENT RIGHTS ARE GRANTED BY
* THIS LICENSE. THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND
* CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
* LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A
* PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR
* CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL,
* EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
* PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR
* BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER
* IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
* ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
* POSSIBILITY OF SUCH DAMAGE.
*******************************************************************************/

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
