# Falcon Com Inspecor

## What Is It
Falcon is a communication inspection tool. It mainly enables you to test UDP, TCP and Serial communication easily. But that is not it, Falcon is packed with other capabilities:
1. Pinging IP address
2. SSH connection
3. Data visualization - Plot of incoming data
4. Package Wizard - Test application level protocols
5. Log data to file
And more...

Falcon was desinged with ease of use in mind, and I hope you will find it helpful.

## How Do I Contact You About Features / Bugs ? 
Use the [issues section](https://github.com/elhayra/falcon-com-inspector/issues). Please describe in details what is the issue, and I will try to answer as soon as possible.

## Installation
No installation is needed for running Falcon. Just [download it](https://github.com/elhayra/falcon-com-inspector/releases/download/V0.2.0/Falcon.zip) and run.

## Usage

The next section is dedicated to brief instructions on how to use Falcon.

### 1. Main Screen

![alt text](https://github.com/elhayra/falcon-com-inspector/blob/master/doc_images/first_impression.JPG "Main Screen")

The main screen is devided to sub-sections:

#### 1.1 Left Column (1)

here you can chose the type of connection protocol you want to listen / publish to. For TCP and UDP connection you can open either a client or a server. When choosing server, IP text box will disapear, because it is determined automatically by the PC current IP.
When listening on a TCP server, an indication "Incoming clients" show you how many clients are connected to you.
On Serial connection, the "COM:" list will be filled with available usb serial connections. Choose one and set the serial settings according to your needs.

Note: At all times, only a single connection is allowed.

#### 1.2 Top Bar (2)
This bar is showing you some statistics about bytes stream:
1. RX: total bytes recieved
2. TX: total bytes sent
3. Rx Rate: current bytes sending rate
4. Tx Rate: current bytes recieved rate
5. TCP / UDP / SER flags: turn on in green whenever one of those protocols is being used

#### 1.3 Display (3)
The display show the incoming bytes

#### 1.4 Bottom Bar (4)
This part consist of the sending text box, and 3 buttons: send, clear and reset.
Write anything in the sending windows, and press "enter" or "send" to send it throught the open connection. If no connection is open, no sending attempt will be made. This text box also save the sending history. When inside that box, you can use the up/down arrows to skip throught history.

Clear button will clear the display from any characters.

Reset button will reset the statistics on the top bar.

#### 1.5 Right Column
This section enables you to set different settings from bytes representation to line ending (for sending).
Most of these settings doesn't need to be explained as they speak for themselves. But here are some who do:
1. Detailed checkbox - will print time stamp for every incoming packate
2. PKG WIZ - will be discussed later in this document.

Features:
1. Send File - click "send". A conversation window will apear - select text file. Once the text file is selected, it will be sent on the open connection.
2. Log To File - click "...", A conversation window will apear - select a folder to store your log file in. Name is generated for logs automatically and is assembled by the following format "falcon_<timespatmp>.txt". The log file will contain all the printing inside the display from the moment it was created.
  
### 2. Falcon Command Line (CLI)
![alt text](https://github.com/elhayra/falcon-com-inspector/blob/master/doc_images/cli.JPG "Falcon Command Line")

Navigate to CLI:
Tools -> Command Line

The falcon CLI enables you to write a set of commands (some of them are similar to windows / linux commands) in order to use additional falcon capabilities. Those are the available commands:
ssh, ping, help, clear.
To understand how to use any of those commands, type "help" and then the name of the command. For example:

```
help ssh
```

This will result in an output of what is the command, its structure and example how to use it.

### 3. Package Wizard (PKG WIZ)
![alt text](https://github.com/elhayra/falcon-com-inspector/blob/master/doc_images/pkg_wiz_manage.JPG "Package Wizard")

Navigate to PKG WIZ:
On the right column, inside the PKG WIZ box, click "Load"

Imagine you need to implement an application level protocol. Wouldn't it be nice if you could send a dummy package of that protocol, and let Falcon parse that package for you in order to test it? Well, it can be done pretty easily. 

Inside the PKG WIZ manager, create a package according to your protocol:
Choose a field type, give it a name and press "Add". This will add the field to the package. Later PKG WIZ will try to parse the incoming bytes into the defined package. The order of which the fields appear in the list, is the same one used for parsing.
After you are done building the package, press "X" to close the PKG WIZ window, connect to UDP or TCP server or client, and check the "Parse" checkbox inside the PKG WIZ box on the right column. If packages are parsed successfuly, you should see something like this (depending on your package) :
![alt text](https://github.com/elhayra/falcon-com-inspector/blob/master/doc_images/pkg_wiz.JPG "Package Wizard Data")

Note: PKG WIZ parsing can only work with TCP or UDP connections for now.

### 4. Plot
![alt text](https://github.com/elhayra/falcon-com-inspector/blob/master/doc_images/plot_no_data.JPG "Plot When No Incoming Data Arrives")

Navigate to Plot:
Tools -> Plot

Before openning plot window, connect and make sure you are getting data inside the display. When opening the plot window, it listens on the open connection. If no incoming data, a "NO DATA" red flag will apear. Otherwise, if there is data but it is unvalid, a "INVALID DATA" red flag will apear. A valid data is a string which contains 10 doubles by "," . The string should start and end with "|" . So for example:

```
|-0.87,0.50,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00|
```

In the above string the 2 first values are -0.87 in index 0, and 0.5 in index 1. The rest of the values are 0. While getting data, we need to add it to the plot in order to get a visual representation of it. Click on "Add/Remove Series" button at the bottom left corner of the plot window. Then, Select a series type:
1. Data - double value from one of the 10 indexes of the incoming data.
2. Setpoint - will draw a vertical line at the selected y value
3. Bytes Rate - draw plot of incoming bytes rate.

For this example, add Data type, name it "some double" and select index 0. Then press add, and "X" to close the series manager. Now the values in index 0 of the incoming string should appear on the plot. In top left side there is a tree of values. Expand it to see the numeric valud of index 0.
In the bottom right corner, you can define how long will be the tail of the line on the graph. In other words: how many values since last one arrived to show on the plot. If you change this, click "Apply".
If you are using arduino and want to see some values on the plot, look at the plot example of arduino [here](https://github.com/elhayra/falcon-com-inspector/tree/master/arduino/src/cosin_waves). Flash this example to your board, open Falcon and connect to it throught Serial. Then open plot and add the desired data index. It should look something like that:
![alt text](https://github.com/elhayra/falcon-com-inspector/blob/master/doc_images/plot_with_data.JPG "Plot Arduino Example")






