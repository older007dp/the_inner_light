using Core.CollectionCreator.ConcreteCollectionCreators;
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
            
            DI.Get<IItemPreview>().Show(ItemData.Image);
            DI.Get<ItemCollectionCreator>().AddData(ItemData);
            //move to ui
            Destroy(gameObject);
        }

        public Sprite ObjectSprite => ItemData.Image;
    }
}
