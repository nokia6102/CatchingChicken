using UnityEngine;
using System.Collections;

public class Canon : MonoBehaviour {
	private float BeginTime;
	 
	public float MoveSpeed=1.5f;

	public float SpawnTime = 2 ;
	public GameObject[] ObjList;

	GameObject Scene;
	// Use this for initialization
	void Start () {
		BeginTime=Time.time;
		 

		Scene=GameObject.Find("Scene");
	}
	
	// Update is called once per frame
	void Update () {

		if (Scene.GetComponent<Scene> ().bGameOver == true)  
			return;

		if (Scene.GetComponent<Scene> ().bLeveLcomplete == true)  
						return;

	 						if (Time.time - BeginTime > SpawnTime) {
								int idx = Random.Range (0, ObjList.Length);
								GameObject newObj = Instantiate (ObjList [idx]) as GameObject;
								newObj.transform.position = transform.position;
								newObj.rigidbody2D.AddForce(new Vector2(12,10),ForceMode2D.Impulse);

								BeginTime = Time.time;
								audio.Play ();
						}
				 
	}
}
