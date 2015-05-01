using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {
	public int LevelNum=1;
	// Use this for initialization
	void Start () {
		guiText.fontSize = (int)(Screen.height / 15 * 0.8f);
		LevelNum = PlayerPrefs.GetInt ("LevelNum");
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = "Level " + LevelNum;
	}
}
