//S.T.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
	//分
	private int minute=0;
	private float seconds=0.0f;
	//　タイマー表示用のテキスト
	public Text time_text;

	void Update()
	{
		seconds += Time.deltaTime;
		if (seconds >= 60f)
		{
			minute++;
			seconds = seconds - 60;
		}
		time_text.text = minute.ToString() + ":" + ((int)seconds).ToString("00");
	}

	public int GetMinute() { return minute; }
}
