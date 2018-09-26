#include <iostream>
#include <string>
#include <cstdlib>
#include <cstdio>

using namespace std;

main() {
	char *s = getenv("QUERY_STRING");
	
	cout << "Content-Type: text/html\r\n\r\n";
	cout << "<!DOCTYPE HTML>";
	cout << "<html>";
	cout << "<body>";
	cout << "<hl style='color:red;'>The result is:</hl>";
	cout << "<hl>";
	int nl,n2;
	sscanf(s,"n1=%d&n2=%d",&nl,&n2);
	int multiply = nl*n2;
	cout << multiply;
	cout << "</hl>";
	cout << "</body>";
	cout << "</html>";
}