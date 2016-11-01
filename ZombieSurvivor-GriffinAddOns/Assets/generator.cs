using UnityEngine;
using System.Collections;

public class generator : MonoBehaviour {

	public int genActive = 0;
	public float genFixLevel = 0;
	public float drainMeter = 0;
	public playerEngiController engineer;
	public bool genFixed = false;
	public bool inArea = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		if (engineer.fixing && inArea) {

			genFixLevel += Time.deltaTime;

		} else {

			if (genFixLevel > 0) {
				genFixLevel -= Time.deltaTime * drainMeter;
			} else {
				genFixLevel = 0;
			}
		}

		if (genFixLevel > 10) {
			genFixed = true;
			genFixLevel = 10.1f;
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
