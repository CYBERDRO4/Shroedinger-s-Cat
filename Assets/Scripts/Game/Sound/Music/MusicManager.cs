using UnityEngine;

namespace Game.Sound.Music
{
    public class MusicManager : MonoManager
    {
        [SerializeField] private AudioDistortionFilter _distortionFilter; 
        public AudioDistortionFilter distortionFilter => _distortionFilter;
    }
}
