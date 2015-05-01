using UnityEngine;
using System.Collections;

public class Num : MonoBehaviour {
	public int Count=1;
	public int CurCount=0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float h = Screen.height / 10 * 0.8f;
		guiText.fontSize = (int)h;

		SetNum ();
	}

	public void SetNum()
	{
		guiText.text=CurCount + "/" + Count;
	}
}
