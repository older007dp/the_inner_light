using UnityEngine;

namespace System.Collections.Generic
{
    public static class UnityExtentions
    {
        public static void CleanChildren(this Transform transform)
        {
            var childCount = transform.childCount;

            for (int i = childCount - 1; i >= 0; i--)
            {
                var child = transform.GetChild(i);
                
                if (child.gameObject != null)
                {
                    UnityEngine.Object.Destroy(child.gameObject);
                }
            }
        }

        public static void CleanChildren(this GameObject go)
        {
            go.transform.CleanChildren();
        }
    }
}