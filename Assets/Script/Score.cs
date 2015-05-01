using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	public int TotalScore = 0;

	// Use this for initialization
	void Start () {
		guiText.fontSize = Screen.height / 10;
		TotalScore = PlayerPrefs.GetInt ("TotalScore");
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = "Score: " + TotalScore;
	}
}
