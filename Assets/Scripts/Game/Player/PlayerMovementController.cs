using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    public sealed class PlayerMovementController : PlayerController
    {
        private Rigidbody2D _rigidbody;
        private Vector2 _velocity; // Векторная величина скорости. Скалярная величина скорости - длина этого вектора

        
        public float speedMultiplicator => this.GetComponent<CatsData.Cat>().Data.speedMultiplicator;
        void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        private void FixedUpdate()
        {
            _rigidbody.velocity = _velocity * speedMultiplicator;
        }

        private void Update()
        {
            Move(CheckInputs());

        }
        private void Move(Vector2 direction)
        {

            _velocity.x = direction.x;
            _velocity.y = direction.y;

            if (_velocity.x != 0 && _velocity.y != 0) // Выравнивание скорости при движении по диагонали
            {
                _velocity.x /= Constants.SQRT2;
                _velocity.y /= Constants.SQRT2;
            }

            Time.timeScale = _velocity.x != 0 || _velocity.y != 0 ? 1 : 0;


        }

        private Vector2 CheckInputs()
        {
            Vector2 direction = _input.Movement.Walking.ReadValue<Vector2>();
            return direction;

        }

        protected override void InitialiseInput()
        {
            _input = new PlayerInputActions();
        }
    }
}
