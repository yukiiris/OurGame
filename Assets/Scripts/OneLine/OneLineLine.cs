using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneLineLine : MonoBehaviour {
	public OneLineNote note1;
	public OneLineNote note2;
	public OneLineLast last;
	private Renderer rend;
	private bool havedo = false;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		rend.enabled=false;
	}

	// Update is called once per frame
	void Update () {
		if(note1.ifChange==true&&note2.ifChange==true&&havedo==false){
			rend.enabled=true;
			note1.ifLink = true;
			note2.ifLink = true;
			last.num++;
			havedo = true;
		}
	}
}
