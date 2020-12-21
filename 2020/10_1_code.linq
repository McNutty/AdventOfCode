<Query Kind="Program" />

/* INSTRUCTIONS

Paste instructions here.

*/

void Main()
{
	string[] inputLines = GetInputLines();
	List<int> list = new List<int>();
	foreach (var element in inputLines)
	{
		list.Add(Int32.Parse(element));
	}
	list.Sort();

	list.Add(list.Last() + 3); //device


	int incOnes = 0;
	int incThrees = 0;
	int prev = 0;
	foreach (var current in list)
	{
		if (current - prev == 1)
			incOnes += 1;
		if (current - prev == 3)
			incThrees += 1;
			
		prev = current;
	}
	
	(incOnes * incThrees).Dump();

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