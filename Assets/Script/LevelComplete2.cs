using UnityEngine;
using System.Collections;

public class LevelComplete2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void NextBtnShow()
	{
		GameObject.Find("NextLevel").renderer.enabled =true;
		GameObject.Find("NextLevel").collider2D.enabled =true;
	}
}
