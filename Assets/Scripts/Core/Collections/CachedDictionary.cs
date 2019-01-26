using System.Collections;
using System.Collections.Generic;

namespace Core.Collections
{
    public class CachedDictionary<TKey,TValue> : DictionaryBase<TKey, TValue>
    {
        private List<TKey> KeysCache = new List<TKey>();
        private List<TValue> ValuesCache = new List<TValue>();
        
        public List<TKey> KeysList => KeysCache;
        public List<TValue> ValuesList => ValuesCache;
        protected override void OnAdd(TKey key, TValue value)
        {
            KeysCache.Add(key);
            ValuesCache.Add(value);
        }

        protected override void OnRemove(TKey key)
        {
            KeysCache.Remove(key);

            if (RealDictionary.ContainsKey(key))
            {
                ValuesCache.Remove(RealDictionary[key]);
            }
        }

        protected override void OnRemove(TKey key, TValue value)
        {
            KeysCache.Remove(key);
            ValuesCache.Remove(value);
        }
    }
}