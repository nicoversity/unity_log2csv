# Unity - Log2CSV

This is a simple logging system implemented for Unity applications. The script is supposed to provide an easy way of logging pretty much anything the user want and write it into a .csv file. 

The repository contains the `LoggingSystem.cs` script itself (written in C#), a `log_demo.csv` file illustrating potential output of a logging session, as well as a folder `log2csv_demo` containing an illustrative Unity project with the logging system setup appropriately incl. simple interaction (see `_scripts/LoggingDemo.cs`) to create log file entries on user interaction.

## Intended usage and Action-Object-Target concept
The `LoggingSystem.cs` script provides some basic functions to write messages into the .csv log file:

* **writeMessageToLog(string message)**: Write a normal message in the first column of the .csv log file.
* 	**writeMessageWithTimestampToLog(string message)**: Write a normal message into the second column of the .csv file, while the first column keeps track of the time in milliseconds since the application's start.
* 	**writeAOTMessageWithTimestampToLog(string act, string obj, string tar)**: Write an Action-Object-Target message into the .csv starting in the second column, while the first column keeps track of the time in milliseconds since the application's start.
* 	**writeAOTOSMMessageWithTimestampToLog(string act, string obj, string tar, string origin, string state, string mode)**: Write an extended Action-Object-Target (Origin-State-Mode) message into the .csv starting in the second column, while the first column keeps track of the time in milliseconds since the application's start.

The *Action-Object-Target* protocol was created (and applied during several studies) to systematically keep track of important events when using an application. The protocol is intended to make the later evaluation of the entries in the log file as convenient and structured as possible. The user can decide how to further process the created .csv file at own demand/desire, e.g. via [R](https://www.r-project.org), [MATLAB](https://www.mathworks.com/products/matlab.html), or simple import to [Google Spreadsheet](https://spreadsheets.google.com/) or [Microsoft Excel](https://products.office.com/en-us/excel).

Overall, following the structure in the `LoggingSystem.cs` script, the script can easily be extended or adopted to custom user cases (as e.g. shown in the `writeAOTOSMMessageWithTimestampToLog` function).

## Notes and compability
* The script is setup to use `;` as a .csv seperator.
* Compatible (tested) operating systems: Windows, OS X, Android, iOS
* Log file folder location via OS:
  * **OS X / Windows**: On desktop environments, the log file folder is created as a subfolder of the Unity project folder or exported executable.
  * **Android**: 
  * **iOS**: Xcode (8.3) -> Window -> Devices -> Select connected iOS device -> Select application from Installed Apps -> Download Container -> Show Package Contents  

## Dependencies
This example has been built using the following specifications:

* OS X 10.12.4
* [Unity](https://unity3d.com) 5.4.1f1 (OS X release)

*Note:* Generally, Unity source code should work also within their Windows counterparts. Please check out the above stated dependencies for troubleshooting.

## Setup instructions
### Unity 
1. Create a new `Empty GameObject` (e.g. called *LoggingSystem*), and attach the `LoggingSystem.cs` script as a component. There is only one instance needed.
2. In your scripts, where you want to create a new log file entry, establish a reference to the `LoggingSystem.cs` component of the `GameObject` as created in step 1, and start using the logger.

*Note:* The `_scripts/LoggingDemo.cs` script, and `_scenes/log2csv_demo.unity` scene provide the basic setup of the logging system in practice.

## License
MIT License, see [LICENSE.md](LICENSE.md)
