using UnityEngine;
using System.Collections;

public class gameEnder : MonoBehaviour {

	public playerEngiController engi;
	private int genCheck;

	void Update () {

		genCheck = engi.numGenFixed;

		//print (genCheck);


	}

	void OnTriggerStay (Collider col) {

		if (col.gameObject.tag == "Engineer") {

			if (genCheck == 4) {

				print ("gameOver");

			}
		}



	}

}
