using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entity
{
    abstract internal class HelperComponentBase
    {
        public GameObject GameObject { get; private set; }

        public void AssignParent(GameObject gameObject)
        {
            if (GameObject != null)
                throw new Exception("Parent game object has already been assigned");

            GameObject = gameObject;
        }
    }
    interface IComponent
    {
        void AssignParent(GameObject gameObject);
        GameObject GameObject { get; }
        void Start() { }
        void Update() { }
    }
}
