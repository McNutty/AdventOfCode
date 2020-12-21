<Query Kind="Program" />

/*
Time to check the rest of the slopes - you need to minimize the probability of a sudden arboreal stop, after all.

Determine the number of trees you would encounter if, for each of the following slopes, you start at the top-left corner and traverse the map all the way to the bottom:

Right 1, down 1.
Right 3, down 1. (This is the slope you already checked.)
Right 5, down 1.
Right 7, down 1.
Right 1, down 2.
In the above example, these slopes would find 2, 7, 3, 4, and 2 tree(s) respectively; multiplied together, these produce the answer 336.

What do you get if you multiply together the number of trees encountered on each of the listed slopes?
*/

void Main()
{
	Int64 result = 1; //Blir int32-overflow annars!!! Coolt!!

	List<(int columnIncrease, int rowIncrease)> slopes = new List<(int, int)>() { (1,1),(3,1),(5,1),(7,1),(1,2) };
	
	foreach (var slope in slopes)
	{
		result *= treesInSlope(slope.rowIncrease, slope.columnIncrease);
	}

	result.Dump();
}

int treesInSlope(int rowIncrease, int columnIncrease)
{
	string[] inputLines = GetInputLines();

	int treesFound = 0;
	int column = columnIncrease;
	for (int row = rowIncrease; row < inputLines.Length; row += rowIncrease)
	{
		char[] currentLine = inputLines[row].ToCharArray();

		if (isTree(currentLine[column % currentLine.Length]))
			treesFound++;

		column += columnIncrease;
	}
	return treesFound;
}

bool isTree(char character)
{
	return character.Equals('#');
}

string[] GetInputLines()
{
	string pathToQuery = Path.GetDirectoryName(Util.CurrentQueryPath);
	string queryName = Path.GetFileNameWithoutExtension(Util.CurrentQueryPath);
	string inputFilename = Regex.Split(queryName, @"_")[0] + "_input.txt";
	return File.ReadAllLines(Path.Combine(pathToQuery, inputFilename));
}