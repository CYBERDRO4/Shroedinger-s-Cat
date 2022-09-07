using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.AI
{
    [CreateAssetMenu(menuName ="Data/Band", fileName ="New band")]
    public class BandData : EnemyData
    {
        #region fields
        [SerializeField] private Enemy _single; // Экземлпяр врага в единичном представлении
        [SerializeField] private int _membersCount; // кол-во членов банды (птиц в стае)
        [SerializeField] private int _hitsForKnock; // кол-во попаданий для выбивания одного члена
        [SerializeField] private Vector2 _offset; // расстояние между членами
        #endregion
        #region properties
        public Enemy single { get { return _single; } }
        public int membersCount { get { return _membersCount; } }
        public int hitsForKnock { get { return _hitsForKnock; } }
        public Vector2 offset { get { return _offset; } }
        #endregion
    }
}
