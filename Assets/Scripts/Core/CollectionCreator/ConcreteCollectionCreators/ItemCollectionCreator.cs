using System.Collections.Generic;
using DataStructures;
using DefaultNamespace;

namespace Core.CollectionCreator.ConcreteCollectionCreators
{
    public class ItemCollectionCreator : CollectionCreator<ItemData, ItemView>
    {
        protected override void Init()
        {
            base.Init();
            DI.Add<ItemCollectionCreator>(this);
        }
    }
}