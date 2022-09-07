using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private GameEvent RemainderDistribution;

    public void AddFeedCount()
    {
        Bank.FeedBank._feedCount++;
    }

    public void AddRemainder()
    {
        Bank.FeedBank._remainder += Bank.FeedBank._feedCount;
        Bank.FeedBank._feedCount = 0;
        RemainderDistribution.Raise();
    }
}
