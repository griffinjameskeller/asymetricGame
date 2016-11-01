using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {
	protected GameObject char1;
	protected GameObject charBody1;

	private int hp = 100;
	private float speedAlter = 1;
	private bool isZombie = false;
	private const float WALK_SPEED = 0.08f;

	protected float runLevel = 1f;

	public void hit(int point){
		if (!isZombie) {
			hp -= point;
			if (hp <= 0) {
				becomeZombie ();
			}
		} 
	}


	// Use this for initialization
	void Start () {
		char1 = gameObject;
		charBody1 = GameObject.Find (name + "body");
	}
	// Update is called once per frame
	void Update () {
		print ("a");
		updating ();

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
			walk (new Vector3(valuex*WALK_SPEED*speedAlter,0f,valuey*WALK_SPEED*speedAlter*runLevel));
		} 
		if (action) {
			startAction1 ();
		} else {
			stopAction1 ();
		}

		if (actionTwo) {
			startAction2 ();
		} else {
			stopAction2 ();
		}
	}
	protected virtual void updating(){
		//add action
	}
	protected virtual void startAction1(){
		//add action
	}
	protected virtual void startAction2(){
		//add action
	}
	protected virtual void stopAction1(){
		//add action
	}
	protected virtual void stopAction2(){
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

	}
}