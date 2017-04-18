using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryBox : Machine {
	public static bool activeBattery = false;


	void Start () {
		BatteryBox.activeBattery = true;
		currentState = new InitState ();
	}

	class InitState:MachineState
	{ 
		public override void Enter(Machine machine){ 
			
		} 

		public override void Execute(Machine machine){ 
			if (machine.IfInteracted ()&&ItemSystem.GetCurrentItem()=="电池") {
				ItemSystem.DeleteItem ("电池");
				EBrake.brakeIsOn = false;
				++EBrake.counter;
			}
			
		}

		public override void Exit(Machine machine){ 

		} 
	} 
}
