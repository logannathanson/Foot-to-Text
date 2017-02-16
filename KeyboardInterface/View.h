#pragma once

#include <string>
#include <windows.h>

#include "AppWindow.h"

class View
{
public:
	View(const std::string& program_name);

	void test();
	void test1(const std::string& new_text);

private:
	AppWindow window;
};
