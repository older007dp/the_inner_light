using DataStructures;
using DefaultNamespace;
using DefaultNamespace.Interfaces;
using Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace System.Collections.Generic
{
    public class ItemView : MonoBehaviour, IDataSetter<ItemData>
    {
        [SerializeField] private ItemData Data;
        [SerializeField] private Image Image;
        [SerializeField] private Button Button;

        public void SetData(ItemData data)
        {
            Button.onClick.AddListener(OnPointerClick);
            Data = data;

            if (Image != null)
            {
                Image.sprite = Data.PreviewImage;
            }
        }


        public void OnPointerClick()
        {
            DI.Get<IPlayerManager>().ItemData = Data;
        }
    }
}