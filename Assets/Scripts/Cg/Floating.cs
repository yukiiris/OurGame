using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour {
	public float y = 0.01f;
	public float bound1 = 0.25f;
	public float bound2 = -0.25f;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, y, 0);
        if (transform.position.y > bound1 || transform.position.y < bound2)
        {
            y = y * (-1);
        }
    }

}
