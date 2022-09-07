using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    public static Action<Transform, string> WhereThePuncher;

    public static void SendWhereThePuncher(Transform wherethepuncher, string puncherstag)
    {
        if(WhereThePuncher != null)
            WhereThePuncher.Invoke(wherethepuncher, puncherstag);
    }
}
