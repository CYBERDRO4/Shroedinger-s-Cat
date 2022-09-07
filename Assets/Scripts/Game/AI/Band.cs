using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.AI
{
    public class Band : Enemy
    {
        [SerializeField] private BandData _bandData;

        private int _hits;

        private Queue<Enemy> _members;
        public BandData bandData { get { return _bandData;} }

        private void Start()
        {
            _members = new Queue<Enemy>();
        }

        public override void GetHit()
        {
            if (_hits >= _bandData.hitsForKnock) {
                var enemy = _members.Dequeue();
                Destroy(enemy);
                if (_members.Count == 0)
                {
                    Debug.Log($"Band has been destroyed {gameObject.name}");
                    Destroy(this);
                }
                _hits = 0;
            }
        }
    }
}
