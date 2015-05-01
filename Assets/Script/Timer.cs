using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	int TimerCount=50;
	int StartTime;
	GameObject Scene;

	bool bStop=false;

	// Use this for initialization
	void Start () {
		guiText.fontSize = (int)(Screen.height / 15 * 0.8f);

		StartTime = (int)Time.time;
		Scene = GameObject.Find ("Scene");

	}
	
	// Update is called once per frame
	void Update () {
		if (Scene.GetComponent<Scene> ().bLeveLcomplete)
			return;

		if (bStop)
			return;

		int period = (int)Time.time - StartTime;
		int t = TimerCount - period;
		if (t <= 0)
		    t = 0;

		if (t==0)
		{
			GameObject.Find ("GameOver").animation.Play();
			Scene.GetComponent<Scene>().bGameOver=true;
			bStop=true;
		}
		SetTime (t);

	}

	void SetTime(int t)
	{
		int Min = t / 60;
		int Sec = t % 60;
		guiText.text = "Time " + Min.ToString ("00") + ":" + Sec.ToString ("00");
	}


}
