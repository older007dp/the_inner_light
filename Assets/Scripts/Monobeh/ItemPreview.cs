using DefaultNamespace;
using DG.Tweening;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Monobeh
{
    public class ItemPreview : MonoBehaviour, IItemPreview
    {
        [SerializeField]
        private Image Parent;

        [SerializeField]
        private Image Image;

        private Sprite SpriteToShow;
        private IPlayerManager PlayerManager => DependencyManager.Get<IPlayerManager>();

        private void Awake()
        {
            DependencyManager.Add<IItemPreview>(this);
        }

        private void Start()
        {
            Default();
        }

        public void Show(Sprite sprite)
        {
            PlayerManager.CanInteractive = false;
            SpriteToShow = sprite;
            Parent.gameObject.SetActive(true);
            Parent.DOColor(Color.black, 0.45f).OnComplete(OnComplete);
        }

        private void OnComplete()
        {
            Image.gameObject.SetActive(true);
            Image.rectTransform.DOLocalRotate(new Vector3(0, 0, Random.Range(-30, 30)), 0.1f);
            Image.sprite = SpriteToShow;
            Image.DOColor(Color.white, 0.1f);
            Invoke("AfterShow", 3f);
        }

        private void AfterShow()
        {
            PlayerManager.CanInteractive = true;

            Default();
        }

        private void Default()
        {
            Image.sprite = null;
            Image.color = Color.clear;
            Image.gameObject.SetActive(false);
            
            Parent.color = Color.clear;
            Parent.gameObject.SetActive(false);
        }
    }
}
