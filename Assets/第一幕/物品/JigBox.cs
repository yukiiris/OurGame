using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JigBox : Machine {

	void Start () {
		currentState = new InitState ();
	}

	class InitState:MachineState
	{ 
		public override void Enter(Machine machine){ 

		} 

		public override void Execute(Machine machine){ 
			if (machine.IfInteracted ()&&ItemSystem.GetCurrentItem()=="电闸零件") {
				EBrake.brakeIsOn = false;
				++EBrake.counter;
			}

		}

		public override void Exit(Machine machine){ 

		} 
	} 
}
