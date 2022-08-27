using ConsoleApp1.Entity.Mobs;
using ConsoleApp1.Entity.Utility;
using Game;

var world = new World();

var orc = world.Spawn<Orc>();

orc.GetComponent<Transform>();

Console.WriteLine($"{world.GetComponents<Transform>().Count}");

world.Start();