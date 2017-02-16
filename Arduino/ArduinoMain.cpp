#include <iostream>
#include <string>
#include <boost/asio.hpp>

using namespace std;

int main() {

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
			cout << input << endl;
			input = "";
		}
		else {
			input += c;
		}
	}	
	
}
