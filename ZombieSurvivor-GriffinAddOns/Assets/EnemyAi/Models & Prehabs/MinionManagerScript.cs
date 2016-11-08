using UnityEngine;
using System.Collections;

public class MinionManagerScript : MonoBehaviour {

	public int maxMinionCount;
	public int minionCount;
	public int incrementalAmount;
	public float timer;
	public int activate;

	public GameObject[] spawners;

	void FixedUpdate () {

		if (minionCount < maxMinionCount) {

			timer = timer + Time.deltaTime;

		}

		if (timer >= activate) {

			ActivateSpawner ();
			timer = 0;

		}

	}

	void ActivateSpawner () {

		if (minionCount < maxMinionCount) {

			foreach (GameObject spawner in spawners) {
				spawner.SendMessage ("Spawn");

			}

		}

	}

	public void AddToCount () {

		minionCount = minionCount + 1;
	}

	public void SubToCount () {

		minionCount = minionCount - 1;
	}

	public void AddMaxCount () {

		maxMinionCount = maxMinionCount + 12;
	}
}
