using Game.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOutOfOrder : MonoBehaviour
{
    [SerializeField] private int milliseconds;
    private float seconds;
    private PlayerMovementController walk;
    private PlayerPunch punch;
    private Rigidbody2D _rigidbody;

    private IEnumerator Calloutine()
    {
        EffectActivate();
        yield return new WaitForSeconds(seconds);
        EffectDeactivate();
    }

    private void Start()
    {
        _rigidbody = transform.parent.GetComponent<Rigidbody2D>();
        seconds = milliseconds * 1000;
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
        _rigidbody.velocity = new Vector2(0, 0);
        walk.enabled = false;
        walk.enabled = false;
    }
    private void EffectDeactivate()
    {
        walk.enabled = true;
        walk.enabled = true;
    }
}
