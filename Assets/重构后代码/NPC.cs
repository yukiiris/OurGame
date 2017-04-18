using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCState
{
    public virtual void Enter(NPC npc)
    {

    }
    public virtual void Execute(NPC npc)
    {

    }
    public virtual void Exit(NPC npc)
    {

    }
}
public class NPC : MonoBehaviour {
    public NPCState currentState=null;
    public Animator animator;
    public Leg leg;
    public Mouth mouth;
	public float x;
    private void Awake()
    {
        mouth = GetComponent<Mouth>();
        leg = GetComponentInParent<Leg>();
        animator = GetComponent<Animator>();
        GetComponent<BasicInformation>().IamSpeacial();
    }
    void Update () {
        if (currentState != null)
        {
            currentState.Execute(this);
        }
	}
    public void ChangeState(NPCState newState)
    {
        currentState.Exit(this);
        currentState = newState;
        currentState.Enter(this);
    }
    public bool IfInteracted()
    {
        return (GetComponent<BasicInteractive>().isActed());
    }
    public void SetBasicInformation(string s0, float t0 = 0, string s1 = "", float t1 = 0, string s2 = "", float t2 = 0, string s3 = "", float t3 = 0)
    {
        GetComponent<BasicInformation>().Set(s0, t0, s1, t1, s2, t2, s3, t3);
    }
}
