using UnityEngine;
using UnityEngine.UI;
using Game.Utils;

namespace Game.Developer
{
    public class DeveloperHud : MonoBehaviour
    {
        [SerializeField] private Slider _distortionSlider;
        [SerializeField] private InputField _iterations;
        [SerializeField] private InputField _lenght;

        public void SetDistortionLevel()
        {
            var musicManager = Singletone<GameManager>.instance.musicManager;
            musicManager.distortionFilter.distortionLevel = _distortionSlider.value;
        }
    }
}
