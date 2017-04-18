using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedWire : Machine {                                      

	void Start () {
		currentState = new InitState ();
	}
	
	class InitState:MachineState{
		public override void Enter(Machine machine){
		
		}

		public override void Execute(Machine machine){
			if (machine.IfInteracted ()&&ItemSystem.GetCurrentItem()=="剪刀") {
				machine.ChangeState (new ItemState ());
			
			}
		}

		public override void Exit(Machine machine){

		}


		class ItemState:MachineState{
			public override void Enter(Machine machine){
				ItemSystem.DeleteItem ("剪刀");
				ItemSystem.AddItem ("电线");
				machine.gameObject.SetActive (false);
			}

			public override void Execute(Machine machine){

			}

			public override void Exit(Machine machine){

			}

		}

	}
}
	

