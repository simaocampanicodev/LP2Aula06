using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GunDecorations
{
    public abstract class GunDecorator : Gun
    {
        private readonly Gun decoratedGun;
        public override int AmmoCapacity => decoratedGun.AmmoCapacity;
        public override float NoiseLevel => decoratedGun.NoiseLevel;

        public GunDecorator(Gun gun)
        {
            decoratedGun = gun;
        }
    }
}