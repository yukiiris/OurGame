using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 守卫 : NPC
{

    static bool isMove = false;
    static bool isTalk = false;
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
            npc.animator.SetBool("isTalk", false);
        }

        public override void Execute(NPC npc)
        {
            if (isTalk)
            {
                npc.ChangeState(new TalkState());
            }

            if (isMove)
            {
                npc.ChangeState(new MoveState());
            }
        }

        public override void Exit(NPC npc)
        {

        }
    }

    class TalkState : NPCState
    {
        public override void Enter(NPC npc)
        {
            npc.animator.SetBool("isMove", false);
            npc.animator.SetBool("isTalk", true);
        }

        public override void Execute(NPC npc)
        {
            if (isStand)
            {
                npc.ChangeState(new StandState());
            }

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
            npc.animator.SetBool("isTalk", false);
            npc.leg.MoveTo(npc.x);
        }

        public override void Execute(NPC npc)
        {
            if (isStand)
            {
                npc.ChangeState(new StandState());
            }

            if (isTalk)
            {
                npc.ChangeState(new TalkState());
            }
        }

        public override void Exit(NPC npc)
        {
            base.Exit(npc);
        }
    }
}