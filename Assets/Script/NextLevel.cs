using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {
	public Sprite BtnDown;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		int i = PlayerPrefs.GetInt ("LevelNum");
		i++;
		PlayerPrefs.SetInt ("LevelNum", i);

		Application.LoadLevel ("Level01");	

	}
}
