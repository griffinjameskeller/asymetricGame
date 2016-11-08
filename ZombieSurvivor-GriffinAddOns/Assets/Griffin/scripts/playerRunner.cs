using UnityEngine;
using System.Collections;

public class playerRunner : playerController {

	public bool isDashing = false;
	private float dashCD = 0;
	// Update is called once per frame
	protected override void updating(){
		if (dashCD > 0) {
			dashCD -= Time.deltaTime;
			if(dashCD < 10){
				isDashing = false;
			}
		} else {
			dashCD = 0;
		}
	}
	protected override void startAction1(){
		if (dashCD == 0) {
			isDashing = true;
			dashCD = 15;
		}
	}
	protected override void startAction2(){
	}
	protected override void stopAction1(){
		
	}
	protected override void stopAction2(){
	}
}