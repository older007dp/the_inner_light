using UnityEngine;

namespace Interfaces
{
    public interface ITargetObject
    {
        int Id { get; }
        void Glow(bool enable);
        void Grab();
    }
}
