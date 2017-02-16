#define WINVER 0x0500
#include <windows.h>
#include <WinUser.h>

#include "Keyboard.h"
#include "View.h"

#include <iostream>
#include <string>
#include <stdexcept>

#include <fstream>

int main()
{
	int i = 1;
	while (true)
	{
		try
		{
			View v {"Foot-to-Text"};

			std::string in;
			std::cin >> in;

			if (in == "q") break;
			else
			{
				v.set_button(i, in);
				i++; if (i > 4) i = 1;
			}
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
