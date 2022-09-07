using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    public class PlayerPunch : PlayerController
    {
        [SerializeField] private GameEvent PunchIsActive;
        [SerializeField] private GameEvent PunchIsDeactive;
        bool canpunch = true;
        protected override void InitialiseInput()
        {
            _input = new PlayerInputActions();
            _input.Movement.Punch.performed += context => Punch();
        }

        public void PlayerCantPunch()
        {
            canpunch = false;
        }
        public void PlayerCanPunch()
        {
            canpunch = true;
        }

        private void Punch()
        {
            if(canpunch == true)
                StartCoroutine(PunchRoutine());
        }

        IEnumerator PunchRoutine()
        {
            canpunch = true;
            gameObject.GetComponent<EdgeCollider2D>().enabled = true;
            PunchIsActive.Raise();
            canpunch = false;
            yield return new WaitForSeconds(0.31f);
            gameObject.GetComponent<EdgeCollider2D>().enabled = false;
            yield return new WaitForSeconds(0.19f);
            PunchIsDeactive.Raise();
            canpunch = true;
        }
    }
}
