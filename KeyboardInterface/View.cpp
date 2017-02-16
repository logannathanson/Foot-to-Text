#include "View.h"
#include "MessageType.h"

#include <cassert>

View::View(const std::string& program_name)
	: window(program_name)
{ }

void View::set_button(int which, const std::string& text)
{
	assert(which > 0);
	window.notify(static_cast<MessageType>((int) MessageType::option1Text + (which - 1)), text);
}
