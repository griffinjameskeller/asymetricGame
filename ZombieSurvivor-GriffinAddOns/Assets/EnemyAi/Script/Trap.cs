using UnityEngine;
using System.Collections;

public class trap : MonoBehaviour {

	public float proximity;
	public int uses;
	public bool limited;

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

				if (limited) {
					uses--;
				}
				Destroy (col.gameObject);

			}

		}

	}
}
