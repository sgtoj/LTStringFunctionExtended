#LTStringFunctionExtended

This is a simple plugin that provides additional common string functions for LabTech's scripting engine. 

#How to Use

###Base64 Functions
Encode a string to and from base64. Based64 encoding is a common way to excape a string so it can be passed between scripts, programs, etc.

![ToBase64 Example](./images/ExampleToBase64.png?raw=true)
 
###String Length
Trims the whitespaces and returns the length the of a string.

![StringLength Example](./images/ExampleStringLength.png?raw=true)


#Importing the Plugin
1. Download the [Plugin](./LTStringFunctionExtended/bin/Release/LTStringFunctionExtended.dll?raw=true) (ie DLL)
1. Control Center > Tools > Plugin > Import Plugin
2. Navigate to and select the `LTStringFunctionExtended.dll` file.
3. Bounce the DBAgent service on the server.
3. Restart the Control Center.
