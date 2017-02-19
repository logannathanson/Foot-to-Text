#define WINVER 0x0500
#include <boost/asio.hpp>
#include <windows.h>
#include <WinUser.h>

#include "Keyboard.h"
#include "View.h"

#include <iostream>
#include <string>
#include <stdexcept>

#include <fstream>

#include <vector>
#include <string>
using namespace std;

/*
Eventually, we'll want all this abstracted into a Controller.
Hack it for now.
*/

View v{ "Foot-to-Text" }; // This is super bad :'/
						  // Note that due to this ^ if you try to run this process without the GUI open
						  // it'll crash.

void pretty_print2(vector<vector<string>> &vec, int cat, int p, bool i_c);
void button_update();

//TODO: fix global vars?
vector<vector<string>> phrases;
int category = 0;
int phrase = 1;
bool in_category = false;


void button_update() {
	if (!in_category) {
		if (category + 4 < phrases.size()) {
			//highlight button1
			v.set_button(5, "1");
			for (unsigned int i = category, b = 1; i < category + 4; ++i, ++b) {
				v.set_button(b, phrases[i][0]);
			}
		}
		else {
			for (unsigned int i = phrases.size() - 4, b = 1; i < phrases.size(); ++i, ++b) {
				if (i == category) {
					//highlight button b
					string button = to_string(b);
					v.set_button(5, button);
				}
				v.set_button(b, phrases[i][0]);
			}
		}
	}
	else {
		if (phrase + 4 < phrases[category].size()) {
			//highlight button 1
			v.set_button(5, "1");
			for (unsigned int i = phrase, b = 1; i < phrase + 4; ++i, ++b) {
				v.set_button(b, phrases[category][i]);
			}
		}
		else {
			for (unsigned int i = phrases[category].size() - 4, b = 1; i < phrases[category].size(); ++i, ++b) {
				if (i == phrase) {
					//highlight button b
					string button = to_string(b);
					v.set_button(5, button);
				}
				v.set_button(b, phrases[category][i]);
			}
		}
	}
	pretty_print2(phrases, category, phrase, in_category);
}

//TODO: remove pretty_print
void pretty_print2(vector<vector<string>> &vec, int cat, int p, bool i_c) {
	cout << endl;
	if (!i_c) {
		if (cat + 4 < vec.size()) {
			cout << "> ";
			for (int i = cat; i < cat + 4; ++i) {
				cout << vec[i][0] << endl;
			}
		}
		else {
			for (int i = vec.size() - 4; i < vec.size(); ++i) {
				if (i == cat) {
					cout << "> ";
				}
				cout << vec[i][0] << endl;
			}
		}
	}
	else {
		if (p + 4 < vec[cat].size()) {
			cout << "> ";
			for (int i = p; i < p + 4; ++i) {
				cout << vec[cat][i] << endl;
			}
		}
		else {
			for (int i = vec[cat].size() - 4; i < vec[cat].size(); ++i) {
				if (i == p) {
					cout << "> ";
				}
				cout << vec[cat][i] << endl;
			}
		}
	}

	cout << endl;
}

void f1_press()
{
	if (!in_category) {
		category = 0;
	}
	in_category = false;
	phrase = 1;
	
	button_update();

}

void f2_press()
{
	if (!in_category) {
		if (category + 1 < phrases.size()) {
			++category;
		}
	}
	else {
		if (phrase + 1 < phrases[category].size()) {
			++phrase;
		}
	}
	button_update();
}

void f3_press()
{
	if (!in_category) {
		if (category - 1 >= 0) {
			--category;
		}
	}
	else {
		if (phrase - 1 >= 1) {
			--phrase;
		}
	}

	button_update();
}

void f4_press()
{
	if (!in_category)
	{
		in_category = true;
		phrase = 1;
	}

	else
	{
		Keyboard::get_instance().send_word(phrases[category][phrase]);
	}
	button_update();
}
void ArdInput() {
	boost::asio::io_service io;
	boost::asio::serial_port serial(io);
	serial.open("COM3");
	serial.set_option(boost::asio::serial_port_base::baud_rate(9600));
	char c;
	string input;
	while (1)
	{
		boost::asio::read(serial, boost::asio::buffer(&c, 1));
		if (c == '\n') {
			c = input[0];
			input = "";
			switch (c) {
			case 'b':
				f1_press();
				break;
			case 'd':
				f2_press();
				break;
			case 'u':
				f3_press();
				break;
			case 's':
				f4_press();
				break;
			}
		}
		else {
			input += c;
		}
	}

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
			cout << "F4\n";
			f4_press();
			break;
		}
	}

	return CallNextHookEx(keypress_hook, code, wp, lp);
}

int main()
{
	//read in file phrases.txt
	// Since we're running it from a different working director, gotta use a relative path
	string filename = "..\\..\\..\\..\\KeyboardInterface\\phrases.txt";
	ifstream ifs(filename);
	string line = "";
	int cat = -1;

	v.set_button(1, "yo doawg");
	while (getline(ifs, line)) {
		if (line[0] != '\t') {
			++cat;
			phrases.push_back(vector<string>());
			phrases[cat].push_back(line);
		}
		else {
			//remove initial tab character
			phrases[cat].push_back(line.erase(0, 1));
		}
	}
	//set buttons to initial state
	button_update();

#ifndef OUR_ARDUINO
	HINSTANCE module_handle = GetModuleHandle(NULL);
	keypress_hook = SetWindowsHookEx(WH_KEYBOARD_LL, (HOOKPROC)keypress_callback, module_handle, NULL);

	MSG	msg;
	while (GetMessage(&msg, NULL, 0, 0))
	{
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}
#else
	ArdInput();
#endif

	// Exit normally
	return 0;
}

