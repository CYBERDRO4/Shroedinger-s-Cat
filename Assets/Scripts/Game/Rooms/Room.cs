using Game.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Rooms
{
    public class Room : MonoBehaviour
    {
        public List<Feed> _food;
        public List<Feed> food => _food;

        private void Awake()
        {
            Singletone<Room>.instance = this;
            _food = new List<Feed>(FindObjectsOfType<Feed>());
            Debug.Log($"Food in room: {_food.Count}");
        }
    }
}