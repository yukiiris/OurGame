using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBrake : Machine {
	
	public static int counter=1;
	public static bool brakeIsOn=false;

	public GameObject unpower;
	public GameObject power;
	public GameObject finish;
	public GameObject finish1;
	public JigsawManager jig;

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
				EBrake.brakeIsOn = !EBrake.brakeIsOn;
			}
			if (EBrake.counter == 1&&EBrake.brakeIsOn==true) {
				machine.ChangeState (new UnpowerState());
			}
			if (EBrake.counter == 2&&EBrake.brakeIsOn==true) {
				machine.ChangeState (new PowerState());
			}
			if (EBrake.counter == 3&&EBrake.brakeIsOn==true) {
				machine.ChangeState (new FinishState());
			}
			if (EBrake.counter == 4&&machine.IfInteracted ()) {
				machine.ChangeState (new Finish1State());
			}
		}

		public override void Exit(Machine machine){

		}

	}

	class UnpowerState:MachineState
	{
		public override void Enter(Machine machine){
			machine.GetComponent<EBrake> ().unpower.SetActive (true);
			GameSystem.IStarted ();
		}

		public override void Execute(Machine machine){
			if (EBrake.brakeIsOn == false) {
				machine.ChangeState (new InitState());
			}
		}

		public override void Exit(Machine machine){
			machine.GetComponent<EBrake> ().unpower.SetActive (false);
			GameSystem.IEnded ();
		}
	}

	class PowerState:MachineState
	{
		public override void Enter(Machine machine){
			machine.GetComponent<EBrake> ().power.SetActive (true);
			GameSystem.IStarted ();
		}

		public override void Execute(Machine machine){
			if (machine.GetComponent<EBrake> ().jig.Win ()) {
				++EBrake.counter;
				EBrake.brakeIsOn = false;
			}
			if (EBrake.brakeIsOn == false) {
				machine.ChangeState (new InitState());
			}
		}

		public override void Exit(Machine machine){
			machine.GetComponent<EBrake> ().power.SetActive (false);
			GameSystem.IEnded ();
		}
	}

	class FinishState:MachineState
	{
		public override void Enter(Machine machine){
			machine.GetComponent<EBrake> ().finish.SetActive (true);
			GameSystem.IStarted ();
		}

		public override void Execute(Machine machine){
			if (EBrake.brakeIsOn == false) {
				machine.ChangeState (new InitState());
			}
		}

		public override void Exit(Machine machine){
			machine.GetComponent<EBrake> ().finish.SetActive (false);
			GameSystem.IEnded ();
		}
	}

	class Finish1State:MachineState
	{
		public override void Enter(Machine machine){
			machine.GetComponent<EBrake> ().finish1.SetActive (true);
			GameSystem.IStarted ();
			SubtitleSystem.ShowSubtitle ("门的电力恢复了");
		}

		public override void Execute(Machine machine){
			if (EBrake.brakeIsOn == false) {
				machine.ChangeState (new InitState());
			}
		}

		public override void Exit(Machine machine){
			machine.GetComponent<EBrake> ().finish1.SetActive (false);
			GameSystem.IEnded ();
		}
	}
		
}
