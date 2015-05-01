using UnityEngine;
using System.Collections;

public class Scene : MonoBehaviour {
	public bool bLeveLcomplete=false;
	public bool bGameOver=false;
	public Texture[] TexList;
	public GameObject[] BGList;

	public GameObject[] pieceList;
	public int PeceOneTime=8;
	float Distance;

	float BeginTime;
	public float SpwanTime=0.5f;


	// Use this for initialization
	void Start () {

		int idxgb = Random.Range (0, BGList.Length);
		GameObject newObj = Instantiate (BGList [idxgb]) as GameObject;

		int idx = Random.Range (0, TexList.Length);
		GameObject.Find ("Icon0").guiTexture.texture = TexList [idx];
		
		int idx1 = Random.Range (0, TexList.Length);		
		while (idx1== idx) 
		{  
			idx1 = Random.Range (0, TexList.Length);
		}
		GameObject.Find ("Icon1").guiTexture.texture = TexList [idx1];


		//第3種水果
		int idx2 = Random.Range (0, TexList.Length);		
		while (idx2== idx || idx2== idx1 ) 
		{  
			idx2 = Random.Range (0, TexList.Length);
		}
		GameObject.Find ("Icon2").guiTexture.texture = TexList [idx2];




		#region 有時一樣有時二樣
		int n=Random.Range(1,2);

		GameObject.Find ("Num0").GetComponent<Num>().Count=n;

		int FieldCount=Random.Range(1,4);
	 	print ("FieldCount: "+ FieldCount);
		if (FieldCount==3)
		{
			n=Random.Range(1,2);
			GameObject.Find("Num1").GetComponent<Num>().Count=n;
			n=Random.Range(1,2);
			GameObject.Find("Num2").GetComponent<Num>().Count=n;
		}
	    else if (FieldCount==2)
		{
			n=Random.Range(1,2);
			GameObject.Find("Num1").GetComponent<Num>().Count=n;

			GameObject.Find("Num2").GetComponent<Num>().Count=0;
			GameObject.Find("Icon2").guiTexture.enabled=false;
			GameObject.Find("Num2").guiText.enabled=false;
		}
		else
		{
			GameObject.Find("Num1").GetComponent<Num>().Count=0;
			GameObject.Find("Icon1").guiTexture.enabled=false;
			GameObject.Find("Num1").guiText.enabled=false;

			GameObject.Find("Num2").GetComponent<Num>().Count=0;
			GameObject.Find("Icon2").guiTexture.enabled=false;
			GameObject.Find("Num2").guiText.enabled=false;

		}
		#endregion

	
		BeginTime = Time.time;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape))
			Application.Quit ();

		if (bLeveLcomplete && Time.time - BeginTime > SpwanTime) {
						Distance = Camera.main.orthographicSize * Camera.main.aspect;
						for (int i=0; i<PeceOneTime; i++) {
								int idx = Random.Range (0, pieceList.Length);
								GameObject newObj2 = Instantiate (pieceList [idx]) as GameObject;
								float Newx = Random.Range (-Distance, Distance);
								float YOffest =Random.Range (-1.5f,1.5f);
								newObj2.transform.position = new Vector3 (Newx, newObj2.transform.position.y+YOffest, newObj2.transform.position.z);				
						}
				BeginTime=Time.time;
				}

	}


}
