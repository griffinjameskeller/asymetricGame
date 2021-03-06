﻿using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {
	protected GameObject char1;
	protected GameObject charBody1;

	private int hp = 10;
	private float speedAlter = 1;
	private bool isZombie = false;
	private const float WALK_SPEED = 3f;
	private float speedUp = 1;
	private GameObject runner;
	private float runnerDistance = 2;
	protected Vector3 facing;
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
		runner =  GameObject.Find ("playerRunner");
		char1 = gameObject;
		charBody1 = GameObject.Find (name + "body");
	}
	// Update is called once per frame
	void Update () {
		updating ();

		detectRunner ();


		float valuex = Input.GetAxis ("Horizontal"); 
		//Left right button
		float valuey = Input.GetAxis ("Vertical"); 
		//Up down button
		bool action = Input.GetButton ("Fire1");
		//Action button
		bool actionTwo = Input.GetButton ("Fire2");
		//Action button

		//Walking and attacking
		if (!isZombie) {
			if (valuex != 0 || valuey != 0) {
				walk (new Vector3 (valuex, 0f, valuey));
			} else {
				stopWalk ();
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
	private void detectRunner(){
		if (runner) {
			float dis = Vector3.Distance (gameObject.transform.position, runner.transform.position);
			if (dis < runnerDistance && runner.GetComponent<playerRunner> ().isDashing) {
				speedUp = 2f;
			} else {
				speedUp = 1;
			}
		}
	}
	private void becomeZombie(){
		isZombie = true;
		Destroy (gameObject);
	}
	private void stopWalk(){
		char1.GetComponent<Rigidbody> ().velocity =new Vector3();
	}
	private void walk(Vector3 dir){
		float finalAngle;
		float myAngle;

		//char1.transform.Translate (dir*WALK_SPEED*speedAlter);

		char1.GetComponent<Rigidbody> ().velocity = dir * WALK_SPEED * speedAlter * speedUp;

		finalAngle = Mathf.Atan2(dir.x,dir.z)/Mathf.PI*180f;
		if (finalAngle < 0) {
			finalAngle = 360f + finalAngle;
		}
		myAngle = charBody1.transform.eulerAngles.y;

		if (Mathf.Abs (finalAngle - myAngle) > 1f) {
			myAngle += (finalAngle - myAngle) * 0.3f * speedAlter;
		}
		charBody1.transform.eulerAngles = new Vector3(0f,myAngle,0f);

		facing = dir;
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Minion") {
			hit (1);
		} 
	}

	
}