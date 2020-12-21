<Query Kind="Program" />

/* INSTRUCTIONS

Paste instructions here.

*/

void Main()
{
	string[] inputLines = GetInputLines();



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