using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneLineControl : MonoBehaviour {
	private OneLineNote note;
	public bool ifNote1=false;
	public OneLineNote note1;
	public bool ifNote2=false;
	public OneLineNote note2;
	public bool ifNote3=false;
	public OneLineNote note3;
	public bool ifNote4=false;
	public OneLineNote note4;
	public OneLineLast last;
//	public bool ifNoten=false;
//	public OneLineNote noten;
//  按上述格式增加
	private int con = 0;
	// Use this for initialization
	void Start () {
		note = GetComponent<OneLineNote> ();
	}
	void OnMouseDown(){
		if ( note.myPos==last.lastPos) {
			con++;
		}
		if (ifNote1) {
			if ( note1.myPos== last.lastPos) {
				con++;
			}
		}
		if (ifNote2) {
			if ( note2.myPos== last.lastPos) {
				con++;
			}
		}
		if (ifNote3) {
			if (note3.myPos == last.lastPos) {
				con++;
			}
		}
		if (ifNote4) {
			if (note4.myPos == last.lastPos) {
				con++;
			}
		}

//		if (ifNoten) {
//			if ( noten.myPos== last.lastPos) {
//				con++;
//			}
//		}
//      按上述格式增加
		if (note.ifLink == false&&con>0) {
			note.ifChange = !note.ifChange;
			last.lastPos = note.myPos;
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
