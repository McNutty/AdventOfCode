<Query Kind="Program" />

void Main()
{
	string[] inputLines = File.ReadAllLines(@"C:\Users\mgjerde\OneDrive - Capgemini\Scripts\LINQPad\Queries\Advent of Code\2018\23_input.txt");
	List<Nanobot> Nanobots = new List<Nanobot>();

	//Parse input
	
	Regex pattern = new Regex(@"pos=<(?<x>-*\d+),(?<y>-*\d+),(?<z>-*\d+)>, r=(?<range>-*\d+)");
	foreach (var line in inputLines)
	{
		Match match = pattern.Match(line);
		
		int x = int.Parse(match.Groups["x"].Value);
		int y = int.Parse(match.Groups["y"].Value);
		int z = int.Parse(match.Groups["z"].Value);
		int range = int.Parse(match.Groups["range"].Value);
		
		Nanobots.Add(new Nanobot(new Tuple<int,int,int>(x,y,z), range));
	}
	//Find Nanobot with greatest range
	int greatestRange = 0;
	Nanobot nanobotWithGreatestRange = null;
	foreach (Nanobot nanobot in Nanobots)
	{
		if (nanobot.range > greatestRange)
		{
			greatestRange = nanobot.range;
			nanobotWithGreatestRange = nanobot;
		}
	}
	
	//Check distances from nanobot with greatest range
	int inRange = 0;
	foreach (Nanobot nanobot in Nanobots)
	{
		if (GetManhattanDistance(nanobotWithGreatestRange.coordinates,nanobot.coordinates) <= nanobotWithGreatestRange.range)
			inRange++;
	}
	
	inRange.Dump();
}

int GetManhattanDistance(Tuple<int,int,int> x, Tuple<int,int,int> y)
{
	return Math.Abs(x.Item1 - y.Item1) + Math.Abs(x.Item2 - y.Item2) + Math.Abs(x.Item3 - y.Item3);
}

class Nanobot
{
	public Tuple<int, int, int> coordinates;
	public int range;
	
	public Nanobot(Tuple<int,int,int> coordinates, int range)
	{
		this.coordinates = coordinates;
		this.range = range;
	}
}

// Define other methods and classes here
