using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.AI
{
    public class Bird : Enemy
    {
        public override void GetHit()
        {
            if (eats == true)
            {
                Debug.Log("Hit to bird");
                //_visual.PlayDeathAnimation();
                _visual.PlayFlyAnimation();
                _timers.StartFoodSearchingTimer();
            }
        }
    }
}
