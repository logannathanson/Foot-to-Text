@echo off
REM Our super jank build system

IF NOT DEFINED RANVARS (
    call "C:\Program Files (x86)\Microsoft Visual Studio 14.0\VC\vcvarsall.bat"
    set RANVARS=1
    echo "VC is now set"
)

cl main.cpp Keyboard.cpp View.cpp AppWindow.cpp /EHsc User32.lib
