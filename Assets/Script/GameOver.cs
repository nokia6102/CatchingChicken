using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void NextBtnShow()
	{
		GameObject.Find("Restart").renderer.enabled =true;
		GameObject.Find("Restart").collider2D.enabled =true;
	}
}
