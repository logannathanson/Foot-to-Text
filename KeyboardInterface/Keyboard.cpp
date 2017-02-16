#include "Keyboard.h"

#include <stdexcept>

Keyboard& Keyboard::get_instance()
{
    static Keyboard instance;
    return instance;
}

void Keyboard::send_word(const std::string& word)
{
    for (char c : word)
    {
        send_char(c);
    }
}

Keyboard::Keyboard()
{
    input.type = INPUT_KEYBOARD;
    input.ki.wScan = 0;
    input.ki.time = 0;
    input.ki.dwExtraInfo = 0;

    layout = GetKeyboardLayout(0); // Locale of current thread
}

void Keyboard::send_char(char c)
{
    auto vk_package = get_virtual_key(c);
    auto virtual_key = vk_package & 0xFF;
    
    auto mod_guard = ModifierGuard(vk_package);

    send_key_down(static_cast<WORD>(virtual_key));
    send_key_up(static_cast<WORD>(virtual_key));
}

void Keyboard::send_key_down(WORD virtual_key)
{
    input.ki.wVk = virtual_key;
    input.ki.dwFlags = 0; // 0 for key press
    SendInput(1, &input, sizeof(INPUT));
}

void Keyboard::send_key_up(WORD virtual_key)
{
    input.ki.wVk = virtual_key;
    input.ki.dwFlags = KEYEVENTF_KEYUP; // KEYEVENTF_KEYUP for key release
    SendInput(1, &input, sizeof(INPUT));
}

SHORT Keyboard::get_virtual_key(char c)
{
    SHORT vk_package = VkKeyScanEx(c, layout);
    if ((char)(vk_package & 0x00FF) == -1 && (char)(vk_package & 0xFF00) == -1)
    {
        throw std::runtime_error("Don't have virtual key for char " + std::to_string(c));
    }
    
    return vk_package;
}

Keyboard::ModifierGuard::ModifierGuard(SHORT vk_package)
    : is_shift((vk_package & 0x100) != 0),
    is_ctrl((vk_package & 0x200) != 0),
    is_alt((vk_package & 0x400) != 0)
{
    if (is_shift) Keyboard::get_instance().send_key_down(VK_SHIFT);
    if (is_ctrl) Keyboard::get_instance().send_key_down(VK_CONTROL);
    if (is_alt) Keyboard::get_instance().send_key_down(VK_MENU);
}

Keyboard::ModifierGuard::~ModifierGuard()
{
    if (is_shift) Keyboard::get_instance().send_key_up(VK_SHIFT);
    if (is_ctrl) Keyboard::get_instance().send_key_up(VK_CONTROL);
    if (is_alt) Keyboard::get_instance().send_key_up(VK_MENU);
}
