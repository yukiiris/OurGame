using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    static public Player current;
    static public Leg leg;
    static public Animator animator;
    public Mouth mouth;
	// Use this for initialization
	void Awake () {
        current = this;
        leg = GetComponentInParent<Leg>();
        mouth = GetComponent<Mouth>();
        animator = GetComponent<Animator>();
	}
	
	public float GetXPosition()
    {
        return transform.position.x;
    }
}
