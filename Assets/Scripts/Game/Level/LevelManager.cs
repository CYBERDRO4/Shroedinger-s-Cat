using UnityEngine;

namespace Game.Level
{
    public class LevelManager : MonoManager
    {
        [SerializeField] private LevelGenerator _levelGenerator;

        public LevelGenerator levelGenerator => _levelGenerator;
    }
}
