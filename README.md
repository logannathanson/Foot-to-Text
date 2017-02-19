# Foot-to-Text

Foot-to-Text is an assistive technology that helps a fellow University of Michigan student, Brad, type long phrases more easily by selecting pre-defined text macros with the press of a button on a foot panel.

In our Alpha release, we have a working graphical interface that responds to button presses, currently simulated with the F1 - F4 keys, as the arduino button control has not yet been integrated.

The keys correspond to the following actions:

Button | Action Name | Description
--- | --- | ---
**F1** | Back | go to previous menu
**F2** | Up | scroll up an option
**F3** | Down | scroll down an option
**F4** | Select | select the category of phrases, or if highlighting a text phrase, type the phrase in the current window

## Build and Run Instructions

*Prerequisites*: Windows operating system (ideally Windows 10), Visual Studio 2015 with Visual C++ and Windows Forms.

1. Open a command prompt (Start menu and type `cmd`)
2. Navigate to the project directory > KeyboardInterface
3. Type `build`
4. Navigate to project directory > WindowsFormApplication1
5. Open the `.sln` file in Visual Studio
6. Press "Start" to bulid and run the GUI, which will also run the background Keyboard process.
7. Open a text editing program and try it out!
