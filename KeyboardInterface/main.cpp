#define WINVER 0x0500
#include <windows.h>
#include <WinUser.h>

#include "Keyboard.h"

#include <iostream>
#include <string>
#include <stdexcept>

enum class Message
{
	Test = WM_USER,
	Test1
};

BOOL CALLBACK find_app(HWND window_handle, LPARAM p)
{
	const size_t max_buffer_length = 64;
	TCHAR buffer[max_buffer_length];

	GetWindowText(window_handle, buffer, max_buffer_length);

	if (std::string(buffer).find("Form1") != std::string::npos)
	{
		*(reinterpret_cast<HWND*>(p)) = window_handle;
		return false;
	}

	return true;
}

int main()
{
	HWND app_window = nullptr;

	int success = EnumWindows(find_app, reinterpret_cast<LPARAM>(&app_window));
	if (success != 0)
	{
		std::cerr << "Open app!" << std::endl;
		exit(1);
	}
	
	SetForegroundWindow(app_window);

	try
	{
		// Keyboard::get_instance().send_word("Hello, world!\n");
		SendMessage(app_window, (UINT) Message::Test, (WPARAM) nullptr, (LPARAM) nullptr);

		std::string next;
		std::cin >> next;
		if (next == "go!")
			SendMessage(app_window, (UINT) Message::Test1, (WPARAM) nullptr, (LPARAM) nullptr);
	}
	catch (std::exception& e)
	{
		std::cerr << e.what() << std::endl;
		exit(1);
	}

	// Exit normally
	return 0;
}
