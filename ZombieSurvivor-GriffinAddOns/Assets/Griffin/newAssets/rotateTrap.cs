using UnityEngine;
using System.Collections;

public class rotateTrap : MonoBehaviour {

	public int rotateSpeed = 5;

	// Update is called once per frame
	void Update () {

		transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
	}
}
