using UnityEngine;
using System.Collections;

public class genLight : MonoBehaviour {

	public generator gen;
	public Light lightLevel;
	public Color color0 = Color.red;
	public Color color1 = Color.blue;
	public float speed = 0.8f;

	// Use this for initialization
	void Start () {
	
		lightLevel = GetComponent<Light> ();

		lightLevel.color = color0;

	}
	
	// Update is called once per frame
	void Update () {
	 
		lightLevel.intensity = gen.genFixLevel * speed;

		if (gen.genFixLevel > 10) {

			lightLevel.color = color1;
		}

	}
}
