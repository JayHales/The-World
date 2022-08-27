using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Utility
{
    internal static class Exceptions
    {
        public class ComponentCollisionException : Exception
        {
            private readonly Type type1;
            private readonly Type type2;
            public ComponentCollisionException(Type type1, Type type2)
            {
                this.type1 = type1;
                this.type2 = type2;
            }
            public override string Message => $"Components {type1.Name} and {type2.Name} are incompatible";
        }

        public class MissingComponentException : Exception
        {
            private readonly Type type;
            public MissingComponentException(Type type)
            {
                this.type = type;
            }
            public override string Message => $"Could not find component ${type.Name}";
        }
    }
}
