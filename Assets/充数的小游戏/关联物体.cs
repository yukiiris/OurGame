using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 关联物体 : Machine {
    public GameObject 小游戏;
	void Start () {
        currentState = new 胜利前();
	}
	
	class 胜利前 :MachineState{
        public override void Execute(Machine machine)
        {
            if (machine.IfInteracted()) GameObject.Instantiate(machine.GetComponent<关联物体>().小游戏);
            if (GameSystem.IfClose()) machine.ChangeState(new 失败());
            if (GameSystem.IfWin()) machine.ChangeState(new 胜利());
        }
    }
    class 失败 : MachineState
    {
        public override void Enter(Machine machine)
        {
            LogSystem.Speak("哎呀好难啊~", Player.current);
            LogSystem.IfSpeakEnded();//清空对话检测缓冲【重要】
            machine.ChangeState(new 胜利前());
        }
    }
    class 胜利 : MachineState
    {
        public override void Enter(Machine machine)
        {
            machine.animator.SetBool("ifWin", true);
            LogSystem.Speak("我赢了", Player.current);
            LogSystem.IfSpeakEnded();//清空对话检测缓冲【重要】
        }
    }
}
