using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.AI {
    [RequireComponent(typeof(Animator))]
    public class VisualBehaviour : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayIdleAnimation() {
            _animator.SetBool("eating", false);
            _animator.SetTrigger("idle");
        }
        public void PlayFlyAnimation() {
            _animator.SetBool("eating", false);
            _animator.SetTrigger("fly");
        }

        public void PlayEatingAnimation()
        {
            _animator.SetBool("eating", true);
            _animator.SetTrigger("eat");
        }

        public void PlayDeathAnimation() {
            _animator.SetBool("eating", false);
            _animator.SetTrigger("death");
        }
        

    }
}
