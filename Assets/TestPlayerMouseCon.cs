using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerMouseCon : MonoBehaviour {
    private void Update()
    {
        if (Input.GetMouseButtonUp(1) && Camera.main.ScreenToWorldPoint(Input.mousePosition).y <= 0.5f)
        {
            Player.leg.MoveTo(Camera.main.ScreenToWorldPoint(Input.mousePosition).x);
        }
    }
}
