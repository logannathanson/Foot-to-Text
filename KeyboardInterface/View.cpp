#include "View.h"
#include "MessageType.h"

View::View(const std::string& program_name)
	: window(program_name)
{ }

void View::test()
{
	window.notify(MessageType::Test0, "It's alive!");
}
