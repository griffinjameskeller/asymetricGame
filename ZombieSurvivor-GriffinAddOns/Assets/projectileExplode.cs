using UnityEngine;
using System.Collections;

public class projectileExplode : MonoBehaviour {

	public float timer = 4f;
	public bool boom = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		timer -= Time.deltaTime;

			if (timer < 1) {

			boom = true;

			}

		if (timer < 0.4f) {
			Destroy(this.gameObject);
		}

	}
}
