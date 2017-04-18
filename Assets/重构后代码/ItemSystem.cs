using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemSystem : MonoBehaviour {
    public class ItemInBlank
    {
       public string name;
        public string introduction;
        public string introductionWhenAdded;
        public Sprite sprite;
       public ItemInBlank(string itemName,string intro,string iWA,Sprite sp)
        {
            name = itemName;
            introduction = intro;
            introductionWhenAdded = iWA;
            sprite = sp;
        }
    };
    public class Item组合
    {
        public string i组合1;
        public string i组合2;
        public string i组合后name;
        public Item组合(string i1,string i2,string ina)
        {
            i组合1 = i1;
            i组合2 = i2;
            i组合后name = ina;
        }
    }
    public static ItemSystem current;
    static string currentItem;
    GameObject itemBlank;
    public bool isShowing=false;
    public bool is组合模式;
    public GameObject 框框;
    GameObject 当前框框;
    GameObject 组合框框;
    int 组合1=-1;
    static public List<Item组合> Item组合记录表;
    static public List<ItemInBlank> AllItemList;
    static public List<ItemInBlank> ItemList;//当前道具表列

    GameObject[] ItemImages;//道具栏里的道具图片表列
    public GameObject AllItems;//所有道具的父对象

    private void Awake()
    {
        AllItemList = new List<ItemInBlank>();
        ItemList = new List<ItemInBlank>();
        Item组合记录表 = new List<Item组合>();
        current = this;
    }
    void Start () {
        itemBlank = GameObject.FindGameObjectWithTag("ItemBlank");
		Fade.Hide (itemBlank);
        FindItems();
		for(int i =0;i<ItemImages.Length;i++){
			Fade.Hide (ItemImages [i]);
		}
        AllItems.SetActive(false);
        isShowing = false;
    }

    public void ShowItemBlank()
    {
        GameSystem.StopMove();
        MyCamera.isFixing = false;
        is组合模式 = false;
		Fade.FadeIn (itemBlank);
        //显示道具
        AllItems.SetActive(true);
		int i = 0;
        for (; i < ItemList.Count; i++)
        {
			Fade.FadeIn (ItemImages[i]);
            ItemImages[i].GetComponent<SingleItem>().Introduction = ItemList[i].introduction;
            ItemImages[i].GetComponent<SpriteRenderer>().sprite = NameToSprite(ItemList[i].name);
            ItemImages[i].GetComponent<SingleItem>().iname = ItemList[i].name;
        }
		for(;i<ItemImages.Length;i++){
			Fade.Hide (ItemImages [i]);
			ItemImages[i].GetComponent<SingleItem>().iname ="Nothing";
		}
        //
        isShowing = true;
    }

    public void HideItemBlank()
    {
        MyCamera.isFixing = true;
        GameSystem.isMoving = true;
		for (int i = 0; i < ItemList.Count; i++)
        {
            ItemImages[i].GetComponent<SingleItem>().iname = "Nothing";
			Fade.FadeOut (ItemImages [i]);
        }
		Fade.FadeOut (itemBlank);
		StartCoroutine (SetAllItemsFalse ());
        isShowing = false;
        隐藏所有框框();
        隐藏组合框框();
    }
	IEnumerator SetAllItemsFalse(){
		yield return new WaitForSeconds (0.21f);
		AllItems.SetActive(false);
	}

    public static void AddItem(string itemName)//添加道具
    {
        ItemInBlank iib = NameToItem(itemName);
        SubtitleSystem.ShowSubtitle(iib.introductionWhenAdded);
        ItemList.Add(iib);
    }

    public void DeleteItem(int o)
    {
        ItemList.Remove(ItemList[o]);
    }
    public static void DeleteItem(string s)
    {
        int o = -1;
        for(int i = 0; i < ItemList.Count; i++)
        {
            if (s == ItemList[i].name) o = i;
        }
        if (o != -1)
        {
            ItemList.Remove(ItemList[o]);
        }
    }

    public void DeleteItem(int o1,int o2)
    {
        ItemInBlank i1 = ItemList[o1];
        ItemInBlank i2 = ItemList[o2];
        ItemList.Remove(i1);
        ItemList.Remove(i2);
    }

    static ItemInBlank NameToItem(string name)
    {
        ItemInBlank si = null;
        for(int i = 0; i < AllItemList.Count; i++)
        {
            if (AllItemList[i].name == name) si=AllItemList[i];
        }
        return si;
    }
    static Sprite NameToSprite(string name)//找到道具名字对应的图片
    {
        Sprite sp=null;
        for (int i = 0; i < AllItemList.Count; i++)
        {
            if (AllItemList[i].name == name) sp = AllItemList[i].sprite;
        }
        return sp;
    }

    void FindItems()//获取道具栏表列
    {
        GameObject[] ii = GameObject.FindGameObjectsWithTag("SingleItem");
        ItemImages = new GameObject[ii.Length];
        for(int i = 0; i < ii.Length; i++)
        {
            int o = ii[i].GetComponent<SingleItem>().order;
            ItemImages[o] = ii[i];
        }
    }

    public void 显示框框(Vector3 p)
    {
        当前框框=GameObject.Instantiate(框框,p,Quaternion.identity);
    }

    public void 创造组合框框(Vector3 p,int o)
    {
        is组合模式 = true;
        组合框框 = GameObject.Instantiate(框框, p, Quaternion.identity);
        组合1 = o;
    }
    public void 隐藏框框()
    {
        Destroy(当前框框);
    }
    public void 隐藏所有框框()
    {
        GameObject[] kuang = GameObject.FindGameObjectsWithTag("kuangkuang");
        for(int i=0;i<kuang.Length;i++)
        {
            Destroy(kuang[i]);
        }
    }
    public void 隐藏组合框框()
    {
        is组合模式 = false;
        Destroy(组合框框);
        组合1 = -1;
    }
    public bool is当前组合(int o)
    {
        return (o == 组合1);
    }
    public void 组合(int o)
    {
        bool isSuccess=false;
        if (组合1 != -1)
        {
            for(int i = 0; i < Item组合记录表.Count; i++)
            {
                if((ItemList[组合1].name==Item组合记录表[i].i组合1&&ItemList[o].name== Item组合记录表[i].i组合2)|| (ItemList[组合1].name == Item组合记录表[i].i组合2 && ItemList[o].name == Item组合记录表[i].i组合1))
                {
                    DeleteItem(组合1, o);
                    AddItem(Item组合记录表[i].i组合后name);
                    ShowItemBlank();
                    isSuccess = true;
                    break;
                }
            }
            if (!isSuccess)
            {
                SubtitleSystem.ShowSubtitle("不能组合哦");
                AudioSystem.current.Play("交互失败");
            }
            else
            {
                AudioSystem.current.Play("组合");
            }
        }
    }

    public static string GetCurrentItem()
    {
        string s=currentItem;
        ItemSystem.current.StopCoroutine(DropItem());
        ItemSystem.current.StartCoroutine(DropItem());
        print(s);
        return s;
    }
    static IEnumerator DropItem()
    {
        yield return new WaitForEndOfFrame();
        ItemSystem.ChangeCurrentItem("Nothing");
        yield return 0;
    }
    public static void ChangeCurrentItem(string s)
    {
        currentItem = s;
    }
}
