<Query Kind="Program" />

/* INSTRUCTIONS
--- Part Two ---
Ding! The "fasten seat belt" signs have turned on. Time to find your seat.

It's a completely full flight, so your seat should be the only missing boarding pass in your list. However, there's a catch: some of the seats at the very front and back of the plane don't exist on this aircraft, so they'll be missing from your list as well.

Your seat wasn't at the very front or back, though; the seats with IDs +1 and -1 from yours will be in your list.

What is the ID of your seat?
*/

void Main()
{
	string[] seats = GetInputLines();

	int highestSeat = 0;
	int currentSeat = 0;
	List<int> rows = new List<int>();
	for (int i = 0; i <= 127; i++)
	{
		rows.Add(i);
	}
	List<int> columns = new List<int>();
	for (int i = 0; i <= 7; i++)
	{
		columns.Add(i);
	}
	
	List<int> allPossibleSeats = new List<int>();
	int highestPossibleSeat = GetSeatID(127,7);
	for (int i = 0; i <= highestPossibleSeat; i++)
	{
		allPossibleSeats.Add(i);
	}

	List<int> flightSeats = new List<int>();
	foreach (var seatCode in seats)
	{
		List<int> _rows = new List<int>(rows);
		List<int> _columns = new List<int>(columns);
		ValueTuple<int, int> seatNumber = GetPlace(seatCode.ToList(), _rows, _columns);
		flightSeats.Add(GetSeatID(seatNumber.Item1, seatNumber.Item2));
	}
	
	allPossibleSeats.Except(flightSeats).Dump();

}

(int, int) GetPlace(List<char> seatCode, List<int> rows, List<int> columns)
{	
	switch (seatCode.FirstOrDefault())
	{
		case 'F':
			seatCode.RemoveAt(0);
			rows.RemoveRange(rows.Count() / 2, rows.Count() / 2);
			return GetPlace(seatCode, rows, columns);
		case 'B':
			seatCode.RemoveAt(0);
			rows.RemoveRange(0, rows.Count() / 2);
			return GetPlace(seatCode, rows, columns);
		case 'L':
			seatCode.RemoveAt(0);
			columns.RemoveRange(columns.Count() / 2, columns.Count() / 2);
			return GetPlace(seatCode, rows, columns);
		case 'R':
			seatCode.RemoveAt(0);
			columns.RemoveRange(0, columns.Count() / 2);
			return GetPlace(seatCode, rows, columns);
		default:
			return (rows[0], columns[0]);
	}
}


int GetSeatID(int row, int column)
{
	return (row * 8) + column;
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