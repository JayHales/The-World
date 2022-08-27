using ConsoleApp1.Entity.Utility;
using System.Numerics;

namespace ConsoleApp1.Entity.Mobs
{
    internal abstract class Mob : GameObject
    {
        public Mob()
        {
            AddComponent<Transform>();
            AddComponent<MobAI>();
        }

        class MobAI : HelperComponentBase, IComponent
        {
            private static readonly float visionRange = 5f;


            public void Start()
            {
                Console.WriteLine("Mob starting!");
            }

            public void Update()
            {

            }

        }
    }
}
