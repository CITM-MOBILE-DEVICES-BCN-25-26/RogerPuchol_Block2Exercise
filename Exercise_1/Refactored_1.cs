using System.Text;

namespace Assignment.Exercise_1;

// Note: I know, with hammer everything looks like a nail

// ---- Game Data storage ----

public class MatchData
{
	public int Score { get; set; }
	public int EnemiesKilled { get; set; }
	public int TimePlayedInSeconds { get; set; }
}

// ---- Match summary ----

// Doing it this way streamlines summary building, as you just need more metrics calculators to build the entire summary instead of editing the summarizer directly
public class MatchSummaryFormatter(IMetrics[] metrics)
{
	public string FormatSummary(MatchData data)
	{
		if (metrics.Length == 0) throw new ArgumentException("At least one metric is required.");
		
		StringBuilder sb = new StringBuilder();
		sb.Append($"{metrics[0].MetricType}: {metrics[0].GetMetric(data)}");
		
		for (int i = 1; i < metrics.Length; i++)
			sb.Append($" | {metrics[i].MetricType}: {metrics[i].GetMetric(data)}");
		
		return sb.ToString();
	}
}

// ---- Metric calculation ----

public interface IMetrics
{
	public string MetricType { get; }
	public string GetMetric(MatchData data);
}

public class PerformanceMetric : IMetrics
{

	public string MetricType { get; } = "Performance";
	public string GetMetric(MatchData data)
	{
		return (data.Score / (float)(data.TimePlayedInSeconds + 1)).ToString();
	}
}

public class ScoreMetric : IMetrics
{
	public string MetricType { get; } = "Score";
	public string GetMetric(MatchData data) => data.Score.ToString();
}

public class EnemiesKilledMetric : IMetrics
{
	public string MetricType { get; } = "Kills";
	public string GetMetric(MatchData data) => data.EnemiesKilled.ToString();
}

// ---- Data export ----

public interface IDataExporter
{
	public void Export(string data);
}

public class JsonDataExporter : IDataExporter
{
	public void Export(string data)
	{
		Console.WriteLine("Exporting as JSON: "+data);
	}
}

public class XmlDataExporter : IDataExporter
{
	public void Export(string data)
	{
		Console.WriteLine("Exporting as XML: "+data);
	}
}

// ---- Program entry point ----

public class Program
{
	public static void EntryPoint()
	{
		MatchData data = new MatchData();
		// Data read done without checks because i don't consider it that important for this assignment
		Console.Write("Score: ");
		data.Score = Convert.ToInt32(Console.ReadLine());
		Console.Write("Enemy kills: ");
		data.EnemiesKilled = Convert.ToInt32(Console.ReadLine());
		Console.Write("Seconds in game: ");
		data.TimePlayedInSeconds = Convert.ToInt32(Console.ReadLine());

		IMetrics[] metrics = [
			new ScoreMetric(),
			new EnemiesKilledMetric(),
			new PerformanceMetric()
		];
		
		MatchSummaryFormatter matchFormatter = new MatchSummaryFormatter(metrics);

		IDataExporter exporter = new JsonDataExporter();
		
		exporter.Export(matchFormatter.FormatSummary(data));

	}
}