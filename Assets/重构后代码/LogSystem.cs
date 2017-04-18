using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogSystem : MonoBehaviour {
    public static GameObject log;
    public GameObject l;
    static bool isSpeakEnded = false;
    public static LogSystem current;
    private void Awake()
    {
        log = l;
        current = this;
    }
    public static int text格式化(string t,out string st)
    {
        string s = t;
        st = "";
        char[] co = s.ToCharArray();
        int d = 0;
        for (int i = 0; i < co.Length; i++)
        {
            if (i % 7 == 0&&i!=0)
            {
                st += "\n";
                d++;
            }
            st += co[i].ToString();
        }
        return d; 
    }
    public static void Speak(string s,NPC npc)
    {
        GameSystem.StopMove();
        GameObject l=GameObject.Instantiate(log, npc.mouth.GetLogPosition(), Quaternion.identity, npc.transform);
        l.GetComponent<SingleLog>().AutoFix(s);
        IfSpeakEnded();
        float seconds = s.Length * 0.1f;
        if(npc.animator!=null) current.StartCoroutine(current.Talk(npc.animator, seconds));
    }
    public static void Speak(string s, Player player)
    {
        GameSystem.StopMove();
        GameObject l = GameObject.Instantiate(log, player.mouth.GetLogPosition(), Quaternion.identity, player.mouth.transform);
        l.GetComponent<SingleLog>().AutoFix(s);
        float seconds = s.Length*0.1f;
        current.StartCoroutine(current.Talk(player.GetComponent<Animator>(), seconds));
    }
    IEnumerator Talk(Animator a, float s)
    {
        a.SetBool("isTalk", true);
        AudioSystem.current.Play("交谈");
        yield return new WaitForSeconds(s);
        a.SetBool("isTalk", false);
        AudioSystem.current.GetComponent<AudioSource>().Stop();
        yield return 0;
    }
    public static bool IfSpeakEnded()
    {
        bool b = isSpeakEnded;
        isSpeakEnded = false;
        return b;
    }
    public static void EndSpeak(SingleLog sl)
    {
        GameSystem.isMoving = true;
        isSpeakEnded = true;
        sl.Disappear();
    }

}
