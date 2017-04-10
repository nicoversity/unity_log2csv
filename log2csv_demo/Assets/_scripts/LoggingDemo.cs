/*
 * LoggingDemo.cs
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

public class LoggingDemo : MonoBehaviour {

	// reference to logging system
	private LoggingSystem logger;


	void Start () {

		// setup reference to logging system
		logger = GameObject.Find ("LoggingSystem").GetComponent<LoggingSystem> ();
		if (logger == null)
			Debug.Log ("[LoggingDemo] Unable to set reference to Logging System.");
	}


	void Update () {

		// user input demo to illustrate application of logging in practice
		//


		// left mouse click
		if(Input.GetMouseButtonDown(0)){
			Debug.Log ("[LoggingDemo] Mouse down = Left at position " + Input.mousePosition.ToString());
			logger.writeAOTOSMMessageWithTimestampToLog ("CLICK", "MOUSE", Input.mousePosition.ToString(), "LEFT_BUTTON", "", "DEMO");
		}

		// press space on keyboard
		if (Input.GetKeyDown (KeyCode.Space)) {
			Debug.Log ("[LoggingDemo] Key down = Space");
			logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");
		}

		// press x on keyboard
		if (Input.GetKeyDown (KeyCode.X)) {
			Debug.Log ("[LoggingDemo] Key down = X");
			logger.writeMessageWithTimestampToLog ("Pressed the x-key on the keyboard.");
		}

		// press c on keyboard
		if (Input.GetKeyDown (KeyCode.C)) {
			Debug.Log ("[LoggingDemo] Key down = C");
			logger.writeMessageToLog ("Pressed the c-key on the keyboard. No record of time.");
		}
	}
}
