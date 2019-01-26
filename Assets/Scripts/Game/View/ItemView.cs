using DataStructures;
using DefaultNamespace.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace System.Collections.Generic
{
    public class ItemView : MonoBehaviour, IDataSetter<ItemData>
    {
        [SerializeField] private ItemData Data;
        [SerializeField] private Image Image;

        public void SetData(ItemData data)
        {
            Data = data;

            if (Image != null)
            {
                Image.sprite = Data.Image;
            }
        }
    }
}