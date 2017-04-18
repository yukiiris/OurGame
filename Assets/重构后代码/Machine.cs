using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineState
{
    public virtual void Enter(Machine machine)
    {

    }
    public virtual void Execute(Machine machine)
    {

    }
    public virtual void Exit(Machine machine)
    {

    }
}
public class Machine : MonoBehaviour {
    public MachineState currentState = null;
    public Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        GetComponent<BasicInformation>().IamSpeacial();
    }
    void Update()
    {
        if (currentState != null)
        {
            currentState.Execute(this);
        }
    }
    public void ChangeState(MachineState newState)
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
