using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCg : Machine {
	void Start () {
		currentState = new InitState ();
	}

	class InitState:MachineState
	{
		public override void Enter(Machine machine){

		}

		public override void Execute (Machine machine)
		{
			if (machine.IfInteracted ()) {
				GameSystem.IStarted ();
				machine.GetComponent<ShowCg> ().transform.GetChild (0).gameObject.SetActive (true);
			}
		}

		public override void Exit(Machine machine){

		}

	}
}