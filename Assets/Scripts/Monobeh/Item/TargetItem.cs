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
        public ItemData ItemData;
        
        [SerializeField]
        private IGlow GlowEffect;

        private void Start()
        {
            GlowEffect = GetComponentInChildren<IGlow>(true);
        }

        public int Id => ItemData.Id;

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
            
            gameObject.SetActive(false);
            //move to ui
            GlowEffect.DefaultEndDisable();
        }
    }
}
