namespace Assignment.Exercise_3;
// ---- Entity component declaration ----

public interface IMovable
{
	public void Move();
}

// ---- Entity definition ----

public class GameEntity
{
}

public class Player : GameEntity, IMovable
{
	public void Move()
	{
		Console.WriteLine("Player moving");
	}
}

public class Wall : GameEntity
{
	// Wall can't move
}

// ---- Movement system ----

public class MovementSystem
{
	public void MoveEntity(IMovable entity)
	{
		entity.Move();
	}
}

// ---- Entry point ----

public static class Program
{
	public static void EntryPoint()
	{
		Player p = new Player();
		Wall w = new Wall();
		
		MovementSystem movementSystem = new MovementSystem();
		
		movementSystem.MoveEntity(p);
		// movementSystem.MoveEntity(w); // Compilation error
	}
}