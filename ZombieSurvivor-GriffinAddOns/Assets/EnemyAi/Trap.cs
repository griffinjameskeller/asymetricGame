using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour {

	public float proximity;
	public int uses;

	void Update() {

		if (uses == 0) {

			Destroy (gameObject);

		}

	}

	void OnTriggerStay (Collider col) {

		if (col.gameObject.CompareTag ("Minion")) {

			float distanceAway = Vector3.Distance(col.transform.position, transform.position);

			print (distanceAway);

			if (distanceAway < proximity) {

				uses--;
				Destroy (col.gameObject);

			}

		}

	}
}
