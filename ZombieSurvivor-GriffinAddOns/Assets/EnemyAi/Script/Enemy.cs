 using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {
	
	public float deathDistance = 0.5f;
	public float distanceAway;
	public bool inSight, active;
	public Transform minion, target, routeEnd;
	public string targetName;
	private NavMeshAgent navComponent;

	void Start() 
	{
		navComponent = this.gameObject.GetComponent<NavMeshAgent>();
		routeEnd = GameObject.FindGameObjectWithTag ("Goal").transform;
		target = GameObject.FindGameObjectWithTag ("Goal").transform;
		minion = this.gameObject.transform;
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

		float distanceAway;

		GameObject obj = GameObject.Find (targetName);

		if (inSight && obj!=null) {
			target = obj.transform;
			distanceAway = Vector3.Distance(target.position, transform.position);
			navComponent.SetDestination (target.position);
		} else {
			navComponent.SetDestination (routeEnd.position);
		}
	}

	void Patrol () {

		distanceAway = Vector3.Distance(routeEnd.position, transform.position);

		if (routeEnd) {
			navComponent.SetDestination (routeEnd.position);
		} else if (routeEnd == null) {
			routeEnd = this.gameObject.GetComponent<Transform> ();
		}

	}

	void OnTriggerStay (Collider col) {

		if (col.gameObject.CompareTag ("Player") || col.gameObject.CompareTag ("Engineer")) {
			inSight = true;
			target = col.gameObject.transform;
			targetName = col.gameObject.name;
		}

	}

	void OnTriggerExit (Collider col) {

		if (col.gameObject.CompareTag ("Player") || col.gameObject.CompareTag ("Engineer")) {
			inSight = false;
		}

	}
}
