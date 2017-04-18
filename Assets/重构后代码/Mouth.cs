using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouth : MonoBehaviour {
    float 身高;
    private void Start()
    {
        BoxCollider bc = GetComponent<BoxCollider>();
        if (bc != null)
        {
            身高 = bc.center.y + bc.size.y / 2+0.3f;
        }else
        {
            BoxCollider2D bc2 = GetComponent<BoxCollider2D>();
            身高 = bc2.offset.y + bc2.size.y / 2 + 0.3f;
        }
    }
    public Vector3 GetLogPosition()
    {
        return (transform.position+Vector3.up*身高);
    }
}
