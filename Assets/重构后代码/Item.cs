using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
	public string itemName;
    public Sprite sprite;
    public string subtitleWhenAdded;
    public string subtitleInBlank;
    BasicInteractive bi=null;
    private void Start()
    {
        bi = GetComponent<BasicInteractive>();
        ItemSystem.AllItemList.Add(new ItemSystem.ItemInBlank(itemName, subtitleInBlank, subtitleWhenAdded, sprite));
    }
    private void Update()
    {
        if (bi != null && bi.isActed())
        {
			Fade.Disappear (gameObject);
            ItemSystem.AddItem(itemName);
            Destroy(bi);
            Destroy(GetComponent<BasicInteractive>());
        }
    }
}
