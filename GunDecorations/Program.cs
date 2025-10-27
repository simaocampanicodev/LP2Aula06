using System;
using GunDecorations.bin;

namespace GunDecorations
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Gun gun = new MachineGun();
            gun = new GunClip(new GunSilencer(gun));

            gun.Fire();
        }
    }
}
