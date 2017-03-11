using UnityEngine;
using System.Collections;
using System;

public class ScreenShotter : MonoBehaviour
{
	public KeyCode screenShotKeyCode = KeyCode.A;
	public string filePath;
	void Update()
	{
		if (Input.GetKeyDown(screenShotKeyCode))
		{
			Application.CaptureScreenshot(string.Format("{0}\\ss_{1}x{2}_{3}.jpg",
				filePath,Screen.width,Screen.height,System.DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds));
		}
	}
}