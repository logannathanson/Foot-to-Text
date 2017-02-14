#include "AppWindow.h"

#include <stdexcept>

struct DataPkg
{
	std::string window_name;
	HWND handle;
};

BOOL CALLBACK find_app(HWND window_handle, LPARAM p)
{
	const size_t max_buffer_length = 64;
	TCHAR buffer[max_buffer_length];

	GetWindowText(window_handle, buffer, max_buffer_length);

	DataPkg &data = *(reinterpret_cast<DataPkg*>(p));

	if (std::string(buffer) == data.window_name)
	{
		data.handle = window_handle;
		return false;
	}

	return true;
}

AppWindow::AppWindow(const std::string& program_name)
{
	auto payload = DataPkg { program_name, nullptr };
	int val = EnumWindows(find_app, reinterpret_cast<LPARAM>(&payload));
	
	if (val || !payload.handle)
		throw std::runtime_error("Could not find application " + program_name + "!");

	window_handle = payload.handle;
}

void AppWindow::notify(MessageType msg, const std::string&)
{
	SendMessage(window_handle, (UINT) msg, (WPARAM) nullptr, (LPARAM) nullptr);
}
