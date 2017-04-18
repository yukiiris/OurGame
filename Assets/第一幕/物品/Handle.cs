using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : Machine {

	public static bool activeScissors = false;
	public  bool handleIsOn=false;
	public GameObject handle1;
	public GameObject handle2;
	public GameObject light1;
	public GameObject light2;

	private void Start () {
			currentState=new InitState();  
	} 


	class InitState:MachineState
	{ 
			public override void Enter(Machine machine){ 
			
			} 

		public override void Execute(Machine machine){ 
			if (machine.IfInteracted ()) {
				machine.GetComponent<Handle>().handleIsOn = !machine.GetComponent<Handle>().handleIsOn;
				if (machine.GetComponent<Handle> ().handleIsOn == true) {
					machine.ChangeState (new OnState ());
				}

				if (machine.GetComponent<Handle> ().handleIsOn == false) {
					machine.ChangeState (new OffState ());
				}
			}
		}

			public override void Exit(Machine machine){ 

			} 
		} 
	
	class OnState:MachineState
	{
		public override void Enter(Machine machine){ 
			machine.GetComponent<Handle> ().handle1.SetActive (false);
			machine.GetComponent<Handle> ().light1.SetActive (false);
			machine.GetComponent<Handle> ().handle2.SetActive (true);
			machine.GetComponent<Handle> ().light2.SetActive (true);
			activeScissors = true;
		} 

		public override void Execute(Machine machine){ 
				machine.ChangeState (new InitState ());

		} 

		public override void Exit(Machine machine){ 

		} 
		
	}

	class OffState:MachineState
	{
		public override void Enter(Machine machine){ 
			machine.GetComponent<Handle> ().handle2.SetActive (false);
			machine.GetComponent<Handle> ().light2.SetActive (false);
			machine.GetComponent<Handle> ().handle1.SetActive (true);
			machine.GetComponent<Handle> ().light1.SetActive (true);
		} 

		public override void Execute(Machine machine){ 
			machine.ChangeState (new InitState ());

		} 

		public override void Exit(Machine machine){ 

		} 

	}
}
