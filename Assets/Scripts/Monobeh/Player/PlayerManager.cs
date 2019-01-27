﻿using System;
using System.Collections.Generic;
using DataStructures;
using DefaultNamespace;
using Interfaces;
using UnityEngine;
using UnityEngine.Playables;

namespace Monobeh.Player
{
    public class PlayerManager : MonoBehaviour, IPlayerManager
    {
        public bool CanInteractive 
        {
            get => PlayerInteractive;
            set => PlayerInteractive = value;
        }
        
        public event Action TryToCatchItem
        {
            add { TryToCatchItemCallback += value; }
            remove { TryToCatchItemCallback -= value; }
        }

        private event Action TryToCatchItemCallback;
        
        private bool PlayerInteractive = true;

        [SerializeField] 
        private int ItemsCount = 0;
        
        [SerializeField] 
        private float Speed;
        
        [SerializeField]
        private CharacterController CharacterController;

        [SerializeField]
        private PlayerTarget PlayerTarget;

        [SerializeField] 
        private Animator Animator;
        
        [SerializeField] 
        private List<ITargetObject> Inventory = new List<ITargetObject>();

        [SerializeField] private AudioSource AuDuio;
        [SerializeField] private AudioClip GrabClip;
        [SerializeField] private AudioClip PutClip;

        [SerializeField] private PlayableDirector PlayableDirector;
        
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
            DI.Get<FollowCamera>()?.NotifyPosition(transform.position);
        }

        private void SomeAction()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                TryToCatchItemCallback?.Invoke();
            }
        }

        private void Movement()
        {
            var xAxis = Input.GetAxis("Horizontal");
            var yAxis = Input.GetAxis("Vertical");
        
            var moveVector = new Vector3(xAxis, 0, yAxis);
            var zero = moveVector.Equals(Vector3.zero);
            
            CharacterController.Move(moveVector / 2);

            Animator.SetBool("Walk_forward", !zero);
            
            if(zero)
            {
                return;
            }
            
            CharacterController.transform.forward = moveVector;
        }

        public void AddItemToInventory(ITargetObject targetObject)
        {
            Inventory.Add(targetObject);

            ItemsCount = Inventory.Count;
            
            AuDuio.PlayOneShot(GrabClip);
        }

        public int ItemId { get; set; }
        public ItemData ItemData { get; set; }
        public int CoutnOfItem = 5;
        
        public void ItemPaced()
        {
            CoutnOfItem -= 1;

            AuDuio.PlayOneShot(PutClip);
            
            if (CoutnOfItem == 0)
            {
                GameOver();
            }
        }

        private void GameOver()
        {
            PlayableDirector.Play();
            Debug.LogWarning("GAME IS OVER");
        }
    }
}
