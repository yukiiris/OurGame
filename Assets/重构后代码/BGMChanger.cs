using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMChanger : MonoBehaviour {
    public AudioClip target;
    public float delay=0;
    // Use this for initialization
	void Start () {
        StartCoroutine(delayAndChangeBGM(delay));

    }
    IEnumerator delayAndChangeBGM(float f)
    {
        yield return new WaitForSeconds(f);
        AudioSystem.current.BGM.clip = target;
        AudioSystem.current.BGM.loop = true;
        AudioSystem.current.BGM.Play();
    }
}
