using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinedItem : MonoBehaviour {
    public string combineItem1;
    public string combineItem2;
    // Use this for initialization
    void Start () {
        ItemSystem.Item组合记录表.Add(new ItemSystem.Item组合(combineItem1, combineItem2, GetComponent<Item>().itemName));
	}
}
