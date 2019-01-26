using System.Collections.Generic;
using Core.Collections;
using DefaultNamespace.Interfaces;
using UnityEngine;

namespace Core.CollectionCreator
{
    public class CollectionCreator<TData, TView> : MonoBehaviour where TView : MonoBehaviour, IDataSetter<TData>
    {
        [SerializeField] private bool CleanOnAwake;
        [SerializeField] private TView Prefab;
        [SerializeField] private Transform Parent;

        private List<TView> TakenViews = new List<TView>();
        private List<TView> PoolOfViews = new List<TView>();
        private Dictionary<TData, TView> DataViewDictionary = new Dictionary<TData, TView>();

        public void SetData(IEnumerable<TData> datas)
        {
            foreach (var item in datas)
            {
                if (!DataViewDictionary.ContainsKey(item))
                {
                    if (PoolOfViews.Count > 0)
                    {
                        PoolOfViews[0].SetData(item);
                        DataViewDictionary.Add(item, PoolOfViews[0]);
                        PoolOfViews[0].gameObject.SetActive(true);
                        PoolOfViews.RemoveAt(0);
                    }

                    var newView = Instantiate<TView>(Prefab);
                    DataViewDictionary.Add(item, newView);
                    BeforeActivate(newView);
                    newView.SetData(item);
                    newView.gameObject.SetActive(true);
                }
            }

            var dataList = new List<TData>(datas);
            var dataToRemove = new List<TData>();

            foreach (var item in DataViewDictionary)
            {
                if (!dataList.Contains(item.Key))
                {
                    dataToRemove.Add(item.Key);
                }
            }

            foreach (var item in dataToRemove)
            {
                DataViewDictionary[item].gameObject.SetActive(false);
                DataViewDictionary.Remove(item);
            }
        }

        public void AddData(TData data)
        {
            var newDatas = new List<TData>(DataViewDictionary.Keys);
            newDatas.Add(data);

            SetData(newDatas);
        }

        public void RemoveData(TData data)
        {
            var newDatas = new List<TData>(DataViewDictionary.Keys);
            newDatas.Remove(data);

            SetData(newDatas);
        }

        private void BeforeActivate(TView view)
        {
            view.transform.SetParent(Parent);
            view.transform.localScale = Vector3.one;
        }

        private void Awake()
        {
            if (CleanOnAwake)
            {
                transform.CleanChildren();
            }
        }
    }
}