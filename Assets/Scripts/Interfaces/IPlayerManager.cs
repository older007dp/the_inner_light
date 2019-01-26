using System;
using DataStructures;
using UnityEngine;

namespace Interfaces
{
    public interface IPlayerManager
    {
        bool CanInteractive { get; set; }

        Action TryToCatchItem { get; set; }

        void AddItemToInventory(ITargetObject targetObject);
        ItemData ItemData { get; set; }
    }
}
