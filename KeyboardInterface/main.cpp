#define WINVER 0x0500
#include <windows.h>
#include <WinUser.h>

#include "Keyboard.h"
#include "View.h"

#include <iostream>
#include <string>
#include <stdexcept>

int main()
{
	while (true)
	{
		try
		{
			View v {"Foot-to-Text"};
			v.test();

			std::string in;
			std::cin >> in;
			if (in == "q") break;
		}
		catch (std::exception& e)
		{
			std::cerr << e.what() << std::endl;
			exit(1);
		}
	}


	// Exit normally
	return 0;
}
