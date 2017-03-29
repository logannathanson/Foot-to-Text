# Foot-to-Text

Foot-to-Text is an assistive technology that helps a fellow University of Michigan student, Brad, type long phrases more easily by selecting pre-defined text macros with the press of a button on a foot panel.

In our Alpha release, we have a working graphical interface that responds to button presses.

There are two possible builds. For general debugging and testing purposes we currently simulate with the F1 - F4 keys. We also have it working with four buttons on the arduino.

The keys correspond to the following actions:

Button | Action Name | Description
--- | --- | ---
**F1/First** | Back | go to previous menu
**F2/Second** | UP | scroll up an option
**F3/Third** | Down | scroll down an option
**F4/Fourth** | Select | select the category of phrases, or if highlighting a text phrase, type the phrase in the current window

## Source code organization
The source code for this project is found in two directories:
1. `KeyboardInterface\` contains the source for the main process, written in C++. It includes the logic for opening and parsing the categories and phrases (main module), populating the GUI (main, View, AppWindow), sending and recieving keyboard events (Keyboard), and recieving foot pedal press events (main).
2. `WindowsFormApplication1\WindowsFormApplication1` is the source for the front-end GUI window that is displayed to the user. It is written in C# using the Windows Form graphical framework. The primary source file for this module is `Form1.cs`.

## Build and Run Instructions

*Prerequisites*: Windows operating system (ideally Windows 10), Visual Studio 2015 with Visual C++ and Windows Forms. To run with the arduino the Boost library is required, as well as the Arduino IDE.

1. Navigate to the project directory > Main
2. Open the `.sln` file in Visual Studio
    1. *To use the Arduino*: Click the Debug tab then select Main Properties
    2. Go to C/C++ and click on command line
    3. In the additonal options box type /D OUR_ARDUINO
3. Go to Build and click Build Solution
4. Navigate to project directory > WindowsFormApplication1
5. Open the `.sln` file in Visual Studio
6. Press "Start" to bulid and run the GUI, which will also run the background Keyboard process.
7. Open a text editing program and try it out
