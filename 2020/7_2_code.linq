<Query Kind="Program" />


/* INSTRUCTIONS

--- Part Two ---
It's getting pretty expensive to fly these days - not because of ticket prices, but because of the ridiculous number of bags you need to buy!

Consider again your shiny gold bag and the rules from the above example:

faded blue bags contain 0 other bags.
dotted black bags contain 0 other bags.
vibrant plum bags contain 11 other bags: 5 faded blue bags and 6 dotted black bags.
dark olive bags contain 7 other bags: 3 faded blue bags and 4 dotted black bags.
So, a single shiny gold bag must contain 1 dark olive bag (and the 7 bags within it) plus 2 vibrant plum bags (and the 11 bags within each of those): 1 + 1*7 + 2 + 2*11 = 32 bags!

Of course, the actual rules have a small chance of going several levels deeper than this example; be sure to count all of the bags, even if the nesting becomes topologically impractical!

Here's another example:

shiny gold bags contain 2 dark red bags.
dark red bags contain 2 dark orange bags.
dark orange bags contain 2 dark yellow bags.
dark yellow bags contain 2 dark green bags.
dark green bags contain 2 dark blue bags.
dark blue bags contain 2 dark violet bags.
dark violet bags contain no other bags.
In this example, a single shiny gold bag must contain 126 other bags.

How many individual bags are required inside your single shiny gold bag?
*/

void Main()
{
	string[] inputLines = GetInputLines();

	Regex pattern = new Regex(@"(?<color>\d*\s?\w+ \w+) bags?");

	HashSet<(string, string)> validCombinations = new HashSet<(string, string)>();
	foreach (var rule in inputLines)
	{
		Match match = pattern.Match(rule);
		int matchNo = 0;
		string enclosingBag = String.Empty;
		while (match.Success)
		{
			if (matchNo == 0) //new rule
			{
				enclosingBag = match.Groups["color"].Value;
			}
			else
			{
				validCombinations.Add((enclosingBag, match.Groups["color"].Value));
			}
			matchNo++;
			match = match.NextMatch();
		}
	}
	//validCombinations.Dump();

	//FindEnclosingBags("shiny gold", validCombinations);
	FindEnclosedBags("shiny gold", validCombinations, 1);

	numberOfBags.Dump();


}

int numberOfBags = 0;

void FindEnclosedBags(string color, HashSet<(string enclosingColor, string enclosedColor)> allRules, int previousNumber)
{

	IEnumerable<(string enclosingColor, string enclosedColor)> rulesWithCurrentColor = allRules.Where(x => x.enclosingColor == color); //1:st order
	if (rulesWithCurrentColor.Any())
	{
		foreach (var rule in rulesWithCurrentColor)
		{
			Regex pattern = new Regex(@"(?<count>\d+) (?<color>\w+ \w+)");
			//combination.enclosedColor.Dump();
			//pattern.Match(combination.enclosedColor).Groups["count"].Value.Dump();
			int number;
			if (Int32.TryParse(pattern.Match(rule.enclosedColor).Groups["count"].Value, out number))
			{
				numberOfBags += number * previousNumber;
				string enclosedBag = pattern.Match(rule.enclosedColor).Groups["color"].Value;
				FindEnclosedBags(enclosedBag, allRules, number);

			}
			else
			{
				numberOfBags += 1 * previousNumber;  //no other bags inside.
			}

		}
	}
}



// Define other methods and classes here
public HashSet<string> bags = new HashSet<string>();
void FindEnclosingBags(string color, HashSet<(string enclosingColor, string enclosedColor)> validCombinations)
{
	IEnumerable<(string enclosingColor, string enclosedColor)> enclosing = validCombinations.Where(x => x.enclosedColor == color); //1:st order
	if (enclosing.Any())
	{
		foreach (var element in enclosing)
		{
			bags.Add(element.enclosingColor);
			FindEnclosingBags(element.enclosingColor, validCombinations);
		}
	}


}

string[] GetInputLines()
{
	//utgår ifrån att namnsättningen på queries börjar med "<dag>_" att motsvarande inputs heter "<dag>_input.txt"
	string pathToQuery = Path.GetDirectoryName(Util.CurrentQueryPath);
	string queryName = Path.GetFileNameWithoutExtension(Util.CurrentQueryPath);
	string inputFilename = Regex.Split(queryName, @"_")[0] + "_input.txt";
	return File.ReadAllLines(Path.Combine(pathToQuery, inputFilename));
}

class Bag
{
	public string color = "";
	public List<Bag> possibleEnclosingBags = new List<Bag>();

	public Bag(string color)
	{
		this.color = color;
	}

	public void AddEnclosingBag(Bag enclosingBag)
	{
		if (!possibleEnclosingBags.Contains(enclosingBag))
			possibleEnclosingBags.Add(enclosingBag);
	}

	public override bool Equals(Object obj)
	{
		//Check for null and compare run-time types.
		if ((obj == null) || !this.GetType().Equals(obj.GetType()))
		{
			return false;
		}
		else
		{
			Bag p = (Bag)obj;
			return (color == p.color);
		}
	}
}


// Define other methods and classes here
