using UnityEngine;
using System.Collections;

public class genFixLevel : MonoBehaviour {

	public generator gen;


	// Use this for initialization
	void Start () {
	


	}
	
	// Update is called once per frame
	void Update () {
	
		transform.localScale = new Vector3(gen.genFixLevel/10, 0.04f, 0.04f);

	}
}
