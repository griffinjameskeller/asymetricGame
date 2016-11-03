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
		shoot2 ();
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
		if (Physics.Raycast (transform.position, facing, out hit)) {
			if (hit.collider.gameObject.tag == "zombie") {
				
			}
		}
		float distance = 10f;
		Debug.DrawRay (transform.position, facing * distance);
	}
	private void shoot2(){
		if (CD_Bomb == 0) {
			CD_Bomb = 10;
			startCoolDown ();
			GameObject missile = Instantiate (explosive, transform.position + facing * 0.08f, char1.transform.rotation) as GameObject;
		}
	}



}
