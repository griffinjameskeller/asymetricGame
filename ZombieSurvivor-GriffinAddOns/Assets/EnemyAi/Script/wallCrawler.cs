using UnityEngine;
using System.Collections;

public class wallCrawler : MonoBehaviour {

	public float movSpd;
	public int direction;
	public bool goWhichWay;
	public bool canGoLeft;
	public bool canGoRight;
	public bool gotTarget;

	public string targetName;

	Rigidbody rb;

	RaycastHit front, left, right, targetHit;

	Vector3 leftCheck, rightCheck, angle, dir, targetPos;

	GameObject Manager;


	void Start () {

		Manager = GameObject.Find ("MinionManager");
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {

		if (!gotTarget) {
			Stabilize ();
			Seeker ();
			leftCheck = -transform.right;
			rightCheck = transform.right;
			CheckFront ();
			CheckSides ();
			Movement ();

			Debug.DrawRay (transform.position, transform.forward * 2, Color.red);
			Debug.DrawRay (transform.position, leftCheck * 2, Color.green);
			Debug.DrawRay (transform.position, rightCheck * 2, Color.yellow);
		}

		if (gotTarget) {
			Chaser ();
		}

	}

	void CheckFront () {

		if(Physics.Raycast(transform.position, transform.forward, out front, 2f)) {
			if (front.collider != null) {
				if(front.collider.gameObject.layer == 8) {
					Turning ();
				}
			}
		}
	}

	void CheckSides () {

		if(Physics.Raycast(transform.position, leftCheck, out left, 2f)) {
			if (left.collider != null) {
				if (left.collider.gameObject.layer == 8) {
					canGoLeft = false;
				} 
			} 
		} else {
			canGoLeft = true;
		}

		if(Physics.Raycast(transform.position, rightCheck, out right, 2f)) {
			if (left.collider != null) {
				if (left.collider.gameObject.layer == 8) {
					canGoRight = false;
				} 
			} 
		} else {
			canGoRight = true;
		}
	}

	void CheckForEnemies () {

		if(Physics.Raycast(transform.position, transform.forward, out front, 3f)) {
			if (front.collider != null) {
				if(front.collider.gameObject.CompareTag("Minion")) {
					TurnAround ();
				}
			}
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
			} else if (!goWhichWay) {
				gameObject.transform.eulerAngles = angle + new Vector3 (0, 90, 0);
			}
		}

		if (!canGoLeft && canGoRight) {
			gameObject.transform.eulerAngles = angle + new Vector3 (0, 90, 0);
		}

		if (canGoLeft && !canGoRight) {
			gameObject.transform.eulerAngles = angle + new Vector3 (0, -90, 0);
		}

		if (!canGoLeft && !canGoRight) {
			TurnAround ();
		}
	}

	void TurnAround () {
		gameObject.transform.eulerAngles = angle + new Vector3 (0, 180, 0);
	}

	void Stabilize () {

		float Yaxis;
		Yaxis = Mathf.RoundToInt(gameObject.transform.eulerAngles.y);

		if (Yaxis == 360 || Yaxis == -360) {
			Yaxis = 0;
		}

		if (Yaxis > 0 && 90 > Yaxis) {
			Yaxis = 90;
		}

		if (Yaxis > 90 && 180 > Yaxis) {
			Yaxis = 180;
		}

		if (Yaxis > 180 && 270 > Yaxis) {
			Yaxis = 270;
		}

		if (Yaxis > 270 && 360 > Yaxis) {
			Yaxis = 360;
		}

		if (Yaxis == 360 || Yaxis == -360) {
			Yaxis = 0;
		}

		if (Yaxis < 0 && -90 < Yaxis) {
			Yaxis = -90;
		}

		if (Yaxis < -90 && -180 < Yaxis) {
			Yaxis = -180;
		}

		if (Yaxis < -180 && -270 < Yaxis) {
			Yaxis = -270;
		}

		if (Yaxis < -270 && -360 < Yaxis) {
			Yaxis = -360;
		}
		gameObject.transform.eulerAngles = new Vector3 (0, Yaxis, 0);
	}

	void Seeker () {

		Debug.DrawRay (transform.position, transform.forward * 8, Color.cyan);

		if(Physics.Raycast(transform.position, transform.forward, out targetHit, 8f)) {
			if (targetHit.collider != null) {
				if(targetHit.collider.gameObject.CompareTag("Player") || targetHit.collider.gameObject.CompareTag("Engineer")) {
					print ("target locked");
					targetName = targetHit.collider.name;
					gotTarget = true;

				}
			}
		}
	}

	void Chaser () {
		GameObject targetObj = GameObject.Find (targetName);
		if (targetObj) {
			targetPos = targetObj.transform.position;
			print (targetPos);
			dir = gameObject.transform.position - targetPos;
			rb.velocity = -dir * 2f;
		} else {
			Destroy (gameObject);
		}

	}

	public void TargetDeleted () {

		Destroy (gameObject);
	}

	void OnCollisionEnter (Collision col) {

		if (gotTarget && col.gameObject.layer == 8) {

			Manager.SendMessage ("SubToCount");
			Destroy (gameObject);
		}
	}
		
}
