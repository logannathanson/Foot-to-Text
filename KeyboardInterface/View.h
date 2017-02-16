#pragma once

#include <string>
#include <windows.h>

#include "AppWindow.h"

class View
{
public:
	View(const std::string& program_name);

	void set_button(int which, const std::string& text);

private:
	AppWindow window;
};
