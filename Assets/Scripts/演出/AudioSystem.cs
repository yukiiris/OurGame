using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : MonoBehaviour {
    public AudioClip 调查;
    public AudioClip 交互;
    public AudioClip 交互失败;
    public AudioClip 组合;
    public AudioClip 交谈;
    AudioSource aus;
    static public AudioSystem current;
    public AudioSource BGM;
    private void Awake()
    {
        current = this;
    }
    void Start () {
        aus = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Play(string s)
    {
        aus.clip = StringToAudio(s);
        aus.Play();
    }
    AudioClip StringToAudio(string s)
    {
        AudioClip a=null;
        switch (s)
        {
            case "调查": a = 调查; break;
            case "交互": a = 交互; break;
            case "交互失败": a = 交互失败; break;
            case "组合": a = 组合; break;
            case "交谈":a = 交谈;break;
        }
        return a;
    }
}
