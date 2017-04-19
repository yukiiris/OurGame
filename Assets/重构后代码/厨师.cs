using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 厨师 : NPC
{
	public static int counter = 1;
    public GameObject chess;

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
			if (npc.IfInteracted ()) {
                //print ("act");
                string item = ItemSystem.GetCurrentItem();
                if ( item == "棋盘")
                {
                    npc.ChangeState(new ItemState22());
                }
                else if (item == "金币")
                {
                    npc.ChangeState(new ItemState32());
                }
                else switch (厨师.counter)
                    {
                        case 1: npc.ChangeState(new TalkState11()); break;
                        case 2: npc.ChangeState(new TalkState21()); break;
                        case 3: npc.ChangeState(new TalkState31()); break;
                        case 4: npc.ChangeState(new TalkState41()); break;
                        case 5: npc.ChangeState(new TalkState51()); break;
                        case 6: npc.ChangeState(new TalkState61()); break;

                    }
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
				npc.ChangeState (new StandState());
			}
		}
	}


	class TalkState21 : NPCState
	{
		public override void Enter(NPC npc)
		{
			LogSystem.Speak ("如果你找到了棋盘就带给我吧。", npc);

		}

		public override void Execute(NPC npc)
		{
			if (LogSystem.IfSpeakEnded ()) {
				npc.ChangeState (new StandState ());
			}
		}
	}

	class ItemState22 : NPCState
	{
		public override void Enter(NPC npc)
		{
			ItemSystem.DeleteItem ("棋盘");
			++厨师.counter;

		}

		public override void Execute(NPC npc)
		{
			npc.ChangeState (new TalkState31());
		}
	}
	class TalkState31 : NPCState
	{
		public override void Enter(NPC npc)
		{
			LogSystem.Speak ("棋盘有了，但我还要金币。", npc);

		}

		public override void Execute(NPC npc)
		{
			if (LogSystem.IfSpeakEnded ()) {
				npc.ChangeState (new StandState ());
			}
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
			npc.ChangeState (new TalkState41());

		}

		public override void Exit(NPC npc)
		{

		}
	}
	class TalkState41 : NPCState
	{
		public override void Enter(NPC npc)
		{
			LogSystem.Speak ("我们开始下棋吧。", npc);
        }

		public override void Execute(NPC npc)
		{
			if (LogSystem.IfSpeakEnded ()) {
				npc.ChangeState (new PlayState ());
			}
		}
	}
    class PlayState : NPCState
    {
        public override void Enter(NPC npc)
        {
            GameObject.Instantiate(npc.GetComponent<厨师>().chess);
            npc.ChangeState(new beforeTalkState51());
        }
    }
    class beforeTalkState51 : NPCState
    {
        public override void Execute(NPC npc)
        {
            if (GameSystem.IfWin())
            {
                ++厨师.counter;
                npc.ChangeState(new TalkState51());
            }
            else if (GameSystem.IfClose())
            {
                npc.ChangeState(new StandState());
            }
        }
    }
    class TalkState51 : NPCState//胜利
	{
		public override void Enter(NPC npc)
		{
            ItemSystem.AddItem("小钥匙");
			LogSystem.Speak ("你赢啦，门已经打开了。", npc);
            ++厨师.counter;
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
            LogSystem.Speak("你还挺厉害的。", npc);
        }

		public override void Execute(NPC npc)
		{
			if (LogSystem.IfSpeakEnded ()) {
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
			LogSystem.Speak ("你好啊，今天天气不错。", npc);
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
}
