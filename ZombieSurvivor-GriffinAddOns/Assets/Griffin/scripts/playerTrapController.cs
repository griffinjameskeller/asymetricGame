using UnityEngine;
using System.Collections;

public class playerTrapController : MonoBehaviour {
	GameObject engineer;
	GameObject charBody1;
	public Transform spawner;
	public GameObject trapPrefab;
	public float instanceTimer = 0f;
	public float timeAmount = 20f;


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
		engineer = gameObject;
		charBody1 = GameObject.Find (name + "body");
	}
	// Update is called once per frame
	void Update () {

		if (instanceTimer > 0){

			instanceTimer -= Time.deltaTime;

		} else {
			instanceTimer = 0;
		}

		float valuex = Input.GetAxis ("Horizontal"); 
		//Left right button
		float valuey = Input.GetAxis ("Vertical"); 
		//Up down button
		bool action = Input.GetButtonDown ("Fire1");
		//Action button

		//Walking and attacking
		if (valuex != 0 || valuey != 0) {
			walk (new Vector3(valuex*WALK_SPEED*speedAlter,0f,valuey*WALK_SPEED*speedAlter));
		} 
		if (action) {
			doAction ();
		}
	}

	private void doAction(){

		if (instanceTimer == 0) {
			GameObject trapInstance;
			trapInstance = Instantiate (trapPrefab, spawner.transform.position, spawner.rotation) as GameObject;
			instanceTimer = timeAmount;
		}
	}

	private void becomeZombie(){
		isZombie = true;
		speedAlter = 0.2f;
	}

	private void walk(Vector3 dir){
		float finalAngle;
		float myAngle;

		engineer.transform.Translate (dir);
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

