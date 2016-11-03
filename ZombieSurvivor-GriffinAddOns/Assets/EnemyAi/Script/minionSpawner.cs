using UnityEngine;
using System.Collections;

public class minionSpawner : MonoBehaviour {

	public GameObject Minion;
	public float timer;
	public int activate;

	void Start () {

	}

	void FixedUpdate () {
		
		//print (Time.deltaTime);

		timer = timer + Time.deltaTime;

		//print (timer);

		if (timer >= activate) {

			Spawn ();
			timer = 0;

		}

	}

	void Spawn () {

		Instantiate (Minion, transform.position, Quaternion.identity);

	}

}
