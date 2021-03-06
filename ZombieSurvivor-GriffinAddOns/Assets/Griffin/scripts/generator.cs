﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class generator : MonoBehaviour {

	public int genActive = 0;
	public float genFixLevel = 0;
	public float drainMeter = 0;
	public playerEngiController engineer;
	public bool genFixed = false;
	public bool inArea = false;
	public float fixSpeed = 1f;
	public Slider healthSlider;
	private GameObject manager;

	// Use this for initialization
	void Start () {
		engineer = GameObject.Find ("Eng").GetComponent<playerEngiController> ();
		manager = GameObject.Find ("MinionManager");
	}
	
	// Update is called once per frame
	void FixedUpdate () {


		if (genFixLevel < 10) {
			if (engineer.fixing && inArea) {

				genFixLevel += Time.deltaTime * fixSpeed;

			} else {

				if (genFixLevel > 0) {
					genFixLevel -= Time.deltaTime * drainMeter;
				} else {
					genFixLevel = 0;
				}
			}
		} if (genFixLevel >= 10 && !genFixed) {
			//print ("its fixed");
			manager.SendMessage ("AddMaxCount");
			engineer.numGenFixed = engineer.numGenFixed + 1;
			genFixed = true;
		
		}

	}

	void OnTriggerStay (Collider other) {
		if (other.gameObject.tag == "Engineer") {
			inArea = true;
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.gameObject.tag == "Engineer") {
			inArea = false;
		}
	}


}
