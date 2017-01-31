#pragma once

#define WINVER 0x0500
#include <windows.h>
#include <WinUser.h>

#include <string>

class Keyboard
{
public:
	static Keyboard& get_instance();

	void send_word(const std::string& word);

private:
	Keyboard();

	void send_char(char c);
	
    void send_key_down(WORD virtual_key);
	
    void send_key_up(WORD virtual_key);

	SHORT get_virtual_key(char c);

	class ModifierGuard
	{
	public:
		ModifierGuard(SHORT vk_package);
		~ModifierGuard();

	private:
		bool is_shift = false;
		bool is_ctrl = false;
		bool is_alt = false;
	};

	INPUT input;
	HKL layout;
};
