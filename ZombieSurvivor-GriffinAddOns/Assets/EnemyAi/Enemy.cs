using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public float deathDistance = 0.5f;
	public float distanceAway;
	public bool inSight, active;
	public Transform enemy, target, routeEnd;
	public string targetName;
	private NavMeshAgent navComponent;

	void Start() 
	{
		navComponent = this.gameObject.GetComponent<NavMeshAgent>();
	}

	void FixedUpdate() {

		if (!inSight) {
			Patrol ();
		} else if (inSight) {
			Chase ();
		}

	}

	void Chase () {

		active = true;

		distanceAway = Vector3.Distance(target.position, transform.position);

		if (routeEnd) {
			navComponent.SetDestination (target.position);
		} else if (routeEnd == null) {
			routeEnd = this.gameObject.GetComponent<Transform> ();
		} else {
			routeEnd = GameObject.FindGameObjectWithTag (targetName).transform;
		}

	}

	void Patrol () {

		distanceAway = Vector3.Distance(routeEnd.position, transform.position);

		if (routeEnd) {
			navComponent.SetDestination (routeEnd.position);
		} else if (routeEnd == null) {
			routeEnd = this.gameObject.GetComponent<Transform> ();
		} else {
			routeEnd = GameObject.FindGameObjectWithTag ("Goal").transform;
		}

	}

	void OnTriggerStay (Collider col) {

		if (col.gameObject.CompareTag ("Player")) {
			inSight = true;
			target = col.gameObject.transform;
			targetName = col.gameObject.name;
		}

	}

	void OnTriggerExit (Collider col) {

		if (col.gameObject.CompareTag ("Player")) {
			inSight = false;
		}

	}
}
