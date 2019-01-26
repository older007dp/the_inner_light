using DG.Tweening;
using Interfaces;
using UnityEngine;

namespace Monobeh.Item
{
    public class GlowEffect : MonoBehaviour, IGlow
    {
        [SerializeField]
        private ParticleSystem ParticleSystem;

        [SerializeField] [Range(0, 1)] private float Max;
        
        private void Awake()
        {
            ParticleSystem = GetComponent<ParticleSystem>();

            DefaultEndDisable();
        }

        public void StartAndPlay()
        {
            ParticleSystem.Play();
        }

        public void DefaultEndDisable()
        {
            ParticleSystem.Stop();
        }
    }
}
