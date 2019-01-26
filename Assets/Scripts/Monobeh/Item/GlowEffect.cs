using DG.Tweening;
using Interfaces;
using UnityEngine;

namespace Monobeh.Item
{
    public class GlowEffect : MonoBehaviour, IGlow
    {
        [SerializeField]
        private Light Light;

        [SerializeField] [Range(0, 1)] private float Max;

        private Tweener Tweener;
        
        private void Awake()
        {
            Light = GetComponent<Light>();
            Light.intensity = 0;
        }

        public void StartAndPlay()
        {
            Tweener = Light.DOIntensity(Max, 3.5f);
        }

        public void DefaultEndDisable()
        {
            Tweener.Kill();
            Tweener = Light.DOIntensity(0, 0.25f);
        }
    }
}
