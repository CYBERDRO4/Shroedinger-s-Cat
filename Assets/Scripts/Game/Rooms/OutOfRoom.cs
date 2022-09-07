using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfRoom : MonoBehaviour
{
    [SerializeField] private GameEvent OfRoom;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            OfRoom.Raise();
        }
    }
}
