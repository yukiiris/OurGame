using UnityEngine;



public  class ChessManager {
    //x y 都是电脑的
    public static int[,] Board = new int[3,3]{ { 0 ,0, 0}, { 0,0,0 }, { 0, 0, 0 } };
    static public bool isPlayer =false, isGameover = false;
    public static int x, y, row = 1, column = 1;
    static int[,] weightRecordArray = new int[3, 3] { { 20, 0, 20 }, { 0, 45, 0 }, { 20, 0, 20 } };

    const int BLACK = -1;//COMPUTER
    const int WHITE = 1;//PLAYER

    static public void artificialPlayerPlayerFirst(int step)
    {
        /*用的是权值算法
        自己要连成3个赋值100
        敌人要连成3个赋值50
        自己要完成眼的布置赋值40
        中心赋值 这是眼布置的关键45
        敌人要完成眼的布置赋值 30
        对角线上的空地赋值20
        决定要下的对角线空地赋值25
        空的赋值0
        有棋子的地方赋值-1
        */
         int[] rowEnemyRecord = { 0, 0, 0 };//记录每一行有多少敌军 

         int[] columnEnemyRecord = { 0, 0, 0 };//记录列 

         int[] rowSelfRecord = { 0, 0, 0 };
         int[] columnSelfRecord = { 0, 0, 0 };

for (int i = 0; i< 3; i++)
	for (int j = 0; j< 3; j++) {
		if (Board[i,j]==WHITE)
		{
			rowEnemyRecord[i]++; columnEnemyRecord[j]++;//计算 哪个地方有两个 
		}
		if (Board[i,j] == BLACK)
		{
			rowSelfRecord[i]++; columnSelfRecord[j]++;
		}
	}
//找出玩家能连成三个地儿的点
for (int j = 0; j< 3; j++) {
	if (rowEnemyRecord[j] ==2)
	{
                row = j;
        for (int i = 0; i < 3; i++)
        {
            if (Board[row, i] == 0)
            {
                weightRecordArray[row, i] = weightRecordArray[row, i] < 50 ? 50 : weightRecordArray[row, i];
                break;
             }
        }
        break;
	}
}

for (int j = 0; j< 3; j++) {
	if (columnEnemyRecord[j] == 2) 
	{
                column = j;
               for (int i = 0; i< 3; i++)
                {
                    if (Board[i, column] == 0)
                    {
                        weightRecordArray[i, column] = weightRecordArray[i, column] < 50 ? 50 : weightRecordArray[i, column];
                        break;
                    }
                }
                break;
	}
}
//找出自己能连成三个的地儿
for (int j = 0; j< 3; j++) {
	if (rowSelfRecord[j] == 2)
	{
               
                for (int i = 0; i < 3; i++)
                {
                    if (Board[j,i] == 0)
                    {
                        weightRecordArray[j, i] = weightRecordArray[j, i] < 100 ? 100 : weightRecordArray[j, i];
                        break;
                    }
                }
                break;
	}
}

for (int j = 0; j< 3; j++){
	if (columnSelfRecord[j] == 2)
	{
		column = j;
		
                for (int i = 0; i < 3; i++)
                {
                    if (Board[i,column] == 0)
                    {
                        weightRecordArray[i, column] = weightRecordArray[i, column] < 100 ? 100 : weightRecordArray[i, column];
                        break;
                    }
                }
                break;
	}
}


//对角线上的自己和敌方是否会赢的判断
        if ((Board[0, 0] == WHITE && Board[1, 1] == WHITE && Board[2, 2] == 0) || (Board[1, 1] == WHITE && Board[2, 2] == WHITE && Board[0, 0] == 0) || (Board[0, 0] == WHITE && Board[2, 2] == WHITE && Board[1, 1] == 0))
        {
            if (Board[0, 0] == 0)
            {
                weightRecordArray[0, 0] = weightRecordArray[0,0] < 50 ? 50 : weightRecordArray[0, 0];
            }
        
            else if (Board[2, 2] == 0)
            {
                weightRecordArray[2, 2] = weightRecordArray[2, 2] < 50 ? 50 : weightRecordArray[2, 2];
            }
    
        }

        if ((Board[0, 2] == WHITE && Board[1, 1] == WHITE && Board[2, 0] == 0) || (Board[1, 1] == WHITE && Board[2, 0] == WHITE && Board[0, 2] == 0) || (Board[0, 2] == WHITE && Board[2, 0] == WHITE && Board[1, 1] == 0))
        { //enemyPositivelyBiased = 1;
            if (Board[0, 2] == 0)
            {
                weightRecordArray[0, 2] = weightRecordArray[0, 2] < 50 ? 50 : weightRecordArray[0, 2];
            }
            else if (Board[2, 0] == 0)
            {
                weightRecordArray[2, 0] = weightRecordArray[2, 0] < 50 ? 50 : weightRecordArray[2, 0];
            }
        }
         

        if ((Board[0, 0] == BLACK && Board[1, 1] == BLACK && Board[2, 2] == 0) || (Board[1, 1] == BLACK && Board[2, 2] == BLACK && Board[0, 0] == 0) || (Board[0, 0] == BLACK && Board[2, 2] == BLACK && Board[1, 1] == 0))
        {
            if (Board[0, 0] == 0)
            {
                weightRecordArray[0, 0] = weightRecordArray[0, 0] < 100 ? 100: weightRecordArray[0, 0];
                
            }
            else if (Board[2, 2] == 0)
            {
                weightRecordArray[2,2] = weightRecordArray[2, 2] < 100 ? 100 : weightRecordArray[2, 2];

            }
        }

        if ((Board[0, 2] == BLACK && Board[1, 1] == BLACK && Board[2, 0] == 0) || (Board[1, 1] == BLACK && Board[2, 0] == BLACK && Board[0, 2] == 0) || (Board[0, 2] == BLACK && Board[2, 0] == BLACK && Board[1, 1] == 0))
        {
            if (Board[0, 2] == 0)
            {
                weightRecordArray[0, 2] = (weightRecordArray[0, 2]) < 100 ? 100 : weightRecordArray[0, 2];
            }
            else if (Board[2, 0] == 0)
            {
                weightRecordArray[2, 0] = (weightRecordArray[2, 0]) < 100 ? 100 : weightRecordArray[2, 0];
            }
        }//对方只有一个地方可以赢的时候


        //判断自己能不能赢  自己的值比较重   放在后面改变
    
//把不能下子的地方灭了
    for (int j = 0; j< 3; j++)
	    for (int i = 0; i< 3; i++)
	    {
	    	if (Board[i,j] != 0) weightRecordArray[i,j] = -1;
	    }
//int(*p)[3] = weightRecordArray;
    int finalRun;
    finalRun = findMaxWeight();
    x = finalRun % 10;//取这数字的个位数
    y = finalRun / 10;//取这个数字的十位数
    Board[y, x] = BLACK;
        isPlayer = true;
}

     static int findMaxWeight()
	{
        int maxPosition = 0, maxNumber = 0;
        for (int i = 0; i<3;i++)
			for (int j = 0; j< 3;j++)
			{
				if (weightRecordArray[i,j] >= maxNumber)
                {
                    //还一度一味maxNumber没用，但要用它来找出maxPosition
					maxNumber = weightRecordArray[i,j];//找出最大的权值  然后给maxPosition定位
					maxPosition = i*10+j;//记录哪个位
				}
			}
		return(maxPosition);
	}
    static public int IfWin()
    {
        int temRecord=0;
        const int appearingDraw = 3;
        for(int i=0;i<3;i++)
        {
            if (Board[i, 0] + Board[i, 1] + Board[i, 2] == BLACK * 3)
            {
                temRecord = BLACK;isGameover = true; return (temRecord);
            }
            else if(Board[i, 0] + Board[i, 1] + Board[i, 2] == WHITE * 3)
            {
                temRecord = WHITE; isGameover = true; return (temRecord);
            }
        }
        for (int j = 0; j < 3; j++)
        {
            if (Board[0, j] + Board[1, j] + Board[2, j] == BLACK * 3)
            {
                temRecord = BLACK; isGameover = true; return (temRecord);
            }
            else if (Board[0, j] + Board[1, j] + Board[2, j] == WHITE * 3)
            {
                temRecord = WHITE; isGameover = true; return (temRecord);
            }
        }
        //判断对角线
        if((Board[0,0]==Board[1,1]&& Board[1, 1] == Board[2,2]&& Board[1, 1]==WHITE)|| (Board[0, 2] == Board[1, 1] && Board[1, 1] == Board[2, 0] && Board[1, 1] == WHITE))
        {
            temRecord = WHITE; isGameover = true; return (temRecord);
        }
        else if ((Board[0, 0] == Board[1, 1] && Board[1, 1] == Board[2, 2] && Board[1, 1] == BLACK) || (Board[0, 2] == Board[1, 1] && Board[1, 1] == Board[2, 0] && Board[1, 1] == BLACK))
        {
            temRecord = BLACK;isGameover = true;return (temRecord);
        }

        int temCounting = 0;
        for (int i=0;i<3;i++)
            for(int j=0;j<3;j++)
            {
                if (Board[i, j] != 0) temCounting++;
            }
        //appear a draw    if the program can go to here  the "temrecord" must be zero
        if (temCounting == 9)
        {
            isGameover = true;
            return (appearingDraw);
        }
        else
        {
            return (temRecord);
        }
    }

    public static void NewRoundBeginAndInit()
    {
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
            {
                Board[i, j] = 0;
            }
        isGameover = false;
        row = 1;
        column = 1;
        weightRecordArray= new int[3, 3] { { 20, 0, 20 }, { 0, 45, 0 }, { 20, 0, 20 } };

    }
}


