using UnityEngine;
using System.Collections;

public class playerTrapController : playerController {
	
	private float instanceTimer = 0f;

	public GameObject trapPrefab;
	public float timeAmount = 20f;


	protected override void updating () {
		
		if (instanceTimer > 0){

			instanceTimer -= Time.deltaTime;

		} else {
			instanceTimer = 0;
		}
	}

	protected override void startAction1 (){
		if (instanceTimer == 0) {
			GameObject trapInstance;
			trapInstance = Instantiate (trapPrefab, transform.position, charBody1.transform.rotation) as GameObject;
			instanceTimer = timeAmount;
		}
	}

}

