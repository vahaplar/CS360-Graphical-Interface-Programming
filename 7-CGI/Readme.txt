There are differences between Windows and Linux for the directory options for your web pages and runnable (CGI) programs.
On Windows, the public_html directory contains your web pages (html files), CSS files, Javascript files and your cgi-bin directory. On Linux the directory /var/www/html/ has ONLY html, CSS & Javascript files. The cgi-bin directory contains only runnable programs and is inside the /var/www/ directory
This assignment has 3 parts: creating the webpage, setting up the server and creating the cgi program. All instructions are based on a Linux server on the TJW system.
1.	Create a webpage named index.html, in your /var/www/html/ directory, using HTML, CSS styles and text to display a form with the following:
a.	2 input fields with red text comments that ask for numbers
b.	A submit button which will send the 2 numbers to your TJWnnn account. 
2.	Set up the server:
a.	Create a directory called cgi-bin. Inside the /var/www/ directory. 
b.	Modify the /etc/httpd/conf/httpd.conf file to allow access to your cgi-bin directory
c.	Start the apache server with:
apachectl	start
d.	You can now test the page before you build the cgi program.
3.	Create a CGI program on the TJW system, written in C or C++, compile it and store the executable in your TJW cgi-bin directory. The CGI program will multiply the 2 numbers and return a webpage with the answer.
EVERY time you change the httpd.conf file, you MUST restart Apache using: 
apachectl 	restart
We are using the default Apache configuration file (found in /etc/httpd/conf/httpd.conf) so you need to set the following values (search for them in the httpd.conf file). Lines beginning with a # are comments
# notice there is NO equal sign on EITHER line below. Be sure to replace nnn with YOUR TJW number
ServerName    tjwnnn.cc.binghamton.edu
Listen   tjwnnn.cc.binghamton.edu:80

#the line below should ALREADY be in the file. If it is not, fix it to look like this one:
ScriptAlias    /cgi-bin/     “/var/www/cgi-bin/”
Also, move your cgi-bin directory INTO /var/www/ and your executable program goes INSIDE /cgi-bin/
NOTE: when you compile, the output of g++ or gcc will be a file named “a.out”, so you can either:
1.	Use a.out as the object of the action=- option in your html page
2.	Use the Linux command: mv   a.out    mypgm        to rename a.out to mypgm or whatever you want to use in your action= option
Don’t forget to do this again if you recompile!!!!
When using method=post, you must READ (cin or scanf) a string containing the name=value pairs of data. This is the PREFERRED method. You will get a string that looks like: name1=value1&name2=value2 etc. BE CAREFUL of the names of your input fields if you want to use printf to debug. If a field name “looks” like an html tag, that is what you will see if you printf the string using printf, although your cgi program will see the actual string That’s because fieldnames will have an “&” in front of them.
To test your page & program, open a browser and go to http://tjwnnn.cc.binghamton.edu  (where nnn is your TJW #.)
 
 

