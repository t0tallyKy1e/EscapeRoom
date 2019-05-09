using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	public string completionText;
	public Text textField;
	private bool isFinished; 
	private float currentTime;

	// time solution found here: https://answers.unity.com/questions/1476208/string-format-to-show-float-as-time.html
	string FormatTime(float time) {
		int minutes = (int) time / 60 ;
		int seconds = (int) time - 60 * minutes;
		int milliseconds = (int) (1000 * (time - minutes * 60 - seconds));

		return string.Format("{0:00}:{1:00}.{2:000}", minutes, seconds, milliseconds);
	}

	void Start () {
		currentTime = 0.0f;
		isFinished = false;
	}

	// display time when stopped
	public void Stop() {
		isFinished = true;

		textField.text = completionText + FormatTime(currentTime) + "!";
	}
	
	void Update () {
		if(!isFinished) {
			currentTime += Time.deltaTime;
		}
	}
}
