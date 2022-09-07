using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnimator : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D _rigidbody;
    bool playerLeft;
    bool playerRight;
    private void Start()
    {
        playerRight = true;
        anim = GetComponent<Animator>();
        _rigidbody = transform.GetComponent<Rigidbody2D>();
        anim.SetBool("CatIsSleep", false);
    }

    private void Update()
    {
        anim.SetFloat("velocity.y", _rigidbody.velocity.y);
        if (_rigidbody.velocity.x < 0 && playerLeft == false)
        {
            playerRight = false;
            playerLeft = true;
            gameObject.transform.Rotate(0, 180, 0);
        }
        if (_rigidbody.velocity.x > 0 && playerRight == false)
        {
            playerLeft = false;
            playerRight = true;
            gameObject.transform.Rotate(0, -180, 0);
        }
        if (anim.GetFloat("velocity.y") != 0)
            anim.SetBool("isRunning.y", true);
        else
            anim.SetBool("isRunning.y", false);
        if (_rigidbody.velocity.x != 0)
            anim.SetBool("isRunning.x", true);
        else
            anim.SetBool("isRunning.x", false);
    }

    public void Death()
    {
        anim.SetBool("CatIsSleep", true);
    }

    public void PunchActivateAnim()
    {
        anim.SetBool("PunchIsActive", true);
    }
    public void PunchDeactivateAnim()
    {
        anim.SetBool("PunchIsActive", false);
    }
}
