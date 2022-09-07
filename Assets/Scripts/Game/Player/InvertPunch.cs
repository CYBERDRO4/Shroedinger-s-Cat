using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertPunch : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private bool IsPunchUp;
    private bool IsPunchDown;
    void Start()
    {
        _rigidbody = transform.parent.GetComponent<Rigidbody2D>();
        IsPunchDown = true;
    }

    void Update()
    {
        if (_rigidbody.velocity.y > 0)
            PunchUp();
        else if (_rigidbody.velocity.y < 0)
            PunchDown();
    }
    private void PunchUp()
    {
        if (IsPunchUp == false)
        {
            IsPunchDown = false;
            IsPunchUp = true;
            gameObject.transform.Rotate(180, 0, 0);
        }
    }
    private void PunchDown()
    {
        if( IsPunchDown == false )
        {
            IsPunchUp = false;
            IsPunchDown = true;
            gameObject.transform.Rotate(-180, 0, 0);
        }
    }
}
