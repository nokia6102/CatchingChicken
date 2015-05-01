using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	private Vector3 StartPos,EndPos;
	private bool bMouseDown=false;
	private GameObject bucket;
	private bool bRight=true;
	Animator anim;
	public bool bUseAccerlation=true;
	public bool bUseTouch=true;

	// Use this for initialization
	void Start () {
		bucket = GameObject.Find ("woodbucket");
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (bUseTouch) {
						if (Input.GetMouseButtonDown (0)) {
								StartPos = Input.mousePosition;
								bMouseDown = true;
							
								bUseAccerlation=false;
						}

						if (Input.GetMouseButtonUp (0)) {
								bMouseDown = false;
								bUseAccerlation=true;
						}
	
						anim.SetBool ("bRun", false);
						if (bMouseDown) {
								EndPos = Input.mousePosition;
								DetectGuesture ();
						}
						Vector3 scale = transform.localScale;
						if ((bRight && transform.localScale.x < 0) || (!bRight && transform.localScale.x > 0)) {  
								scale.x *= -1.0f;
								transform.localScale = scale;
						}
						else
						{
							if (bUseAccerlation) {
								anim.SetBool ("bRun", false);
								float dir = Input.acceleration.x;
								dir = dir * Time.deltaTime;
								float MoveSpeed = 40;
								float len = dir * MoveSpeed;
								
								
								Vector3 p3 = new Vector3 (transform.position.x + len, transform.position.y, transform.position.z);
								
								float w = Camera.main.orthographicSize * Camera.main.aspect - bucket.renderer.bounds.size.x / 2;
								p3.x = Mathf.Max (p3.x, -w);
								p3.x = Mathf.Min (p3.x, w);
								transform.position = p3;
								
								StartPos = EndPos;
								
								if (Mathf.Abs (len) > 0.01f) {
									if (dir > 0)
										bRight = true;
									if (dir < 0)
										bRight = false;
									anim.SetBool ("bRun", true);
								}
								
							//	Vector3 scale = transform.localScale;
								if ((bRight && transform.localScale.x < 0) || (!bRight && transform.localScale.x > 0)) {  
									scale.x *= -1.0f;
									transform.localScale = scale;
								}
							}
						}
		}
			
	}

	void DetectGuesture()
	{
		Vector3 p1 = Camera.main.ScreenToWorldPoint (StartPos);
		Vector3 p2 = Camera.main.ScreenToWorldPoint (EndPos);
		float len = (p2.x - p1.x)*2;
		Vector3 p3 = new Vector3 (transform.position.x + len, transform.position.y, transform.position.z);

		float w = Camera.main.orthographicSize * Camera.main.aspect - bucket.renderer.bounds.size.x / 2;
		p3.x = Mathf.Max (p3.x, -w);
		p3.x = Mathf.Min (p3.x, w);
		transform.position = p3;

		StartPos = EndPos;

		if (Mathf.Abs (len) > 0.01f) 
		        {
						if (p2.x > p1.x)
								bRight = true;
						if (p2.x < p1.x)
								bRight = false;
						anim.SetBool("bRun",true);
	
				}

		}
}
