using DataStructures;
using DefaultNamespace;
using Interfaces;
using UnityEngine;

namespace Monobeh.Item
{
    public class TargetItem : MonoBehaviour, ITargetObject
    {
        [SerializeField] 
        private ItemData ItemData;
        
        [SerializeField]
        private IGlow GlowEffect;

        [SerializeField] 
        private SpriteRenderer SpriteRenderer;

        private void Start()
        {
            if (ItemData.Image == null)
            {
                ItemData.Image = SpriteRenderer.sprite;
            }
            else
            {
                SpriteRenderer.sprite = ItemData.Image;
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
            
            DependencyManager.Get<IItemPreview>().Show(ItemData.Image);
            //move to ui
        }

        public Sprite ObjectSprite => ItemData.Image;
    }
}
