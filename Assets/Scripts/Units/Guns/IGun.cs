
using System;

namespace Units.Guns
{
    public interface IGun
    {
        event Action EventReadyShoot;
        float SecondsReload { get; }
        void Shoot();
    }
}