using UnityEngine;
using System.Collections;

public class Bucketbottom : MonoBehaviour {
	Score score;
	GameObject Icon0,Icon1,Num0,Num1;
	GameObject Icon2,Num2;

	GameObject Boom;

	public Sprite[] SpriteList;
	public GameObject Point;

	int LifePoint=100;
	GameObject LifeBar;


	// Use this for initialization
	void Start () {
		score = GameObject.Find ("Score").GetComponent<Score> ();

		Icon0 = GameObject.Find ("Icon0");
		Icon1 = GameObject.Find ("Icon1");

		Icon2 = GameObject.Find ("Icon2");
		//--

		Num0  = GameObject.Find ("Num0");
		Num1  = GameObject.Find ("Num1");

		Num2  = GameObject.Find ("Num2");

		Boom = GameObject.Find ("Boom");

		LifeBar = GameObject.Find ("LifeBar");

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider)
	{

		if (GameObject.Find ("Scene").GetComponent<Scene> ().bGameOver) 
		{Destroy(collider.gameObject);
						return;
				}

		int idx2 = collider.gameObject.name.IndexOf ("Bomb");

		if (idx2 != -1) {
			Destroy(collider.gameObject);
			Vector3 p=GameObject.Find("Player").transform.position;
			Vector3 p2=Boom.transform.position;
			p2.x=p.x;
			Boom.transform.position=p2;
			Boom.renderer.enabled=true;
			Boom.animation.Play();
			Boom.audio.Play();
			LifePoint-=20;
			LifeBar.transform.localScale = new Vector3((float)LifePoint/100, LifeBar.transform.localScale.y, LifeBar.transform.localScale.z);


			if (LifePoint<=0)
			{
			GameObject.Find ("GameOver").animation.Play();
			GameObject.Find("Scene").GetComponent<Scene>().bGameOver=true;
			p.z=-20;
			GameObject.Find("Player").transform.position=p;			
			}
			return;
		}

		if (collider.gameObject.name.Contains("Mcase"))
		{
			print ("X" + collider.gameObject.name.Contains("Mcase"));
			print ("M " +collider.gameObject.name);
			LifePoint=100;
			LifeBar.transform.localScale = new Vector3((float)LifePoint/100, LifeBar.transform.localScale.y, LifeBar.transform.localScale.z);
			GameObject.Destroy(collider.gameObject);
			return;
		}


		int value = collider.gameObject.GetComponent<FruitValue>().Value;

	//	if (value!=0)
	    //{
		score.TotalScore += value;

		int th, ten, one;
		th = value / 100;
		ten = value % 100 / 10;
		one = value % 100 % 10;

		GameObject obj =Instantiate (Point) as GameObject;

		GameObject child = obj.transform.FindChild ("digital_2").gameObject;
		child.GetComponent<SpriteRenderer> ().sprite = SpriteList [th];
		child.animation.Play ();

		child = obj.transform.FindChild ("digital_1").gameObject;
		child.GetComponent<SpriteRenderer> ().sprite = SpriteList [ten];
		child.animation.Play ();

		child = obj.transform.FindChild ("digital_0").gameObject;
		child.GetComponent<SpriteRenderer> ().sprite = SpriteList [one];
		child.animation.Play ();


		Vector3 pos = transform.position;
		pos.y += 2.0f;
		obj.transform.position = pos;
		obj.animation.Play ();

		int idx = collider.gameObject.name.IndexOf (Icon0.guiTexture.texture.name);
		if (idx != -1) {
			Num0.GetComponent<Num>().CurCount+=1;
		
			if (Num0.GetComponent<Num>().CurCount>=Num0.GetComponent<Num>().Count)
				Num0.GetComponent<Num>().CurCount=Num0.GetComponent<Num>().Count;
			Num0.GetComponent<Num>().SetNum();
				}

		    idx = collider.gameObject.name.IndexOf (Icon1.guiTexture.texture.name);
		if (idx != -1) {
			Num1.GetComponent<Num>().CurCount+=1;
			if (Num1.GetComponent<Num>().CurCount>=Num1.GetComponent<Num>().Count)
				Num1.GetComponent<Num>().CurCount=Num1.GetComponent<Num>().Count;
			Num1.GetComponent<Num>().SetNum();
		}

		idx = collider.gameObject.name.IndexOf (Icon2.guiTexture.texture.name);
		if (idx != -1) {
			Num2.GetComponent<Num>().CurCount+=1;
			if (Num2.GetComponent<Num>().CurCount>=Num2.GetComponent<Num>().Count)
				Num2.GetComponent<Num>().CurCount=Num2.GetComponent<Num>().Count;
			Num2.GetComponent<Num>().SetNum();
		}

		//}

		Destroy(collider.gameObject);
		audio.Play ();

		if ((Num0.GetComponent<Num> ().CurCount == Num0.GetComponent<Num> ().Count) &&
						(Num1.GetComponent<Num> ().CurCount == Num1.GetComponent<Num> ().Count) &&
						(Num2.GetComponent<Num> ().CurCount == Num2.GetComponent<Num> ().Count)) 
		        {


			//GameObject.Find("LevelComplete").rigidbody2D.isKinematic=false;
			//GameObject.Find("Box").collider2D.enabled=true;
			GameObject.Find("LevelComplete2").animation.Play();
			GameObject.Find("Scene").GetComponent<Scene>().bLeveLcomplete =true;

			PlayerPrefs.SetInt("TotalScore", score.TotalScore);
		//	GameObject.Find("LevelComplete").renderer.enabled =true;
		//	GameObject.Find("LevelComplete").collider2D.enabled =true;

				}
	}
}
