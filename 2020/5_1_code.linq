<Query Kind="Program" />

/* INSTRUCTIONS
--- Day 5: Binary Boarding ---
You board your plane only to discover a new problem: you dropped your boarding pass! You aren't sure which seat is yours, and all of the flight attendants are busy with the flood of people that suddenly made it through passport control.

You write a quick program to use your phone's camera to scan all of the nearby boarding passes (your puzzle input); perhaps you can find your seat through process of elimination.

Instead of zones or groups, this airline uses binary space partitioning to seat people. A seat might be specified like FBFBBFFRLR, where F means "front", B means "back", L means "left", and R means "right".

The first 7 characters will either be F or B; these specify exactly one of the 128 rows on the plane (numbered 0 through 127). Each letter tells you which half of a region the given seat is in. Start with the whole list of rows; the first letter indicates whether the seat is in the front (0 through 63) or the back (64 through 127). The next letter indicates which half of that region the seat is in, and so on until you're left with exactly one row.

For example, consider just the first seven characters of FBFBBFFRLR:

Start by considering the whole range, rows 0 through 127.
F means to take the lower half, keeping rows 0 through 63.
B means to take the upper half, keeping rows 32 through 63.
F means to take the lower half, keeping rows 32 through 47.
B means to take the upper half, keeping rows 40 through 47.
B keeps rows 44 through 47.
F keeps rows 44 through 45.
The final F keeps the lower of the two, row 44.
The last three characters will be either L or R; these specify exactly one of the 8 columns of seats on the plane (numbered 0 through 7). The same process as above proceeds again, this time with only three steps. L means to keep the lower half, while R means to keep the upper half.

For example, consider just the last 3 characters of FBFBBFFRLR:

Start by considering the whole range, columns 0 through 7.
R means to take the upper half, keeping columns 4 through 7.
L means to take the lower half, keeping columns 4 through 5.
The final R keeps the upper of the two, column 5.
So, decoding FBFBBFFRLR reveals that it is the seat at row 44, column 5.

Every seat also has a unique seat ID: multiply the row by 8, then add the column. In this example, the seat has ID 44 * 8 + 5 = 357.

Here are some other boarding passes:

BFFFBBFRRR: row 70, column 7, seat ID 567.
FFFBBBFRRR: row 14, column 7, seat ID 119.
BBFFBBFRLL: row 102, column 4, seat ID 820.
As a sanity check, look through your list of boarding passes. What is the highest seat ID on a boarding pass?
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

	string highestSeatCode = "";
	foreach (var seatCode in seats)
	{
		List<int> _rows = new List<int>(rows);
		List<int> _columns = new List<int>(columns);
		ValueTuple<int, int> seatNumber = GetPlace(seatCode.ToList(), _rows, _columns);
		currentSeat = GetSeatID(seatNumber.Item1, seatNumber.Item2);
		if (currentSeat > highestSeat)
		{
			highestSeat = currentSeat;
			highestSeatCode = seatCode;
		}
	}
	
	highestSeat.Dump();
	highestSeatCode.Dump();

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