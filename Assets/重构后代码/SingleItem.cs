using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleItem : MonoBehaviour {
    public string iname="Nothing";
    public string Introduction;
    public int order;
    void Start()
    {
    }
    void OnMouseOver()
    {
        if (iname != "Nothing") {
            if (Input.GetMouseButtonUp(1))
            {
                if (ItemSystem.current.is组合模式&&!ItemSystem.current.is当前组合(order))
                {
                    ItemSystem.current.组合(order);
                }
                else
                {
                    SubtitleSystem.ShowSubtitle("拿" + iname + "干嘛呢~");
                    ItemSystem.ChangeCurrentItem(iname);
                    ItemSystem.current.HideItemBlank();
                }
                ItemSystem.current.隐藏组合框框();
            }
            if (Input.GetMouseButtonUp(0))
            {
                ItemSystem.current.隐藏组合框框();
                ItemSystem.current.创造组合框框(transform.position,order);
            }
        }
    }
    private void OnMouseEnter()
    {
        ItemSystem.current.显示框框(transform.position);
        if (iname != "Nothing")
        {
            SubtitleSystem.ShowSubtitle(Introduction);
        }
    }
    void OnMouseExit()
    {
        ItemSystem.current.隐藏框框();
    }
}
