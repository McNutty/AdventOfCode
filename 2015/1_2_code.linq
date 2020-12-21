<Query Kind="Program" />

/* INSTRUCTIONS
--- Part Two ---
Now, given the same instructions, find the position of the first character that causes him to enter the basement (floor -1). The first character in the instructions has position 1, the second character has position 2, and so on.

For example:

) causes him to enter the basement at character position 1.
()()) causes him to enter the basement at character position 5.
What is the position of the character that causes Santa to first enter the basement?

*/

void Main()
{
	string[] inputLines = GetInputLines();
	
	int floor = 0;
	char[] characters = inputLines[0].ToCharArray();
	int floorIndex = 0;
	for (int i = 0; i < characters.Length; i++)
	{
		if (Char.Equals(characters[i], '('))
			floor++;
		else if (Char.Equals(characters[i], ')'))
			floor--;
	
		if (floor == -1)
		{
			floorIndex = i + 1;
			break;
		}
	}
	
	floorIndex.Dump();


}

// Define other methods and classes here

string[] GetInputLines()
{
	//utgår ifrån att namnsättningen på queries börjar med "<dag>_" att motsvarande inputs heter "<dag>_input.txt"
	string pathToQuery = Path.GetDirectoryName(Util.CurrentQueryPath);
	string queryName = Path.GetFileNameWithoutExtension(Util.CurrentQueryPath);
	string inputFilename = Regex.Split(queryName, @"_")[0] + "_input.txt";
	return File.ReadAllLines(Path.Combine(pathToQuery, inputFilename));
}