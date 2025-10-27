using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GunDecorations
{
    public class GunClip : GunDecorator
    {
        public override int AmmoCapacity => base.AmmoCapacity + 20;
        public GunClip(Gun gun) : base(gun) { }
    }
}