using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AMen : Machine {

	// Use this for initialization
	void Start () {
        currentState = new basicState();
	}

    class basicState : MachineState
    {
        public override void Execute(Machine machine)
        {
            if (machine.IfInteracted())
            {
                SceneManager.UnloadSceneAsync("C1S2");
                SceneChanger.Change("C1S3", "C1S4", "打开门后，一切都变了。", 4);
            }
        }
    }
}
