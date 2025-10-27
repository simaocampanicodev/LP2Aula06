using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GunDecorations
{
    public abstract class Gun
    {
        public abstract int AmmoCapacity { get; }
        public abstract float NoiseLevel { get; }

        public void Fire()
        {
            Console.WriteLine($"Ammo capacity = {AmmoCapacity}");
            Console.WriteLine($"Noise level   = {NoiseLevel}");
        }
    }
}