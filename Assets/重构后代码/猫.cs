using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 猫 : NPC {

    static bool isMove = false;
    static bool isStand = false;

    private void Start()
    {
        currentState = new StandState();
    }

    class StandState : NPCState
    {
        public override void Enter(NPC npc)
        {
            npc.animator.SetBool("isMove", false);
        }

        public override void Execute(NPC npc)
        {
            if (isMove)
            {
                npc.ChangeState(new MoveState());
            }
        }

        public override void Exit(NPC npc)
        {

        }
    }

  
    class MoveState : NPCState
    {
        public override void Enter(NPC npc)
        {
            base.Enter(npc);
            npc.animator.SetBool("isMove", true);
            npc.leg.MoveTo(npc.x);
        }

        public override void Execute(NPC npc)
        {
            if (isStand)
            {
                npc.ChangeState(new StandState());
            }
        }

        public override void Exit(NPC npc)
        {
            base.Exit(npc);
        }
    }
}
