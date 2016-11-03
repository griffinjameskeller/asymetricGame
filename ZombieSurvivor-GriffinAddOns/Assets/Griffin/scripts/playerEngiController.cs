using UnityEngine;
using System.Collections;

public class playerEngiController : playerController {
	
	public bool fixing = false;
	public int numGenFixed = 0;
	public bool goalAchieved = false;


	// Update is called once per frame
	protected override void updating(){
		if (numGenFixed == 4) {
			goalAchieved = true;
		}
	}
	protected override void startAction1(){
		fixing = true;
	}
	protected override void startAction2(){
		runLevel = 2.0f;
	}
	protected override void stopAction1(){
		fixing = false;
	}
	protected override void stopAction2(){
		runLevel = 1.0f;
	}
}