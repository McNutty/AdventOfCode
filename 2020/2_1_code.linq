<Query Kind="Program" />

/*
To try to debug the problem, they have created a list (your puzzle input) of passwords (according to the corrupted database) and the corporate policy when that password was set.

For example, suppose you have the following list:

1-3 a: abcde
1-3 b: cdefg
2-9 c: ccccccccc
Each line gives the password policy and then the password. The password policy indicates the lowest and highest number of times a given letter must appear for the password to be valid. For example, 1-3 a means that the password must contain a at least 1 time and at most 3 times.

In the above example, 2 passwords are valid. The middle password, cdefg, is not; it contains no instances of b, but needs at least 1. The first and third passwords are valid: they contain one a or nine c, both within the limits of their respective policies.

How many passwords are valid according to their policies?
*/

void Main()
{
	string[] inputLines = File.ReadAllLines(@"C:\Users\mgjerde\OneDrive - Capgemini\Scripts\LINQPad\Queries\Advent of Code\2020\2_input.txt");
	int validLines = 0;

	Regex pattern = new Regex(@"(?<rangestart>\d+)-(?<rangeend>\d+) (?<letter>\w): (?<password>\w+)");
	//Parse input
	foreach (var line in inputLines)
	{
		Match match = pattern.Match(line);

		int rangeStart = int.Parse(match.Groups["rangestart"].Value);
		int rangeEnd = int.Parse(match.Groups["rangeend"].Value);
		char letter = Char.Parse(match.Groups["letter"].Value);
		string password = match.Groups["password"].Value;
		
		int occurences = CountCharOccurences(password,letter);
		
		if (rangeStart <= occurences && occurences <= rangeEnd)
			validLines++;
	}

	validLines.Dump();
}

int CountCharOccurences(string haystack, char needle)
{
	int count = 0;
	foreach (char element in haystack.ToCharArray())
	{
		if (element.Equals(needle))
			count++;
	}
	return count;
}