namespace Assignment.Exercise_2;

// ---- Skills ----

public interface ISkill
{
	public string Name { get; }
	public int ApplyTo(int baseDamage);
}

public class FireSkill : ISkill
{
	public string Name { get; } = "Fire";
	public int ApplyTo(int baseDamage) => baseDamage + 10;
}

public class IceSkill : ISkill
{
	public string Name { get; } = "Ice";
	public int ApplyTo(int baseDamage) => baseDamage + 5;
}

public class PoisonSkill : ISkill
{
	public string Name { get; } = "Poison";
	public int ApplyTo(int baseDamage) => baseDamage + 2;
}

// ---- Skill system ----

public class SkillSystem
{
	public SkillSystem(IEnumerable<ISkill> skills)
	{
		skillDict = skills.ToDictionary(skill => skill.Name);
	}

	private readonly Dictionary<string, ISkill> skillDict;
	
	public int ApplySkill(string skillType, int baseDamage)
	{
		if (skillDict.TryGetValue(skillType, out var skill))
		{
			return skill.ApplyTo(baseDamage);
		}
		else return baseDamage;
	}
}

// ---- Program entry point ----

public class Program
{
	public static void EntryPoint()
	{
		int baseDamage = 10;
		SkillSystem skillSystem = new SkillSystem([
			new FireSkill(),
			new IceSkill(),
			new PoisonSkill()
		]);
		
		Console.WriteLine($"Base damage is {baseDamage}");
		Console.WriteLine($"Poison skill deals {skillSystem.ApplySkill("Poison", baseDamage)}");
		Console.WriteLine($"Fire skill deals {skillSystem.ApplySkill("Fire", baseDamage)}");
		Console.WriteLine($"Ice skill deals {skillSystem.ApplySkill("Ice", baseDamage)}");
		Console.WriteLine($"Explosion skill deals {skillSystem.ApplySkill("Explosion", baseDamage)}");
	}
}