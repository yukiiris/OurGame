using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JigsawManager : MonoBehaviour
{
    public int blank = 8;
    public int[] winArray = { 0, 1, 2, 3, 4, 5, 6, 8, 7 };
    public int[] nowArray = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
    // Use this for initialization
    void Start()
    {
        //print(Win().ToString());
    }

    // Update is called once per frame
    void Update()
	{
		Win ();
    }

    public void ChangeNowArray(int i, int value)
    {
        nowArray[i] = value;
    }

    public bool Win()
    {
        int i = 0;
        //  print(i.ToString());
        while (i < 9)
        {
            int a = nowArray[i];
            int b = winArray[i];
            //       print(a.ToString());
            if (a != b)
            {
                return false;
            }
            i += 1;
        }
        return true;
    }
}

