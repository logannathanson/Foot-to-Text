#define WINVER 0x0500
#include <windows.h>
#include <WinUser.h>

#include "Keyboard.h"
#include "View.h"

#include <iostream>
#include <string>
#include <stdexcept>

#include <fstream>

/*
	Eventually, we'll want all this abstracted into a Controller.
	Hack it for now.
*/

View v {"Foot-to-Text"}; // This is super bad :'/
// Note that due to this ^ if you try to run this process without the GUI open
// it'll crash.

void f1_press()
{
	v.set_button(1, "yo dawg");
}

void f2_press()
{
	v.set_button(2, "qu'est-ce que c'est");
}

void f3_press()
{
	v.set_button(3, "was ist das");
}

void f4_press()
{
	v.set_button(4, "que");
}

HHOOK keypress_hook;
LRESULT CALLBACK keypress_callback(int code, WPARAM wp, LPARAM lp)
{
	if (code == HC_ACTION && (wp == WM_SYSKEYDOWN || wp == WM_KEYDOWN)) {
		KBDLLHOOKSTRUCT key_data = *((KBDLLHOOKSTRUCT*)lp);
		DWORD virtual_key = key_data.vkCode;
		
		switch (virtual_key)
		{
			case VK_F1:
				f1_press();
				break;
			case VK_F2:
				f2_press();
				break;
			case VK_F3:
				f3_press();
				break;
			case VK_F4:
				f4_press();
				break;
		}
	}

	return CallNextHookEx(keypress_hook, code, wp, lp);
}

int main()
{
	HINSTANCE module_handle = GetModuleHandle(NULL);
	keypress_hook = SetWindowsHookEx(WH_KEYBOARD_LL, (HOOKPROC)keypress_callback, module_handle, NULL);

	MSG	msg;
	while (GetMessage(&msg, NULL, 0, 0))
	{
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}

	// Exit normally
	return 0;
}
