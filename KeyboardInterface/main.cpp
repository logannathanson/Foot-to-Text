#define WINVER 0x0500
#include <windows.h>
#include <WinUser.h>

#include "Keyboard.h"

#include <iostream>
#include <string>
#include <stdexcept>

BOOL CALLBACK find_notepad(HWND window_handle, LPARAM p)
{
	const size_t max_buffer_length = 64;
	TCHAR buffer[max_buffer_length];

	GetWindowText(window_handle, buffer, max_buffer_length);

	if (std::string(buffer).find("Notepad") != std::string::npos)
	{
		*(reinterpret_cast<HWND*>(p)) = window_handle;
		return false;
	}

	return true;
}

int main()
{
	HWND notepad_window = nullptr;

	int success = EnumWindows(find_notepad, reinterpret_cast<LPARAM>(&notepad_window));
	if (success != 0)
	{
		std::cerr << "Open notepad!" << std::endl;
		exit(1);
	}
	
	SetForegroundWindow(notepad_window);

	try
	{
		Keyboard::get_instance().send_word("Hello, world!\n");
	}
	catch (std::exception& e)
	{
		std::cerr << e.what() << std::endl;
		exit(1);
	}

	// Exit normally
	return 0;
}
