using System.Collections.Generic;
using DefaultNamespace;
using Interfaces;
using UnityEngine;

namespace Monobeh.Player
{
    public class PlayerTarget : MonoBehaviour
    {
        [SerializeField] private List<string> TargetTags = new List<string>();
        [SerializeField] private List<ITargetObject> ObjectsInTarget = new List<ITargetObject>();

        private IPlayerManager PlayerManager => DependencyManager.Get<IPlayerManager>();
        private void Start()
        {
            PlayerManager.TryToCatchItem += TryToCatchItem;
        }

        private void TryToCatchItem()
        {
            if (ObjectsInTarget.Count > 0)
            {
                var target = ObjectsInTarget[0];

                if (target == null)
                {
                    return;
                }
                
                PlayerManager.AddItemToInventory(target);
                ObjectsInTarget.Remove(target);
                
                target.Grab();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.LogWarning(other.tag);
            
            if (TargetTags.Contains(other.tag))
            {
                var targetObj = other.GetComponent<ITargetObject>();

                if (targetObj == null)
                {
                    return;
                }
                
                targetObj.Glow(true);
                
                ObjectsInTarget.Add(targetObj);
            }
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (TargetTags.Contains(other.tag))
            {
                var targetObj = other.GetComponent<ITargetObject>();

                if (targetObj == null)
                {
                    return;
                }
                
                targetObj.Glow(false);
                
                ObjectsInTarget.Remove(targetObj);
            }
        }
    }
}
