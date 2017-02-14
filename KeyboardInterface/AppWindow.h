#pragma once

#include <string>
#include <windows.h>

#include "MessageType.h"

class AppWindow
{
public:
	AppWindow(const std::string& program_name);

	void notify(MessageType msg, const std::string&);

private:
	HWND window_handle;
};
