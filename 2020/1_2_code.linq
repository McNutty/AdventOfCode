<Query Kind="Program" />

/* INSTRUCTIONS
--- Part Two ---
The Elves in accounting are thankful for your help; one of them even offers you a starfish coin they had left over from a past vacation. They offer you a second one if you can find three numbers in your expense report that meet the same criteria.

Using the above example again, the three entries that sum to 2020 are 979, 366, and 675. Multiplying them together produces the answer, 241861950.

In your expense report, what is the product of the three entries that sum to 2020?
*/

void Main()
{
	string[] inputLines = File.ReadAllLines(@"C:\Users\mgjerde\OneDrive - Capgemini\Scripts\LINQPad\Queries\Advent of Code\2020\1_input.txt");

	int firstNumber = 0;
	int secondNumber = 0;
	int thirdNumber = 0;
	int answer = 0;
	bool answerFound = false;

	int i = 0;
	int j = 0;
	int k = 0;
	for (i = 0; i < inputLines.Length; i++)
	{
		firstNumber = Int32.Parse(inputLines[i]);

		for (j = i + 1; j < inputLines.Length; j++)
		{
			secondNumber = Int32.Parse(inputLines[j]);

			for (k = j + 1; k < inputLines.Length; k++)
			{
				thirdNumber = Int32.Parse(inputLines[k]);

				if (firstNumber + secondNumber + thirdNumber == 2020)
				{
					answer = firstNumber * secondNumber * thirdNumber;
					answerFound = true;
					break;
				}
			}
			if (answerFound)
			{
				break;
			}

		}
		if (answerFound)
		{
			break;
		}
	}
	String.Format("First Number on line {0} = {1}", i+1,firstNumber).Dump();
	String.Format("Second Number on line {0} = {1}", j+1,secondNumber).Dump();
	String.Format("Third Number on line {0} = {1}", k+1,thirdNumber).Dump();
	String.Format("Answer ({0}*{1}*{2}) = {3}",firstNumber,secondNumber,thirdNumber,answer).Dump();
}

// Define other methods and classes here