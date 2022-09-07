using Game.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private PlayerMovementController walk;
    private PlayerPunch punch;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = transform.parent.GetComponent<Rigidbody2D>();
        walk = gameObject.transform.parent.GetComponent<PlayerMovementController>();
        punch = gameObject.transform.parent.GetComponent<PlayerPunch>();
    }
    public void CallActivateEffect()
    {
        EffectActivate();
    }
    public void CallDeactivateEffect()
    {
        EffectDeactivate();
    }
    private void EffectActivate()
    {
        _rigidbody.velocity = new Vector2(0,0);
        walk.enabled = false;
        //punch.enabled = false;
    }
    private void EffectDeactivate()
    {
        walk.enabled = true;
        //punch.enabled = true;
    }
}
