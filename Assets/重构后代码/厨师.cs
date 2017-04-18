using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 厨师 : NPC
{
	public GameObject poster;
	public GameObject ink;
	public GameObject gold;
    public static bool isTalk = false;
	public static bool isStand = false;
	public static int counter = 1;

    private void Start()
    {
        currentState = new StandState();
    }

    class StandState : NPCState
    {
        public override void Enter(NPC npc)
		{
            npc.animator.SetBool("isTalk", false);
        }

        public override void Execute(NPC npc)
		{
            if (isTalk)
            {
                npc.ChangeState(new TalkState());
            }

			if (npc.IfInteracted ()) {
				//print ("act");
				if (厨师.counter == 1) {
					npc.ChangeState (new TalkState11 ());
				} 
				if (厨师.counter == 2) {
					npc.ChangeState (new TalkState21 ());
				}
				if (厨师.counter == 3) {
					npc.ChangeState (new TalkState31 ());
				}
				if (厨师.counter == 4) {
					npc.ChangeState (new TalkState41 ());
				}
				if (ItemSystem.GetCurrentItem () == "棋盘") {
					npc.ChangeState (new ItemState22 ());
				}
				if (ItemSystem.GetCurrentItem () == "金币") {
					npc.ChangeState (new ItemState32 ());
				}
				if (厨师.counter == 5) {
					npc.ChangeState (new TalkState51 ());
				}
				if (厨师.counter == 6) {
					npc.ChangeState (new TalkState61 ());
				}

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
           //print(厨师.isTalk);
            npc.animator.SetBool("isTalk", true);
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

        }
    } 

	class TalkState11 :NPCState
	{
		public override void Enter(NPC npc)
		{
			npc.animator.SetBool("isTalk", true);
			LogSystem.Speak ("你好呀，来和我下棋吧。",npc);
		}
		public override void Execute (NPC npc)
		{
			if (LogSystem.IfSpeakEnded ()) {
				npc.ChangeState (new TalkState12());
			}
		}
		public override void Exit (NPC npc)
		{
			
		}
	}

	class TalkState12 :NPCState
	{
		public override void Enter(NPC npc)
		{
			LogSystem.Speak ("你问我为什么？",npc);
		}
		public override void Execute (NPC npc)
		{
			if (LogSystem.IfSpeakEnded ()) {
				npc.ChangeState (new TalkState13());
			}
		}
		public override void Exit (NPC npc)
		{

		}
	}

	class TalkState13 :NPCState
	{
		public override void Enter(NPC npc)
		{
			LogSystem.Speak ("因为如果你赢不了我，前面的门就不会开。",npc);
		}
		public override void Execute (NPC npc)
		{
			if (LogSystem.IfSpeakEnded ()) {
				npc.ChangeState (new TalkState14());
			}
		}
		public override void Exit (NPC npc)
		{

		}
	}
	class TalkState14 :NPCState
	{
		public override void Enter(NPC npc)
		{
			LogSystem.Speak ("明白了就好，快准备棋盘吧，我這有棋子了。", npc);
			++厨师.counter;
		}
		public override void Execute (NPC npc)
		{
			if (LogSystem.IfSpeakEnded ()) {
				npc.GetComponent<厨师> ().poster.SetActive (false);
				npc.GetComponent<厨师> ().ink.SetActive (false);
				npc.ChangeState (new StandState());
			}
		}
		public override void Exit (NPC npc)
		{

		}
	}


	class TalkState21 : NPCState
	{
		public override void Enter(NPC npc)
		{
			npc.animator.SetBool("isTalk", true);
			LogSystem.Speak ("如果你找到了棋盘就带给我吧。", npc);

		}

		public override void Execute(NPC npc)
		{
			if (LogSystem.IfSpeakEnded ()) {
				npc.ChangeState (new StandState ());
			}
		}

		public override void Exit(NPC npc)
		{

		}
	}

	class ItemState22 : NPCState
	{
		public override void Enter(NPC npc)
		{
			ItemSystem.DeleteItem ("棋盘");
			npc.GetComponent<厨师> ().gold.SetActive (false);
			++厨师.counter;

		}

		public override void Execute(NPC npc)
		{
			npc.ChangeState (new StandState());
		}

		public override void Exit(NPC npc)
		{

		}
	}
	class TalkState31 : NPCState
	{
		public override void Enter(NPC npc)
		{
			npc.animator.SetBool("isTalk", true);
			LogSystem.Speak ("棋盘有了，但我还要金币。", npc);

		}

		public override void Execute(NPC npc)
		{
			if (LogSystem.IfSpeakEnded ()) {
				npc.ChangeState (new StandState ());
			}
		}

		public override void Exit(NPC npc)
		{

		}
	}
	class ItemState32 : NPCState
	{
		public override void Enter(NPC npc)
		{
			ItemSystem.DeleteItem ("金币");
			++厨师.counter;
		}

		public override void Execute(NPC npc)
		{
			npc.ChangeState (new StandState());

		}

		public override void Exit(NPC npc)
		{

		}
	}
	class TalkState41 : NPCState
	{
		public override void Enter(NPC npc)
		{
			npc.animator.SetBool("isTalk", true);
			LogSystem.Speak ("我们开始下棋吧。", npc);

		}

		public override void Execute(NPC npc)
		{
			if (LogSystem.IfSpeakEnded ()) {
				npc.ChangeState (new StandState ());
			}
		}

		public override void Exit(NPC npc)
		{

		}
	}
	class TalkState51 : NPCState
	{
		public override void Enter(NPC npc)
		{
			npc.animator.SetBool("isTalk", true);
			LogSystem.Speak ("你赢啦，门已经打开了。", npc);

		}

		public override void Execute(NPC npc)
		{
			if (LogSystem.IfSpeakEnded ()) {
				npc.ChangeState (new StandState ());
			}
		}

		public override void Exit(NPC npc)
		{

		}
	}
	class TalkState61 : NPCState
	{
		public override void Enter(NPC npc)
		{
			//player.istalk=true speak"打招呼之类的"
		}

		public override void Execute(NPC npc)
		{
			if (true/*LogSystem.IfSpeakEnded ()*/) {
				//istalk=false
				npc.ChangeState (new TalkState62 ());
			}
		}

		public override void Exit(NPC npc)
		{

		}
	}
	class TalkState62 : NPCState
	{
		public override void Enter(NPC npc)
		{
			npc.animator.SetBool ("isTalk",true);
			LogSystem.Speak ("你好啊，今天天气不错。", npc);

		}

		public override void Execute(NPC npc)
		{
			if (LogSystem.IfSpeakEnded ()) {
				npc.animator.SetBool ("isTalk",false);
				npc.ChangeState (new StandState ());
			}
		}

		public override void Exit(NPC npc)
		{

		}
	}
}
