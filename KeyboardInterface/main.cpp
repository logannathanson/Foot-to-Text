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

HHOOK kbdhook;
__declspec(dllexport) LRESULT CALLBACK handlekeys(int code, WPARAM wp, LPARAM lp)
{
	if (code == HC_ACTION && (wp == WM_SYSKEYDOWN || wp == WM_KEYDOWN)) {
		KBDLLHOOKSTRUCT st_hook = *((KBDLLHOOKSTRUCT*)lp);
		DWORD key = st_hook.vkCode;
		
		switch (key)
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

	return CallNextHookEx(kbdhook, code, wp, lp);
}

int main()
{
	HINSTANCE modulehandle = GetModuleHandle(NULL);
	kbdhook = SetWindowsHookEx(WH_KEYBOARD_LL, (HOOKPROC)handlekeys, modulehandle, NULL);

	MSG	msg;
	bool running = true;
	while (running)
	{
		if (!GetMessage(&msg, NULL, 0, 0))
		{
			running = false;
		}
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}

	// Exit normally
	return 0;
}
