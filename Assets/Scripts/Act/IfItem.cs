using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfItem : MonoBehaviour {
	public string currentItem;
	private Item item;
	// Use this for initialization
	void Start () {
		item = GetComponent<Item> ();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (ItemSystem.GetCurrentItem ());
		if (ItemSystem.GetCurrentItem () == currentItem) {
			item.enabled = true;
		}
		else {
			item.enabled = false;
		}
	}
}
