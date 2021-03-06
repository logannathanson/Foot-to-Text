#pragma once

#define WINVER 0x0500
#include <windows.h>
#include <WinUser.h>

#include <string>

struct ModifierPkg
{
	bool ctrl = false;
	bool shift = false;
	bool alt = false;
};

class Keyboard
{
public:
	struct Key
	{
		Key(const std::string& key_str);
		friend class Keyboard;

	private:
		SHORT virtual_key;
	};

	static Keyboard& get_instance();

	void send_word(const std::string& word);

	void send_shortcut(ModifierPkg mods, Key key);

private:
	Keyboard();

	void send_char(char c);
	void send_newline();
	
    void send_key_down(WORD virtual_key);
	
    void send_key_up(WORD virtual_key);

	SHORT get_virtual_key(char c);

	class ModifierGuard
	{
	public:
		ModifierGuard(SHORT vk_package);
		ModifierGuard(ModifierPkg mods);
		~ModifierGuard();

	private:
		void set_entry_state();

		bool is_shift = false;
		bool is_ctrl = false;
		bool is_alt = false;
	};

	INPUT input;
};
