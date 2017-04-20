using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour {
    public static bool isThis_Mini_gameFinish = false;
    public static bool isPlayerReallyWin = false;

    static int Round;//记录回合数 五盘不输！ 厨师先行
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
                Destroy(this);
                GameSystem.IWin();
            }
            else
            {
                Destroy(this);
                GameSystem.IEnded();
            }
            
        }
        else RoundManager();
    }

    void RoundManager()
    {
        if (Round == 5) isThis_Mini_gameFinish = true;
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
        Transform[] g = GetComponentsInChildren<Transform>();
        foreach(Transform a in g)
        {
            Destroy(a.GetComponent<GameObject>());
        }
        ChessManager.isPlayer = !ChessManager.isPlayer;
        
    }
}
