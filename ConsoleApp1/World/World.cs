namespace ConsoleApp1.World
{
    internal class World
    {
        private readonly List<GameObject> gameObjects = new();

        public T Spawn<T>() where T : GameObject, new()
        {
            T newObject = new();

            gameObjects.Add(newObject);

            return newObject;
        }

        public List<T> GetComponents<T>() where T : IComponent
        {
            List<T> components = new();

            foreach (GameObject gameObject in gameObjects)
            {
                if (gameObject.TryGetComponent(out T component))
                {
                    components.Add(component);
                }
            }

            return components;
        }

        public void Start()
        {
            while (true)
            {
                Update();
            }
        }

        public void Update()
        {
            foreach (GameObject gameObject in gameObjects)
            {
                foreach (IComponent component in gameObject.AllComponents())
                {
                    component.Update();
                }
            }
        }
    }
}
