<Query Kind="Program" />

/* INSTRUCTIONS
Before you leave, the Elves in accounting just need you to fix your expense report (your puzzle input); apparently, something isn't quite adding up.
Specifically, they need you to find the two entries that sum to 2020 and then multiply those two numbers together.
For example, suppose your expense report contained the following:

1721
979
366
299
675
1456

In this list, the two entries that sum to 2020 are 1721 and 299. Multiplying them together produces 1721 * 299 = 514579, so the correct answer is 514579.
Of course, your expense report is much larger. Find the two entries that sum to 2020; what do you get if you multiply them together?
*/

void Main()
{
	//string[] inputLines = File.ReadAllLines(Path.Combine(Path.GetDirectoryName(Util.CurrentQueryPath), "1_input.txt"));
	string[] inputLines = GetInputLines();
	int firstNumber = 0;
	int secondNumber = 0;
	int answer = 0;
	bool answerFound = false;
	
	int i = 0;
	int j = 1;
	for (i = 0; i < inputLines.Length; i++)
	{
		firstNumber = Int32.Parse(inputLines[i]);
		
		for (j = i+1; j < inputLines.Length; j++)
		{
			secondNumber = Int32.Parse(inputLines[j]);
			if (firstNumber + secondNumber == 2020)
			{
				answer = firstNumber*secondNumber;
				answerFound = true;
				break;
			}
		}
		if (answerFound)
		{
			break;
		}
	}
	String.Format("First Number on line {0} = {1}", i + 1, firstNumber).Dump();
	String.Format("Second Number on line {0} = {1}", j + 1, secondNumber).Dump();
	String.Format("Answer ({0}*{1}) = {2}",firstNumber,secondNumber,answer).Dump();
}

string[] GetInputLines()
{
	string pathToQuery = Path.GetDirectoryName(Util.CurrentQueryPath);
	string queryName = Path.GetFileNameWithoutExtension(Util.CurrentQueryPath);
	string inputFilename = Regex.Split(queryName, @"_")[0] + "_input.txt";
	return File.ReadAllLines(Path.Combine(pathToQuery, inputFilename));
}