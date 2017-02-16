#include "View.h"
#include "MessageType.h"

View::View(const std::string& program_name)
	: window(program_name)
{ }

void View::test()
{
	window.notify(MessageType::option1Text, "It's alive!");
	window.notify(MessageType::option2Text, "And the messages are working");
}

void View::test1(const std::string& new_text)
{
	window.notify(MessageType::option3Text, new_text);
}
