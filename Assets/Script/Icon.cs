using UnityEngine;
using System.Collections;

public class Icon : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float h = Screen.height / 10 * 0.8f;
		guiTexture.pixelInset = new Rect (-h / 2, -h / 2, h, h);
	}
}
