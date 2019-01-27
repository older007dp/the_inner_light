using System.Collections;
using System.Collections.Generic;
using Core.CollectionCreator.ConcreteCollectionCreators;
using DefaultNamespace;
using Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemPlace : MonoBehaviour, IItemPlace
{
    [SerializeField] private int ItemId;
    [SerializeField] private GameObject TargetGameObject;

    private void Awake()
    {
        TargetGameObject.SetActive(false);
    }

    public bool PlaceItem(ITargetObject item)
    {
        TargetGameObject.SetActive(item.Id.Equals(ItemId));
        
        return item.Id.Equals(ItemId);
    }

    private void MoveObjectToTarget()
    {
        
    }

    private void OnMouseDown()
    {
        var data = DI.Get<IPlayerManager>().ItemData;

        if (data == null)
        {
            return;
        }

        if (data.Id.Equals(ItemId))
        {
            TargetGameObject.SetActive(true);
            
            DI.Get<ItemCollectionCreator>().RemoveData(data);
            DI.Get<IPlayerManager>().ItemPaced();
        }
    }
}
