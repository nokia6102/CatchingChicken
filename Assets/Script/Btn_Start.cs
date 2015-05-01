using UnityEngine;
using System.Collections;

public class Btn_Start : MonoBehaviour {
	public Sprite BtnUp;
	public Sprite BtnDown;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp()
	{
		GetComponent<SpriteRenderer> ().sprite = BtnUp;
	
		PlayerPrefs.SetInt ("TotalScore", 0);
		PlayerPrefs.SetInt ("LevelNum", 1);

		Application.LoadLevel ("Level01");
	}

	void OnMouseDown()
	{
		GetComponent<SpriteRenderer> ().sprite = BtnDown;
	}

}
