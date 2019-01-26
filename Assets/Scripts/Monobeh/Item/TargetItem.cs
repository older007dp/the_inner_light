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

        [SerializeField] 
        private SpriteRenderer SpriteRenderer;

        [SerializeField] 
        private Sprite TargetSprite;

        private void Start()
        {
            if (TargetSprite == null)
            {
                TargetSprite = SpriteRenderer.sprite;
            }

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

        public Sprite ObjectSprite => TargetSprite;
    }
}
