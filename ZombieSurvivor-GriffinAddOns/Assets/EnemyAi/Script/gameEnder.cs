using UnityEngine;
using System.Collections;

public class gameEnder : MonoBehaviour {

	void OnTriggerStay (Collider col) {

		col.GetComponent<playerEngiController> ();

	}

}
