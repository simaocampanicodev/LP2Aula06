using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GunDecorations.bin
{
    public class GunSilencer : GunDecorator
    {
        public override float NoiseLevel => base.NoiseLevel - 10.0f;
        public GunSilencer(Gun gun) : base(gun) { }
    }
}