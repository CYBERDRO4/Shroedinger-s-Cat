using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlImpulse : MonoBehaviour
{
    bool bowlistouched;
    private Vector2 punchdirection;
    [SerializeField] private int countOfContacts;
    private int contacts;
    [SerializeField] private float punchPower;
    [SerializeField] private GameEvent BowlIsTouched;

    IEnumerator DecelerationRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<Rigidbody2D>().velocity -= new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x / 3, gameObject.GetComponent<Rigidbody2D>().velocity.y / 3);
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<Rigidbody2D>().velocity -= new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x / 3, gameObject.GetComponent<Rigidbody2D>().velocity.y / 3);
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        contacts = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        contacts++;
        gameObject.GetComponent<Rigidbody2D>().velocity -= new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x / countOfContacts, gameObject.GetComponent<Rigidbody2D>().velocity.y / countOfContacts);
        if (contacts > countOfContacts - 1)
        {
            StartCoroutine(DecelerationRoutine());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        bowlistouched = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bowlistouched = true;
        BowlIsTouched.Raise();
    }
    private void PunchBowl(Transform wherethepuncher, string puncherstag)
    {
        if (bowlistouched)
        {
            contacts = 0;
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            Punch(wherethepuncher);
            Debug.Log("Ударяющий имеет тег - " + puncherstag);
            CheckTag(puncherstag);
        }
    }
    private void Punch(Transform wherethepuncher)
    {
        ToDirectAVelocity(CheckDirection(wherethepuncher));
    }
    private Vector2 CheckDirection(Transform wherethepuncher)
    {
        punchdirection = -(wherethepuncher.position - gameObject.GetComponent<Transform>().position)/ (wherethepuncher.position - gameObject.GetComponent<Transform>().position).magnitude;
        return punchdirection;
    }
    private void ToDirectAVelocity(Vector2 punchersdirection)
    {
        gameObject.GetComponent<Rigidbody2D>().velocity += new Vector2(punchersdirection.x * punchPower, punchdirection.y * punchPower);
    }
    //Предыдущая версия удара
    //private void PunchBowl(Transform wherethepuncher)
    //{
    //    CheckDirection(wherethepuncher);
    //}
    //private void CheckDirection(Transform wherethepuncher)
    //{
    //    int x = 0;
    //    int y = 0;
    //    //направление по x
    //    {
    //        if (wherethepuncher.position.x < gameObject.GetComponent<Transform>().position.x)
    //        {
    //            x = 1;
    //        }
    //        else if (wherethepuncher.position.x > gameObject.GetComponent<Transform>().position.x)
    //        {
    //            x = -1;
    //        }
    //        else if (wherethepuncher.position.x == gameObject.GetComponent<Transform>().position.x)
    //        {
    //            x = 0;
    //        }
    //    }
    //    //направление по y
    //    {
    //        if (wherethepuncher.position.y < gameObject.GetComponent<Transform>().position.y)
    //        {
    //            y = 1;
    //        }
    //        else if (wherethepuncher.position.y > gameObject.GetComponent<Transform>().position.y)
    //        {
    //            y = -1;
    //        }
    //        else if (wherethepuncher.position.y == gameObject.GetComponent<Transform>().position.y)
    //        {
    //            y = 0;
    //        }
    //    }
    //    ToDirectAVelocity(wherethepuncher, x, y);
    //}
    //private void ToDirectAVelocity(Transform wherethepuncher, int x, int y)
    //{
    //    float _x = gameObject.GetComponent<Transform>().position.x;
    //    float _y = gameObject.GetComponent<Transform>().position.y;
    //    gameObject.GetComponent<Rigidbody2D>().velocity += new Vector2(x * Math.Abs(punchPower - Math.Abs(_y - wherethepuncher.position.y)), y * Math.Abs(punchPower - Math.Abs(_x - wherethepuncher.position.x)));
    //}





    private void CheckTag(string puncherstag)
    {
        switch (puncherstag)
        {
            case "Player":
                Debug.Log("тронул Кот");
            
                break;
            case "Bird'sBoss":
                Debug.Log("тронул БоссПтиц");
                break;
        }
    }

    
    private void Awake()
    {
        EventManager.WhereThePuncher += PunchBowl;
    }
    private void OnDestroy()
    {
        EventManager.WhereThePuncher -= PunchBowl;
    }
}
