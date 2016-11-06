using UnityEngine;
using System.Collections;

public class wallCrawler : MonoBehaviour {

	public float movSpd;
	public int direction;
	public bool goWhichWay;
	public bool canGoLeft;
	public bool canGoRight;

	Rigidbody rb;

	RaycastHit front;
	RaycastHit left;
	RaycastHit right;

	Vector3 leftCheck;
	Vector3 rightCheck;
	Vector3 angle;

	void Start () {

		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {

		leftCheck = -transform.right;
		rightCheck = transform.right;
		CheckFront ();
		CheckSides ();
		Movement ();


	}

	void CheckFront () {

		if(Physics.Raycast(transform.position, transform.forward, out front, 2f)) {
			if (front.collider != null) {
				if(front.collider.gameObject.layer == 8) {
					print ("there's a wall in front");
					Turning ();
				}
			}
		}
	}

	void CheckSides () {

		if(Physics.Raycast(transform.position, leftCheck, out left, 2f)) {
			if (left.collider != null) {
				if (left.collider.gameObject.layer == 8) {
					print ("there's a wall on my left");
					canGoLeft = false;
				} 
			} 
		} else {
			print ("there ISN'T a wall on my left");
			canGoLeft = true;
		}

		if(Physics.Raycast(transform.position, rightCheck, out right, 2f)) {
			if (left.collider != null) {
				if (left.collider.gameObject.layer == 8) {
					print ("there's a wall on my left");
					canGoRight = false;
				} 
			} 
		} else {
			print ("there ISN'T a wall on my left");
			canGoRight = true;
		}
	}

	void Movement () {
		
		rb.velocity = transform.forward * movSpd;
	}

	void Turning () {

		angle = gameObject.transform.eulerAngles;

		if (canGoLeft && canGoRight) {

			direction = Mathf.RoundToInt (Random.Range (0, 99));

			if (direction > 50) {
				goWhichWay = true;
			} else if (direction <= 50) {
				goWhichWay = false;
			}

			if (goWhichWay) {
				gameObject.transform.eulerAngles = angle + new Vector3 (0, -90, 0);
				print ("goleft");
			} else if (!goWhichWay) {
				gameObject.transform.eulerAngles = angle + new Vector3 (0, 90, 0);
				print ("goright");
			}
		}

		if (!canGoLeft && canGoRight) {
			gameObject.transform.eulerAngles = angle + new Vector3 (0, 90, 0);
		}

		if (canGoLeft && !canGoRight) {
			gameObject.transform.eulerAngles = angle + new Vector3 (0, -90, 0);
		}

		if (!canGoLeft && !canGoRight) {
			gameObject.transform.eulerAngles = angle + new Vector3 (0, 180, 0);
		}
	}
	void OnDrawGizmos () {
		Gizmos.color = Color.red;
		Gizmos.DrawRay (transform.position, transform.forward * 2);

		Gizmos.color = Color.green;
		Gizmos.DrawRay (transform.position, leftCheck * 2);

		Gizmos.color = Color.yellow;
		Gizmos.DrawRay (transform.position, rightCheck * 2);
	}
}
