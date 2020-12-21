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

	int variants = 0;
	for (int i = 0; i < list.Count; i++)
	{
		
	}
	
	

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