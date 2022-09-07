using UnityEngine;

namespace Game.Player
{
    public abstract class PlayerController : MonoBehaviour
    {

        protected PlayerInputActions _input;

        private void Awake()
        {
            InitialiseInput();
        }

        private void OnEnable()
        {
            _input.Enable();
        }
        private void OnDisable()
        {
            _input.Disable();
        }
        protected virtual void InitialiseInput()
        {
            
        }



    }
}