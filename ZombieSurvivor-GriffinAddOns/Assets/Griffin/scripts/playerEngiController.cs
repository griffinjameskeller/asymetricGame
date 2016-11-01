using UnityEngine;
using System.Collections;

public class playerEngiController : MonoBehaviour {
	GameObject char1;
	GameObject charBody1;
	public bool fixing = false;
	public float runLevel = 10f;
	public int numGenFixed = 0;
	public bool goalAchieved = true;

	public void hit(int point){
		if (!isZombie) {
			hp -= point;
			if (hp <= 0) {
				becomeZombie ();
			}
		} 
	}

	private int hp = 100;
	private float speedAlter = 1;
	private bool isZombie = false;

	private const float WALK_SPEED = 0.08f;
	// Use this for initialization
	void Start () {
		char1 = gameObject;
		charBody1 = GameObject.Find (name + "body");
	}
	// Update is called once per frame
	void Update () {
		//print (fixing);

		if (numGenFixed == 4) {
			goalAchieved = true;
		}

		float valuex = Input.GetAxis ("Horizontal"); 
		//Left right button
		float valuey = Input.GetAxis ("Vertical"); 
		//Up down button
		bool action = Input.GetButton ("Fire1");
		//Action button
		bool actionTwo = Input.GetButton ("Fire2");
		//Action button


		//Walking and attacking
		if (valuex != 0 || valuey != 0) {
			walk (new Vector3(valuex*WALK_SPEED*speedAlter,0f,valuey*WALK_SPEED*speedAlter));
		} 
		if (action) {
			//doAction ();
			fixing = true;
		} else {
			fixing = false;
		}

		if (actionTwo) {


			//doAction ();
			speedAlter = 2;

		} else {
			speedAlter = 1;
		}
	}

	private void doAction(){
		//add action
	}

	private void becomeZombie(){
		isZombie = true;
		speedAlter = 0.2f;
	}

	private void walk(Vector3 dir){
		float finalAngle;
		float myAngle;

		char1.transform.Translate (dir);
		finalAngle = Mathf.Atan2(dir.x,dir.z)/Mathf.PI*180f;
		if (finalAngle < 0) {
			finalAngle = 360f + finalAngle;
		}
		myAngle = charBody1.transform.eulerAngles.y;

		if (Mathf.Abs (finalAngle - myAngle) > 1f) {
			myAngle += (finalAngle - myAngle) * 0.3f * speedAlter;
		}
		charBody1.transform.eulerAngles = new Vector3(0f,myAngle,0f);
		//character.GetComponent<Animator> ().SetBool ("isWalking", true);

	}
}