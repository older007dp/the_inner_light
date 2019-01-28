using System;
using DataStructures;
using UnityEngine;

namespace Interfaces
{
    public interface IPlayerManager
    {
        bool CanInteractive { get; set; }

        event Action TryToCatchItem;

        void AddItemToInventory(ITargetObject targetObject);
        ItemData ItemData { get; set; }

        void ItemPaced(int id);
    }
}
