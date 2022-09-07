using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchedBowl : MonoBehaviour
{
    bool bowlistouched = false;
    public void PunchIsTouch()
    {
        if (bowlistouched == true)
            EventManager.SendWhereThePuncher(gameObject.transform, gameObject.tag);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Bowl"))
            bowlistouched = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Bowl"))
            bowlistouched = false;
    }
}
