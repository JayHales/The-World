using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entity.Mobs
{
    internal class Orc : Mob
    {
        public Orc()
        {
            AddComponent<OrcAI>();
        }

        internal class OrcAI : HelperComponentBase, IComponent
        {
            public void Update()
            {
                if (new Random().NextSingle() == 0f)
                {
                    Console.WriteLine($"Growl {GameObject.Guid}");
                }
            }
        }
    }
}
