<Query Kind="Program" />

/*
--- Part Two ---
Confident that your list of box IDs is complete, you're ready to find the boxes full of prototype fabric.

The boxes will have IDs which differ by exactly one character at the same position in both strings. For example, given the following box IDs:

abcde
fghij
klmno
pqrst
fguij
axcye
wvxyz
The IDs abcde and axcye are close, but they differ by two characters (the second and fourth). However, the IDs fghij and fguij differ by exactly one character, the third (h and u). Those must be the correct boxes.

What letters are common between the two correct box IDs? (In the example above, this is found by removing the differing character from either ID, producing fgij.)

1. Gå igenom bokstav för bokstav. Stoppa alla med samma bokstav i 
2. Gå igenom varje ord. I den inre loopen, ta ett set difference för varje annat ord. Det får bara skilja ett tecken.

*/

void Main()
{
	string[] inputLines = GetInputLines();

	//Parse input
	(int index, string value) firstBox = (0,"");
	(int index, string value) secondBox = (0,"");
	bool found = false;
	int differingLetters = 0;

	for (int currentIndex = 0; currentIndex < inputLines.Length; currentIndex++) // för varje box...
	{
		for (int nextIndex = currentIndex+1; nextIndex < inputLines.Length; nextIndex++) //...kolla alla följande boxar...
		{
			for (int j = 0; j < inputLines[currentIndex].Length; j++) //...genom att gå genom och jämföra bokstav för bokstav.
			{
				if (inputLines[currentIndex][j] != inputLines[nextIndex][j])
				{
					differingLetters++;
				}
				if (differingLetters > 1)
					break;
			}
			
			if (differingLetters == 1)
			{
				firstBox = (currentIndex, inputLines[currentIndex]);
				secondBox = (nextIndex, inputLines[nextIndex]);
				found = true;
				break;
			}
			differingLetters = 0;
		}
		if (found)
			break;
	}
	
	("Första: " + firstBox.value + " (index: " + firstBox.index + "), Andra: " + secondBox.value + " (index: " +secondBox.index + ")").Dump();
	
}



string[] GetInputLines()
{
	//utgår ifrån att namnsättningen på queries börjar med "<dag>_" att motsvarande inputs heter "<dag>_input.txt"
	string pathToQuery = Path.GetDirectoryName(Util.CurrentQueryPath);
	string queryName = Path.GetFileNameWithoutExtension(Util.CurrentQueryPath);
	string inputFilename = Regex.Split(queryName, @"_")[0] + "_input.txt";
	return File.ReadAllLines(Path.Combine(pathToQuery, inputFilename));
}