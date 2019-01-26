using Interfaces;
using UnityEngine;

namespace Monobeh.Item
{
    public class TargetItem : MonoBehaviour, ITargetObject
    {
        [SerializeField] 
        private int Id;
        
        [SerializeField]
        private IGlow GlowEffect;

        private void Start()
        {
            GlowEffect = GetComponentInChildren<IGlow>(true);
        }

        public void Glow(bool enable)
        {
            if (enable)
            {
                GlowEffect.StartAndPlay();
                return;
            }
            
            GlowEffect.DefaultEndDisable();
        }

        public void Grab()
        {
            //move to ui
        }
    }
}
