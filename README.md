# GildedRoseAssignment

This project was completed as part of a Technoical Assessment. And provides an implementation of a modified Gilded Rose Kata.

It is Provided as Visual Studio Solution (VS2019) containing 3 projects

* GildedRoseApplication: An application configured for use with .Net Core 2.2
* GildedRoseAssignment: A class library providing the API to solve the problem configued for .Net Core 2.2
* GuildedRoseAssignment_Tests: A Test Project using NUnit 3.11. 

These tests were run by the default test runner provided by VS2019

Usage:

The Application can run with 3 commandline configurations

1) GildedRoseApplication: will run the application using thge file testinput.txt and produce testoutput.txt into the build folder
2) GildedRoseAPplication "inputfile" will run application using a custom input fole as the user procides and write to testoutput.txt in the build folder
3) GildedRoseAPplication "inputfile" "outputfile" will run the application using input and output files at the location the user desires.

For viewing the debug envioronment with VS itself is easiest, this way there is no need to setup the runtimes for .Net Core on your system 
seperately. The command line arguments can be specified As application arguments within the debug tab of the project properties

The test input as specified by the assignment specification can also be viewed with a complee end to end test within GildedRoseAssignement_Tests. 
The test is named Test Name:	Execute_WhenRun_WritesCorrectData and can be found within the DailyStockUpdaterTests class

---- About the API

The project has been designed around SOLID Principles and attempts to maintain as clean a structure as possible. The Main class for the  API, (which is all an external client needs to interact with), is DailyStockUpdater. This provides a single entry point called Execute that runs the whole
process. 

The Process consists of 3 distinct steps Read Data, Perform Updates and Write Data. The classes reponsible for the actual function are injected into
DailyStockUpdater from 2 factorys and the only dependencies are upon the interfaces: IDataReader, IDataWriter and IStockItemTransform. 
DataAcessFactory for stream objects and StockTransformFactory for specific transforms depending on the name of the item. This means that 
DailyStockUpdater, simply has to read a list of StockItems, iterate over requesting an appropriate transform for each and applying it, then
write the data. 

It also makes use of an ErrorLogger static class which currently just writes to the console but provides a source of flexibility to a more
detailed logging system 

As in a real system the data is probably not going to be issolated but rather be part of a full POS database the streameaders/streamwriters 
involved in this test are hidden behind the IDataReader and IDataWriter, maintaining proper SOLID design.

Of particular note, StockItem is the basic datastructure for the system and is maintained as a pure datastructure containing 
[string Name,
int Sellin,
STockQuality quality]

StockQuality wraps a single integer and provides a couple of static methods to test and apply a constraint upon its value when requested
The values of these constraints are provided as static properties that have a defualt value but for flexibility could be configured by a client

The reading and writing of data into StockItems from strings is provided by Extension Methods in Extensions.cs. This keeps StockItem a pure datastructure whilst syntactiaclly allowing these obvious operations to be provided and give a further area of flexibility. The format annd contents of the strings are processed using Regular Expressions. If the Format is wrong the record is noted in the read count and logged as an error but is not added into the list and thus will be ommited from further processing.   

finally the DalyStockUpdater maintains a count for records read and write count for record written. 


