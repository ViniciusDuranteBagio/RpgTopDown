using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Animations
{
    Idle = 0,
    Walking = 1,
    Running = 2,
}

public class PlayerAnim : MonoBehaviour
{

    private Player player;
    private Animator anim;


    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        OnMove();
        OnRun();
    }

    #region Movement
    void OnMove()
    {
        SetAnimationTransition();
        FlipPlayerSprite();

        if (player.isCutting)
        {
            anim.SetInteger("transition", 3);
        }
    }

    void SetAnimationTransition() 
    {
        if (player.direction.sqrMagnitude > 0)
        {
            if (player.isRolling)
            {
                //ver como passar esse isRoll para um enum
                anim.SetTrigger("IsRoll");
            }
            else
            {
                anim.SetInteger("transition", (int) Animations.Walking);
            }
        }
        else
        {
            anim.SetInteger("transition", 0);
        }
    }
    void FlipPlayerSprite()
    {
        if (player.direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (player.direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }

    void OnRun()
    {
        if (player.isRunning)
        {
            anim.SetInteger("transition", (int) Animations.Running);
        }
    }
    #endregion
}
