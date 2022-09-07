using UnityEngine;
using UnityEngine.Events;
using Game.Level;
using Game.Sound;
using Game.Sound.Music;
using Game.Utils;

namespace Game
{
    public class GameManager : MonoManager
    {
        [Header("Sub managers")]
        [SerializeField] private MusicManager _musicManager;
        [SerializeField] private SoundManager _SoundManager;
        [SerializeField] private LevelManager _levelManager;
        [Header("Events")]
        [SerializeField] private UnityEvent _onGameStart;
        [SerializeField] private UnityEvent _onGameStop;

        public MusicManager musicManager => _musicManager;
        public LevelManager levelManager => _levelManager;


        private void Awake()
        {
            Singletone<GameManager>.instance = this;
        }

        public void StartGame() {
            _onGameStart?.Invoke();
        }

        public void StopGame()
        {
            _onGameStop?.Invoke();
        }
    }
}
