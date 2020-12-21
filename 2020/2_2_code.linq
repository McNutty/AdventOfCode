<Query Kind="Program" />

/*
Each policy actually describes two positions in the password, where 1 means the first character, 2 means the second character, and so on. (Be careful; Toboggan Corporate Policies have no concept of "index zero"!) Exactly one of these positions must contain the given letter. Other occurrences of the letter are irrelevant for the purposes of policy enforcement.

Given the same example list from above:

1-3 a: abcde is valid: position 1 contains a and position 3 does not.
1-3 b: cdefg is invalid: neither position 1 nor position 3 contains b.
2-9 c: ccccccccc is invalid: both position 2 and position 9 contain c.
How many passwords are valid according to the new interpretation of the policies?
*/

void Main()
{
	string[] inputLines = File.ReadAllLines(@"C:\Users\mgjerde\OneDrive - Capgemini\Scripts\LINQPad\Queries\Advent of Code\2020\2_input.txt");
	int validLines = 0;

	Regex pattern = new Regex(@"(?<firstPosition>\d+)-(?<secondPosition>\d+) (?<letter>\w): (?<password>\w+)");
	//Parse input
	foreach (var line in inputLines)
	{
		Match match = pattern.Match(line);

		int firstPosition = int.Parse(match.Groups["firstPosition"].Value);
		int secondPosition = int.Parse(match.Groups["secondPosition"].Value);
		char letter = Char.Parse(match.Groups["letter"].Value);
		string password = match.Groups["password"].Value;
		
		int occurrences = OccurrencesInLine(password,letter,firstPosition-1,secondPosition-1);
		
		if (occurrences == 1)
			validLines++;
	}

	validLines.Dump();
}

int OccurrencesInLine(string haystack, char needle, int firstPosition, int secondPosition)
{
	int occurrences = 0;
	if (needle.Equals(haystack[firstPosition]))
		occurrences++;
	if (needle.Equals(haystack[secondPosition]))
		occurrences++;
	
	return occurrences;
}