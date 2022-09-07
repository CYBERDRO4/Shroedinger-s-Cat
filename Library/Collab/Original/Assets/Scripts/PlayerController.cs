using UnityEngine;

namespace Game.Player
{
    public sealed class PlayerController : MonoBehaviour
    {
        private Rigidbody2D _rb;
        private Vector2 _velocity; // Векторная величина скорости. Скалярная величина скорости - длина этого вектора

        [Tooltip("Множитель скорости")][SerializeField] private float _acceleration; 
        public float acceleration => _acceleration;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            CheckInputs();
        }

        private void FixedUpdate()
        {
            _rb.velocity = _velocity * acceleration;
        }

        private void CheckInputs()
        {
            _velocity.x = Input.GetAxisRaw("Horizontal");
            _velocity.y = Input.GetAxisRaw("Vertical");

            if (_velocity.x != 0 && _velocity.y != 0) // Выравнивание скорости при движении по диагонали
            {
                _velocity.x /= Constants.SQRT2;
                _velocity.y /= Constants.SQRT2;
            }
        }
    }
}
