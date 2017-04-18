using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singer : NPC
{
	public static int  counter=1;
    public static bool isSing = false;
    public static bool isTalk = false;
    public static bool isStand = false;

    private void Start()
    {
        currentState = new StandState();
    }

    class StandState : NPCState
    {
        public override void Enter(NPC npc)
        {
            npc.animator.SetBool("isSing", false);
            npc.animator.SetBool("isTalk", false);
        }

        public override void Execute(NPC npc)
        {
            if (isTalk)
            {
                npc.ChangeState(new TalkState());
            }

            if (isSing)
            {
                npc.ChangeState(new SingState());
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
            npc.animator.SetBool("isSing", false);
            npc.animator.SetBool("isTalk", true);
        }

        public override void Execute(NPC npc)
        {
            if (isStand)
            {
                npc.ChangeState(new StandState());
            }

            if (isSing)
            {
                npc.ChangeState(new SingState());
            }
        }

        public override void Exit(NPC npc)
        {

        }
    }

    class SingState : NPCState
    {
        public override void Enter(NPC npc)
        {
            base.Enter(npc);
            npc.animator.SetBool("isSing", true);
            npc.animator.SetBool("isTalk", false);
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
