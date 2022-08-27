namespace ConsoleApp1.Entity
{
    internal class GameObject
    {
        private readonly List<IComponent> components = new();
        public readonly Guid Guid;

        public GameObject()
        {
            Guid = Guid.NewGuid();
        }

        /// <summary>
        /// Instantiates and attatches the component provided to the game object.
        /// </summary>
        /// <typeparam name="T">The type of component. Must implement IComponent.</typeparam>
        /// <returns>The instantiated component.</returns>
        /// <exception cref="Exceptions.ComponentCollisionException">When two components of the same type are added.</exception>
        public T AddComponent<T>() where T : IComponent, new()
        {
            foreach (IComponent existingComponent in components)
            {
                if (existingComponent.GetType() == typeof(T))
                {
                    throw new Exceptions.ComponentCollisionException(typeof(T), existingComponent.GetType());
                }
            }

            T component = new();

            components.Add(component);

            component.AssignParent(this);

            return component;
        }

        /// <summary>
        /// Finds and returns the instance of the given component on the game object.
        /// </summary>
        /// <typeparam name="T">The type of component. Must implement IComponent.</typeparam>
        /// <returns>The component instance.</returns>
        /// <exception cref="Exceptions.MissingComponentException">When the component does not exist on the game object.</exception>
        public T GetComponent<T>() where T : IComponent
        {
            if (TryGetComponent(out T component))
            {
                return component;
            }

            throw new Exceptions.MissingComponentException(typeof(T));
        }

        /// <summary>
        /// Tries to find and return the given component.
        /// </summary>
        /// <typeparam name="T">The component which is being fetched.</typeparam>
        /// <param name="component">The component should the return value be true.</param>
        /// <returns>Whether or not the component exists on the game object.</returns>
        public bool TryGetComponent<T>(out T component) where T : IComponent
        {
            foreach (IComponent existingComponent in components)
            {
                if (existingComponent.GetType() == typeof(T))
                {
                    component = (T)existingComponent;
                    return true;
                }
            }

            component = default;
            return false;
        }

        public List<IComponent> AllComponents() => components;
    }


}
