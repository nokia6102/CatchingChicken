using UnityEngine;
using System.Collections;

public class Spawer : MonoBehaviour {
	private float BeginTime;
	float Distance;
	public float MoveSpeed=1.5f;

	public float SpawnTime = 2 ;
	public GameObject[] ObjList;

	GameObject Scene;
	// Use this for initialization
	void Start () {
		BeginTime=Time.time;
		Distance = Camera.main.orthographicSize * Camera.main.aspect * 2 * 0.9f;

		Scene=GameObject.Find("Scene");
	}
	
	// Update is called once per frame
	void Update () {

		if (Scene.GetComponent<Scene> ().bGameOver == true)  
			return;

		if (Scene.GetComponent<Scene> ().bLeveLcomplete == true)  
						return;

						float newXPos = Mathf.PingPong (Time.time * MoveSpeed, Distance) - (Distance / 2);
						transform.position = new Vector3 (newXPos, transform.position.y, transform.position.z);

						if (Time.time - BeginTime > SpawnTime) {
								int idx = Random.Range (0, ObjList.Length);
								GameObject newObj = Instantiate (ObjList [idx]) as GameObject;
								newObj.transform.position = transform.position;

								BeginTime = Time.time;
								audio.Play ();
						}
				 
	}
}
