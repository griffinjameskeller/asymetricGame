using UnityEngine;
using System.Collections;

public class minionSpawner : MonoBehaviour {

	public GameObject Minion;
	public float timer;
	public int activate;

	GameObject Manager;

	void Start () {
		Manager = GameObject.Find ("MinionManager");

	}

	public void Spawn () {

		Instantiate (Minion, transform.position, Quaternion.identity);
		Manager.SendMessage ("AddToCount");

	}

}
