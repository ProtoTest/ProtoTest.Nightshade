# Nightshade - Eggplant Test Runner
=============================
## Overview

Nightshade is a test runner written in C#.  It's built to execute and validate scripts and commands written in TestPlant's Eggplant.  It's primary purpose is to execute a large suite of eggplant scripts that run over the course of many days.  Currently, the Eggplant GUI will run out of memory after 40 hours of execution, and a 100 hour run was needed.  

## Installation and execution instructions
- You must be on a Windows PC, with 8GB or more of RAM.
- Download and install GallioBundle-3.4.xx.msi from https://code.google.com/p/mb-unit/downloads/list
- Download and install TestPlant's Eggplant.  http://www.testplant.com/support/downloads/current/ 
- Download and Install .Net 4.0 if it's not already installed.
- Connect the device(s) via USB to your computer, and install the drivers as detailed in the section below.  
- Verify the device has VMLite VNC Server for Android installed.  If necessary, download and install from google play.  
- Install the Android controller to your PC : http://www.vmlite.com/vaac/.  Start the "VMLite Android App Controller" program, and click USB Connect to start the VMLite VNC Server on the device.  Verify the app says the server is running.
- On the PC, Install Github GUI.  Go to http://www.github.com/ and Click "download github for windows".
- Download the Nightshade framework from http://www.github.com/prototest/Nightshade.  Click the "Clone on desktop" to download all source to the default github folder.
- Edit the Nightshade config file ProtoTest.Nightshade\bin\Release\TestConfig.xml and verify all path settings are correct. 
- Edit the config file to reflect which scripts need to be run on which devices. A description of all the config file entries is at the bottom of this page.  
- Launch Gallio - Icarus GUI Test Runner, click "Add" and select the framework dll :  ProtoTest.Nightshade\bin\Release\ProtoTest.Nightshade.dll.  You should see a test show up called "RunTestsFromConfigFile"
- Launch Eggplant GUI, and verify you can connect to the device(s) you will be testing with.  For best results, connect via USB device name, not IP address.
- Close Eggplant GUI, as it will prevent eggplant drive from launching.  
- Click "Start" in Gallio Icarus.  A command prompt will be launched to start eggplant drive, and tests should start to get executed against the devices.  Once a test is finished, the GUI should update to show the pass/fail state of each test.  Additionally, a log of all commands should display in the runtime log.  
- If a test fails, it should include a screenshot and reason why.  
- Export the report as HTML by clicking Report -> View As -> HTML.  

##Driver Installation:
- Download and Install Motorola Drivers from https://motorola-global-portal.custhelp.com/app/answers/detail/a_id/88481
- Go to Device Manager
- Right-Click on unknown Android device
- Update Driver Software
- Choose Browse my computer for driver software
- Choose Let me pick from a list of device drivers on my computer
- Choose ADB Interface
- Select Motorola and then Choose Mot Composite ADB Interface
- Take Custom ADB Files for Shelter and replace in eggPlant / eggPlant.app / Resources folder
- Change VMLite Android App controller ADB location to new eggplant ADB file
- Start VMLite Android App Controller / VMLite VNC Server


## Config File : 

## Technical information

- Nightshade is built using MbUnit 3.4, and is designed to be executed using a GUI called Gallio Icarus 3.4.  MbUnit.dll is included in the Gallio 3.4 bundle which can be downloaded from http://www.gallio.org.  The Nightshade runner works just like a unit test.  The C# code is built into a .dll (library) file.  The tests can be executed using Galio Icarus (GUI) or Echo (Command).  Using a unit testing framework like MbUnit means that all of the functionality is already built, we just have to execute it in the right way.  For instance, the report is formatted by Gallio, all we have to do is write to it. 
- Nightshade uses an XML config file to specify all run-time values, such as which scripts to execute, the path to the suite, test timeouts, etc.  
- Nightshade uses MbUnit's DynamicTestFactory attribute to generate tests at run-time.  The DynamicTestFactory is a function that builds tests dynamically.  Normally with a unit testing framework you have to define one function per test case.  With the Factory, we can build one function, have it parse the XML file, and build the tests dynamically.  This lets us define which tests we want to run without having to recompile.  In addition, each Test can have multiple actions assosicated with it, and the test case will automatically keep track of how many of those actions ran, and how many passed or failed.  
- Nightshade executes Eggplant commands using Eggplant Drive.  Once eggplant is installed on a computer, you can start drive via a command prompt.  Drive exposes an XmlRpc service that allows us to tell it what commands to execute.  You can call the service from a client and tell it to execute a variety of commands.  Nightshade basically sends XmlRpc commands to that service to tell it to run a specific script against a specific host.  Full details of eggplant drive can be found here : http://docs.testplant.com/?q=content/eggplant-drive
- Eggplant Drive is started using a batch file included with the Suite.  If eggplant is not installed to the default directory, that batch file needs to be updated with the correct path. 

## Code overview
There are 5 .cs files.  Each should be commented with more details.
- Common.cs - Stores global and shared methods.  
- EggplantDriver.cs - This class starts eggplant drive, and execute commands against it.  
- EggplantDynamicTestFactory.cs - This class looks in the config file and builds tests. 
- EggplantScript.cs - This class contains all information about how to execute an eggplant script and how to validate it passed.  
- IEggplantDriveService.cs - This is the XmlRpc service.  Most of the functionality is handled by the underlying XmlRpc library.

	

	








