using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leg : MonoBehaviour {
    public float speed = 4;
    public float speedDelta = 0.5f;
    bool facingLeft;//脸的朝向

    public Rigidbody2D rigi;
    public Animator anim;//动画


    bool isMove = false;//是否移动
    int isRight = 1;//速度方向，要乘到速度上
    float moveToX;

    void Awake()
    {
        rigi = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponentInChildren<Animator>();
        isMove = false;
    }

    void Update()
    {
        if (GameSystem.isMoving)
        {
            if (isMove)//如果还在运动
            {
                if (System.Math.Abs(rigi.position.x - moveToX) < 0.1f)//当行走到鼠标点击坐标附近
                {
                    setMoveStation(false);
                }
                if (rigi.velocity.x * isRight < speed)
                {
                    rigi.velocity += new Vector2(isRight * speedDelta, 0);//加一个速度
                }
            }
            else//减速
            {
                if (System.Math.Abs(rigi.velocity.x) > speedDelta)
                {
                    rigi.velocity -= new Vector2(((rigi.velocity.x > 0) ? 1 : -1) * speedDelta, 0);
                }
                else
                {
                    rigi.velocity = Vector2.zero;
                }
            }
        }else
        {
            rigi.velocity = Vector2.zero;
        }
    }

    public void MoveTo(float x)
    {
        if (GameSystem.isMoving)
        {
            setMoveStation(true);
            isRight = (rigi.transform.position.x - x < 0) ? 1 : -1;
            if ((rigi.transform.position.x - x < 0) == facingLeft) Turn();
            moveToX = x;
        }
    }

    public void Turn()
    {
        facingLeft = !facingLeft;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        SingleLog s = GetComponentInChildren<SingleLog>();
        if (s != null)
        {
            Vector3 ss = s.transform.localScale;
            ss.x *= -1;
            s.transform.localScale = ss;
        }
    }
    public void setMoveStation(bool b)
    {
        isMove = b;
        anim.SetBool("isMove", b);
    }
}
