using System.Collections;
using System.Collections.Generic;

namespace Core.Collections
{
    public abstract class DictionaryBase<TKey, TValue> : IDictionary<TKey, TValue>
    {
        protected Dictionary<TKey, TValue> RealDictionary = new Dictionary<TKey, TValue>();

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return RealDictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            RealDictionary.Clear();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return RealDictionary.ContainsKey(item.Key);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            if (RealDictionary.ContainsKey(item.Key))
            {
                return false;
            }

            OnRemove(item.Key, item.Value);
            RealDictionary.Remove(item.Key);

            return true;
        }

        public int Count => RealDictionary.Count;
        public bool IsReadOnly => false;

        public void Add(TKey key, TValue value)
        {
            RealDictionary.Add(key, value);
            OnAdd(key, value);
        }

        public bool ContainsKey(TKey key)
        {
            return RealDictionary.ContainsKey(key);
        }

        public bool Remove(TKey key)
        {
            OnRemove(key);

            return RealDictionary.Remove(key);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return RealDictionary.TryGetValue(key, out value);
        }

        public TValue this[TKey key]
        {
            get => RealDictionary[key];
            set => RealDictionary[key] = value;
        }

        public virtual ICollection<TKey> Keys => RealDictionary.Keys;
        public virtual ICollection<TValue> Values => RealDictionary.Values;

        protected abstract void OnAdd(TKey key, TValue value);
        protected abstract void OnRemove(TKey key);
        protected abstract void OnRemove(TKey key, TValue value);
    }
}