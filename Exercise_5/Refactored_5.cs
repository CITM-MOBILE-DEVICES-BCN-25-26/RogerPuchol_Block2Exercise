namespace Assignment.Exercise_5;

// ---- Reward definition ----

public interface IReward
{
	public string RewardType { get; }
	public void GiveReward();
}

public class CoinReward : IReward
{
	public string RewardType { get; } = "Coins";
	public void GiveReward()
	{
		Console.WriteLine("Giving coins");
	}
}

public class ItemReward : IReward
{
	//Item pool, logic, etc. not implemented
	public string RewardType { get; } = "Item";
	public void GiveReward()
	{
		Console.WriteLine("Giving item");
	}
}

public class UnlockReward : IReward
{
	// Unlock target and other logic not implemented
	public string RewardType { get; } = "Unlock";
	public void GiveReward()
	{
		Console.WriteLine("Unlocking content");
	}
}

// ---- Reward system ----

public class RewardSystem
{
	public RewardSystem(IEnumerable<IReward> rewards)
	{
		this.rewards = rewards.ToDictionary(r => r.RewardType);
	}
	
	private Dictionary<string, IReward> rewards;
	
	public void GiveReward(string rewardType)
	{
		if (rewards.TryGetValue(rewardType, out IReward? reward))
		{
			reward?.GiveReward();
		}
	}
}

// ---- Program entry point ----

public static class Program
{
	public static void EntryPoint()
	{
		RewardSystem rewardsystem = new RewardSystem([
			new CoinReward(),
			new ItemReward(),
			new UnlockReward()
		]);
		
		rewardsystem.GiveReward("Coins");
		rewardsystem.GiveReward("Item");
		rewardsystem.GiveReward("Unlock");
		rewardsystem.GiveReward("Unknown");
	}
}