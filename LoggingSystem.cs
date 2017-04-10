/*
 * LoggingSystem.cs
 *
 * Project: Log2CSV - Simple Logging System for Unity applications
 *
 * Supported Unity version: 5.4.1f1 Personal (tested)
 *
 * Author: Nico Reski
 * Web: http://reski.nicoversity.com
 * Twitter: @nicoversity
 */

using UnityEngine;
using System.Collections;
using System.IO;

public class LoggingSystem : MonoBehaviour {

	#region FIELDS

	// static log file names and formatters
	private static string LOGFILE_DIRECTORY = "log2csv_logfiles";
	private static string LOGFILE_NAME_BASE = "_log_file.csv";
	private static string LOGFILE_NAME_TIME_FORMAT = "yyyy-MM-dd_HH-mm-ss";	// prefix of the logfile, created when application starts (year - month - day - hour - minute - second)

	// logfile reference of the current session
	private string logFile;

	// bool representing whether the logging system should be used or not (set in the Unity Inspector)
	public bool activeLogging;

	#endregion



	#region START_UPDATE

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {

		if(this.activeLogging)
		{
			// check if directory exists (and create it if not)
			if(!Directory.Exists(LOGFILE_DIRECTORY)) Directory.CreateDirectory(LOGFILE_DIRECTORY);

			// create file for this session using time prefix based on standard UTC time
			this.logFile = LOGFILE_DIRECTORY
				+ "/"
				+ System.DateTime.UtcNow.ToString(LOGFILE_NAME_TIME_FORMAT)
				//+ System.DateTime.UtcNow.AddHours(2.0).ToString(LOGFILE_NAME_TIME_FORMAT)	// manually adjust time zone, e.g. + 2 UTC hours for summer time in location Stockholm/Sweden
				+ LOGFILE_NAME_BASE;
			File.Create(this.logFile);

			if(File.Exists(this.logFile)) Debug.Log("[LoggingSystem] LogFile created at " + this.logFile);
			else Debug.LogError("[LoggingSystem] Error creating LogFile");
		}
	}

	#endregion



	#region WRITE_TO_LOG

	/// <summary>
	/// Writes the message to the log file on disk.
	/// </summary>
	/// <param name="message">string representing the message to be written.</param>
	public void writeMessageToLog(string message)
	{
		if(this.activeLogging)
		{
			if(File.Exists(this.logFile))
			{
				TextWriter tw = new StreamWriter(this.logFile, true);
				tw.WriteLine(message);
				tw.Close(); 
			}
		}
	}

	/// <summary>
	/// Writes the message including timestamp to the log file on disk.
	/// </summary>
	/// <param name="message">string representing the message to be written.</param>
	public void writeMessageWithTimestampToLog(string message)
	{
		writeMessageToLog(Time.realtimeSinceStartup.ToString() + ";" + message);
	}


	/// <summary>
	/// Writes an Action-Object-Target message including timestamp to the log file on disk.
	/// </summary>
	/// <param name="act">string representing the ACTION message.</param>
	/// <param name="obj">string representing the OBJECT message.</param>
	/// <param name="tar">string representing the TARGET message.</param>
	public void writeAOTMessageWithTimestampToLog(string act, string obj, string tar)
	{
		writeMessageToLog(Time.realtimeSinceStartup.ToString() + ";" + act + ";" + obj + ";" + tar);
	}
		

	/// <summary>
	/// Writes the Action-Object-Target-Origin-State message with timestamp to log.
	/// </summary>
	/// <param name="act">string representing the ACTION message.</param>
	/// <param name="obj">string representing the OBJECT message.</param>
	/// <param name="tar">string representing the TARGET message.</param>
	/// <param name="origin">string representing the ORIGIN message.</param>
	/// <param name="state">string representing the STATE message.</param>
	/// <param name="state">string representing the MODE message.</param>
	public void writeAOTOSMMessageWithTimestampToLog(string act, string obj, string tar, string origin, string state, string mode)
	{
		writeMessageToLog(Time.realtimeSinceStartup.ToString() + ";" + act + ";" + obj + ";" + tar + ";" + origin + ";" + state + ";" + mode);
	}

	#endregion
}