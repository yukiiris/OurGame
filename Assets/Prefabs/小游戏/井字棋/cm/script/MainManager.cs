using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour {
    public static bool isThis_Mini_gameFinish =false;
    public static bool isPlayerReallyWin = false;

    static int Round=1;//记录回合数 五盘不输！ 厨师先行
    static bool isPlayerHasLost = false;

    const int COMPUTER = -1;
    const int PLAYER = 1;
    const int appearingDraw = 3;
    // Use this for initialization
    void Start () {
        GameSystem.IStarted();
	}

    private void Update()
    {
        if (isThis_Mini_gameFinish)
        {
            if (isPlayerReallyWin)
            {
                Destroy(this.gameObject);
                GameSystem.IWin();
            }
            else
            {
                Destroy(this.gameObject);
                GameSystem.IEnded();
            }
            
        }
        else RoundManager();
    }

    void RoundManager()
    {
        if (Round > 5) isThis_Mini_gameFinish = true;
        if (ChessManager.isGameover)
        {
            Round++;
            NewRoundBeginAndInit();
        }
        if (Chess.RoundWinner == COMPUTER) isPlayerHasLost = true;
    }
    
    //初始化逻辑棋盘和显示棋盘
    void NewRoundBeginAndInit()
    {
        ChessManager.NewRoundBeginAndInit();
        //销毁他娘的子物体
        Component[] g = GetComponentsInChildren<Transform>();
        foreach(Component a in g)
        {
            if (a != transform)
                Destroy(a.gameObject);
        }
        switch (Round)
        {
            case 1:ChessManager.isPlayer = false;break;
            case 2: ChessManager.isPlayer = true; break;
            case 3: ChessManager.isPlayer = false; break;
            case 4: ChessManager.isPlayer = true; break;
            case 5: ChessManager.isPlayer = false; break;
        }
        
    }
}
