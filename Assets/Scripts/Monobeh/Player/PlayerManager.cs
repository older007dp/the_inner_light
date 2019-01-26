using System;
using System.Collections.Generic;
using DefaultNamespace;
using Interfaces;
using UnityEngine;

namespace Monobeh.Player
{
    public class PlayerManager : MonoBehaviour, IPlayerManager
    {
        public bool CanInteractive 
        {
            get => PlayerInteractive;
            set => PlayerInteractive = value;
        }

        public Action TryToCatchItem { get; set; }
        
        private bool PlayerInteractive = true;

        [SerializeField] 
        private int ItemsCount = 0;
        
        [SerializeField] 
        private float Speed;
        
        [SerializeField]
        private Rigidbody2D CharacterController;

        [SerializeField]
        private PlayerTarget PlayerTarget;

        [SerializeField] private List<ITargetObject> Inventory = new List<ITargetObject>();

        private void Awake()
        {
            DependencyManager.Add<IPlayerManager>(this);
        }

        private void Update()
        {
            if (!PlayerInteractive)
            {
                return;
            }
            
            Movement();
            SomeAction();
        }

        private void SomeAction()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                TryToCatchItem?.Invoke();
            }
        }

        private void Movement()
        {


            var xAxis = Input.GetAxis("Horizontal");
            var yAxis = Input.GetAxis("Vertical");
        
            var moveVector = new Vector2(xAxis, yAxis);

            CharacterController.velocity = moveVector * Speed;
        }

        public void AddItemToInventory(ITargetObject targetObject)
        {
            Inventory.Add(targetObject);

            ItemsCount = Inventory.Count;
        }
    }
}
