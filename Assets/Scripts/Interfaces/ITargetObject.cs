using UnityEngine;

namespace Interfaces
{
    public interface ITargetObject
    {
        void Glow(bool enable);
        void Grab();
        Sprite ObjectSprite { get; }
    }
}
