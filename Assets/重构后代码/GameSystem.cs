using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour {
    public static bool isMoving = true;
    static bool ifEnded = false;
    static bool ifWon = false;
    static GameObject co;
    static GameSystem current;
    public GameObject 遮挡用3D碰撞箱;
    private void Awake()
    {
        current = this;
    }
    public static void StopMove()
    {
        isMoving = false;
        Player.leg.setMoveStation(false);
    }
    public static void IStarted()
    {
        //co=GameObject.Instantiate(current.遮挡用3D碰撞箱, current.transform);
        StopMove();
        MyCamera.isFixing = false;
    }
    public static void IEnded()
    {
        Destroy(co);
        isMoving = true;
        MyCamera.isFixing = true;
        ifEnded = true;
    }
    public static void IWin()
    {
        Destroy(co);
        isMoving = true;
        MyCamera.isFixing = true;
        ifWon = true;
    }
    public static bool IfClose()
    {
        bool b = ifEnded;
        ifEnded = false;
        return b;
    }
    public static bool IfWin()
    {
        bool b = ifWon;
        ifWon = false;
        return b;
    }
}
