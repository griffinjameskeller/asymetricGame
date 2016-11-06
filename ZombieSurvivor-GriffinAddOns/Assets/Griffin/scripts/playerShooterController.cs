using UnityEngine;
using System.Collections;

public class playerShooterController : playerController {
	
	public GameObject explosive;

	protected override void updating(){
		
	}
	protected override void startAction1(){
		shoot ();
	}
	protected override void startAction2(){
		
	}
	protected override void stopAction1(){
		
	}
	protected override void stopAction2(){
	}

	private int CD_Bomb = 0;
	private void startCoolDown(){
		if (!IsInvoking("subTake_Second")) {
			InvokeRepeating("subTake_Second", 1, 1);
		}
	}
	private void subTake_Second() {

		if (CD_Bomb > 0) {
			CD_Bomb -= 1;
		}
	}
	private void shoot(){
		RaycastHit hit;
		float distance = 100f;
		if (Physics.Raycast (transform.position, facing * distance, out hit, 10000f)) {
			print (hit.collider.gameObject.name);
			if (hit.collider.gameObject.name == "face") {
				Destroy(hit.collider.gameObject);
			}
		}

		Debug.DrawRay (transform.position, facing * distance);
	}




}
