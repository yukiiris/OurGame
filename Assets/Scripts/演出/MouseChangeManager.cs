using UnityEngine;
using System.Collections;


public class MouseChangeManager : MonoBehaviour
{

    static MouseChangeManager _instance;
    public static MouseChangeManager Instance
    {
        get
        {
            return _instance;
        }
    }


    public Texture2D normalCursor, npcCursor, itemCursor;



    void Awake()
    {
        _instance = this;
        Cursor.SetCursor(normalCursor, Vector2.zero, CursorMode.Auto);
    }


    public void SetCursorNormal()
    {
        Cursor.SetCursor(normalCursor, Vector2.zero, CursorMode.Auto);
    }


    public void SetCursorItem()
    {
        Cursor.SetCursor(itemCursor, Vector2.zero, CursorMode.Auto);
    }


    public void SetCursorNpc()
    {
        Cursor.SetCursor(npcCursor, Vector2.zero, CursorMode.Auto);
    }

}
