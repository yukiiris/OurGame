using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chess : MonoBehaviour {
    // is computer   -1
    // is  player    1
    const int COMPUTER = -1;
    const int PLAYER = 1;
    const int appearingDraw=3;
    public GameObject Cc;
    public GameObject Pc;
    public GameObject DefeatImage;
    public GameObject DrawImage;
    public static int RoundWinner=0;
    int x = 0, y = 0;
    float sizex;
    float leftx;
    float sizey;
    float lefty;
    // Use this for initialization
    void Start () {
        sizex = GetComponent<BoxCollider>().size.x * transform.localScale.x;//碰撞箱相对于父物体  size position都是相对transform
        leftx = transform.position.x - sizex / 2;
        sizey = GetComponent<BoxCollider>().size.y * transform.localScale.y;
        lefty = transform.position.y - sizey / 2;
    }
	
	// Update is called once per frame
	void Update () {
        if (!ChessManager.isPlayer)
        {
            ChessManager.artificialPlayerPlayerFirst(0);
            x = ChessManager.x;
            y = ChessManager.y;
            ChessDown(Cc);
            ChessManager.isPlayer = true;
        }
        if (ChessManager.IfWin() != 0)
        {
            int judgement = ChessManager.IfWin();
            if (judgement == PLAYER) PlayerWin();
            else if (judgement == COMPUTER) ComputerWin();
            else if (judgement == appearingDraw) DrawAppear(); 
        }
	}

    private void OnMouseUp()
    {
        if (ChessManager.isPlayer)
        {
            CheckPosition(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if (ChessManager.Board[y,x] == 0)
            {
                ChessDown(Pc);
                ChessManager.Board[y, x] = 1;
                ChessManager.isPlayer = false;
            }
        }
    }
    void ChessDown(GameObject g)
    {
        Vector3 v= transform.position - new Vector3((1 - x) * sizex / 3, (1 - y) * sizey / 3, 1);
        GameObject.Instantiate(g, v, Quaternion.identity,transform);
        
    }
    void CheckPosition(Vector3 mouseposition)
    {
        x = (int)((mouseposition.x - leftx) * 3 / sizex);
        y = (int)((mouseposition.y - lefty) * 3 / sizey);
    }
   
    void ComputerWin()//五局三胜
    {
        //这一个小局玩家输了
        RoundWinner = COMPUTER;
        SubtitleSystem.ShowSubtitle("这一回合你输了耶~继续努力~", 3);
    }

    void PlayerWin()
    {
        //这一小局玩家赢了  不能的哈哈哈
        RoundWinner = PLAYER;
    }

    void DrawAppear()
    {
        RoundWinner = appearingDraw;
        SubtitleSystem.ShowSubtitle("这回合是平局呢！加油努力干掉电脑！", 3);
    }
}
