#define WINVER 0x0500

#ifdef OUR_ARDUINO
#include <boost/asio.hpp>
#endif

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
#include <cassert>
#include <algorithm>



using namespace std;

/*
Eventually, we'll want all this abstracted into a Controller.
Hack it for now.
*/

View v{ "Foot-to-Text" }; // This is super bad :'/
						  // Note that due to this ^ if you try to run this process without the GUI open
						  // it'll crash.

void button_update();

class Phrase {
	public:
		string s;
		string original;
		int c;
		Phrase(string in_string, int in_count) {
			s = in_string;
			c = in_count;
			original = in_string;
		}
		bool operator < (const Phrase& p) const {
			return c > p.c;
		}
};


//TODO: fix global vars?
vector<vector<Phrase>> phrases;
vector<string> comments;
int category = 0;
int phrase = 1;
bool in_category = false;

//call this function to save the file upon exit
void save_file(vector<vector<Phrase>>& phrases, vector<string>& comments, string filename) {
	ofstream myfile;
	myfile.open(filename);
	for (int i = 0; i < comments.size(); ++i) {
		myfile << comments[i] << endl;
	}
	for (int cat = 0; cat < phrases.size(); ++cat) {
		for (int phrase = 0; phrase < phrases[cat].size(); ++phrase) {
			if (phrase == 0) {
				myfile << phrases[cat][phrase].s << endl;
			}
			else {
				myfile << "\t" << phrases[cat][phrase].c << " " << phrases[cat][phrase].original << endl;
			}
		}
	}
	myfile.close();
}

void newlines(vector<vector<Phrase>>& phrases) {
	for (int i = 0; i < phrases.size(); ++i) {
		for (int j = 1; j < phrases[i].size(); ++j) {
			for (auto k = (phrases[i][j].s).begin(); k < (phrases[i][j].s).end(); ++k) {
				if (*k == '\\' && *(k + 1) == 'n') {
					(phrases[i][j].s).erase(k);
					*k = '\n';
				}
			}
		}
	}
}

void button_update() {
	if (!in_category) {
		if (category + 4 < phrases.size()) {
			//highlight button1
			v.set_button(5, "1");
			for (unsigned int i = category, b = 1; i < category + 4; ++i, ++b) {
				v.set_button(b, phrases[i][0].s);
			}
		}
		else {
			for (unsigned int i = phrases.size() - 4, b = 1; i < phrases.size(); ++i, ++b) {
				if (i == category) {
					//highlight button b
					string button = to_string(b);
					v.set_button(5, button);
				}
				v.set_button(b, phrases[i][0].s);
			}
		}
	}
	else {
		if (phrase + 4 < phrases[category].size()) {
			//highlight button 1
			v.set_button(5, "1");
			for (unsigned int i = phrase, b = 1; i < phrase + 4; ++i, ++b) {
				v.set_button(b, phrases[category][i].s);
			}
		}
		else {
			for (unsigned int i = phrases[category].size() - 4, b = 1; i < phrases[category].size(); ++i, ++b) {
				if (i == phrase) {
					//highlight button b
					string button = to_string(b);
					v.set_button(5, button);
				}
				v.set_button(b, phrases[category][i].s);
			}
		}
	}
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

void f3_press()
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

void f4_press()
{
	if (!in_category)
	{
		in_category = true;
		phrase = 1;
	}

	else
	{
		// Decide if it's a keyboard shortcut we're sending
		const auto& word = phrases[category][phrase].s;
		++phrases[category][phrase].c; //increment current count
		if (phrase - 1 > 0){
			if (phrases[category][phrase].c > phrases[category][phrase - 1].c) {
				//swap if the phrase's priority increases
				string temp_s = phrases[category][phrase].s;
				int temp_c = phrases[category][phrase].c;
				phrases[category][phrase].s = phrases[category][phrase - 1].s;
				phrases[category][phrase].c = phrases[category][phrase - 1].c;
				phrases[category][phrase - 1].s = temp_s;
				phrases[category][phrase - 1].c = temp_c;
				phrase -= 1;
			}
		}
		if (word.find("Ctrl") != std::string::npos
			|| word.find("Alt") != std::string::npos
			|| word.find("Shift") != std::string::npos)
		{
			// Assumptions: the keyboard shortcut is formatted to start with
			// Ctrl, Alt, and/or Shift, separated by dashes, followed by
			// a letter or one of [Del,Tab,Esc]

			auto mods = ModifierPkg{};
			if (word.find("Ctrl") != std::string::npos)
			{
				mods.ctrl = true;
			}

			if (word.find("Alt") != std::string::npos)
			{
				mods.alt = true;
			}

			if (word.find("Shift") != std::string::npos)
			{
				mods.shift = true;
			}

			// The rest of the sequence: must be either a single letter,
			// or one of "Tab", "Del", or "Esc", case-insensitive
			int pos = word.find_last_of('+');
			assert(pos < (word.size() - 1) && "Shortcut string not well formatted");

			std::string key = word.substr(pos + 1);
			Keyboard::Key keyboard_input(key);

			Keyboard::get_instance().send_shortcut(mods, keyboard_input);
		}
		else
		{
			Keyboard::get_instance().send_word(phrases[category][phrase].s);
		}
	}
	button_update();
	//right now the file saves every time the select button is pressed
	save_file(phrases, comments, "..\\..\\..\\..\\KeyboardInterface\\phrases.txt");
}

#ifdef OUR_ARDUINO
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
#endif

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
	
	//read in phrases file
	while (getline(ifs, line)) {
		cout << line << endl;
		//new category
		if (line[0] == '#') {
			comments.push_back(line);
		}
		else if (line[0] == '\t') {
			//remove initial tab character
			size_t space = line.find_first_of(" ");
			string s = line.substr(space).erase(0, 1);
			int c = atoi(line.substr(0, space).c_str());
			phrases[cat].push_back(Phrase(s, c));
		}
		else {
			++cat;
			phrases.push_back(vector<Phrase>());
			phrases[cat].push_back(Phrase(line, 0));
		}
	}


	for (int i = 0; i < phrases.size(); ++i) {
		while (phrases[i].size() < 5) {
			//GUI crashes when I set to empty string, really priority so it stays down
			phrases[i].push_back(Phrase("empty", -1000000));
		}
	}

	for (int i = 0; i < phrases.size(); ++i) {
		sort(phrases[i].begin() + 1, phrases[i].end());
	}

	//if you don't want to deal with newlines, just comment out this line and rebuild
	newlines(phrases);

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

