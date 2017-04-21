using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : MonoBehaviour {
    public AudioClip 调查;
    public AudioClip 交互;
    public AudioClip 交互失败;
    public AudioClip 组合;
    public AudioClip 交谈;
    public AudioClip[] BGM;
    AudioSource aus;
    static public AudioSystem current;
    public AudioSource BGMSource;
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
    static public void ChangeBGM(string bgmName,float delay=0,bool ifloop=true)
    {
        current.StartCoroutine(current.delayAndChangeBGM(current.StringToAudio(bgmName),delay, ifloop));
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
            case "BGM0": a = BGM[0]; break;
            case "BGM1": a = BGM[1]; break;
            case "BGM2": a = BGM[2]; break;
            case "BGM3": a = BGM[3]; break;
            case "BGM4": a = BGM[4]; break;
            case "BGM5": a = BGM[5]; break;
            case "BGM6": a = BGM[6]; break;
            case "BGM7": a = BGM[7]; break;
        }
        return a;
    }
    IEnumerator delayAndChangeBGM(AudioClip target, float f, bool ifloop)
    {
        yield return new WaitForSeconds(f);
        current.BGMSource.clip = target;
        current.BGMSource.loop = ifloop;
        current.BGMSource.Play();
    }
}
