<Query Kind="Program" />

/* INSTRUCTIONS

--- Day 4: Passport Processing ---
You arrive at the airport only to realize that you grabbed your North Pole Credentials instead of your passport. While these documents are extremely similar, North Pole Credentials aren't issued by a country and therefore aren't actually valid documentation for travel in most of the world.

It seems like you're not the only one having problems, though; a very long line has formed for the automatic passport scanners, and the delay could upset your travel itinerary.

Due to some questionable network security, you realize you might be able to solve both of these problems at the same time.

The automatic passport scanners are slow because they're having trouble detecting which passports have all required fields. The expected fields are as follows:

byr (Birth Year)
iyr (Issue Year)
eyr (Expiration Year)
hgt (Height)
hcl (Hair Color)
ecl (Eye Color)
pid (Passport ID)
cid (Country ID)
Passport data is validated in batch files (your puzzle input). Each passport is represented as a sequence of key:value pairs separated by spaces or newlines. Passports are separated by blank lines.

Here is an example batch file containing four passports:

ecl:gry pid:860033327 eyr:2020 hcl:#fffffd
byr:1937 iyr:2017 cid:147 hgt:183cm

iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884
hcl:#cfa07d byr:1929

hcl:#ae17e1 iyr:2013
eyr:2024
ecl:brn pid:760753108 byr:1931
hgt:179cm

hcl:#cfa07d eyr:2025 pid:166559648
iyr:2011 ecl:brn hgt:59in
The first passport is valid - all eight fields are present. The second passport is invalid - it is missing hgt (the Height field).

The third passport is interesting; the only missing field is cid, so it looks like data from North Pole Credentials, not a passport at all! Surely, nobody would mind if you made the system temporarily ignore missing cid fields. Treat this "passport" as valid.

The fourth passport is missing two fields, cid and byr. Missing cid is fine, but missing any other field is not, so this passport is invalid.

According to the above rules, your improved system would report 2 valid passports.

Count the number of valid passports - those that have all required fields. Treat cid as optional. In your batch file, how many passports are valid?

*/

void Main()
{
	string[] inputLines = GetInputLines();

	Regex field = new Regex(@"(?<fieldName>\w+):(?<fieldValue>\S+)");
	
	List<string> passportFields = new List<string>();
	List<(string,string)> passportData = new List<(string fieldName, string fieldValue)>();
	int validPassports = 0;
	//Parse input
	foreach (var line in inputLines)
	{
		Match fieldMatch = field.Match(line);
		while (fieldMatch.Success)
		{
			string fieldName = fieldMatch.Groups["fieldName"].Value;
			string fieldValue = fieldMatch.Groups["fieldValue"].Value;

			passportFields.Add(fieldName);
			passportData.Add((fieldName,fieldValue));

			("fieldName: " + fieldName + ", fieldValue: " + fieldValue).Dump();

			fieldMatch = fieldMatch.NextMatch();
		}

		if (String.IsNullOrEmpty(line))
		{
			if (ValidatePassportFields(passportFields) && ValidateFieldData(passportData))
			{
				validPassports++;
			}

			passportFields.Clear();
			passportData.Clear();
			"".Dump();
		}
	}
	validPassports.Dump();
}

// Define other methods and classes here
bool ValidatePassportFields(List<string> passportFields)
{
	// Jag vill jämföra två sets. Alla mandatory måste finnas i passportFields. Skit i optional.
	List<string> mandatoryCodes = new List<string>() { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };
	
	var missingFields = mandatoryCodes.Except(passportFields).ToList();
	
	if (missingFields.Count == 0)
	{
		"All mandatory passport fields present!".Dump();
		return true;
	}
	else
	{
		StringBuilder missing = new StringBuilder();
		foreach (var element in missingFields)
		{
			missing.Append(element+", ");
		}
		("Missing field(s): " + missing.ToString().Substring(0,missing.Length-2)).Dump();

		return false;
	}
	
	//return (missingFields.ToList().Count == 0);
}

bool ValidateFieldData(List<(string fieldName, string fieldData)> passportData)
{
	(bool valid, string errorMessage) status = (true,"");
	bool formatOK = true;
	bool rangeOK = true;
	
	Regex pattern = new Regex("");
	Match match;
	
	foreach (var field in passportData)
	{
		if (!status.valid)
			break;
		
		switch (field.fieldName)
		{
			case "byr":
				formatOK = field.fieldData.Length == 4;
				rangeOK = Int32.Parse(field.fieldData) >= 1920 && Int32.Parse(field.fieldData) <= 2002;
				if (!(formatOK && rangeOK))
					status = (false,"byr");
			 	break;
				
			case "iyr":
				formatOK = field.fieldData.Length == 4;
				rangeOK = Int32.Parse(field.fieldData) >= 2010 && Int32.Parse(field.fieldData) <= 2020;
				if (!(formatOK && rangeOK))
					status = (false, "iyr");
				break;

			case "eyr":
				formatOK = field.fieldData.Length == 4;
				rangeOK = Int32.Parse(field.fieldData) >= 2020 && Int32.Parse(field.fieldData) <= 2030;
				if (!(formatOK && rangeOK))
					status = (false, "eyr");
				break;

			case "hgt": //height
				pattern = new Regex(@"^(?<value>\d+)(?<unit>(cm|in))");
				match = pattern.Match(field.fieldData);
				formatOK = match.Success;
				if (formatOK)
				{
					if (match.Groups["unit"].Value == "cm")
					{
						rangeOK = Int32.Parse(match.Groups["value"].Value) >= 150 && Int32.Parse(match.Groups["value"].Value) <= 193;
					}
					else //inches
					{
						rangeOK = Int32.Parse(match.Groups["value"].Value) >= 59 && Int32.Parse(match.Groups["value"].Value) <= 76;
					}
				}
				
				if (!(formatOK && rangeOK))
					status = (false, "hgt");
				break;

			case "hcl": //hair color
				pattern = new Regex(@"#[0-9a-f]{6}");
				match = pattern.Match(field.fieldData);
				formatOK = match.Success;
				if (!formatOK)
					status = (false, "hcl");
				break;

			case "ecl": //eye color
				pattern = new Regex(@"(amb|blu|brn|gry|grn|hzl|oth)");
				match = pattern.Match(field.fieldData);
				formatOK = match.Success;
				if (!formatOK)
					status = (false, "ecl");
				break;

			case "pid": //Passport ID
				pattern = new Regex(@"^\d{9}$");
				match = pattern.Match(field.fieldData);
				formatOK = match.Success;
				if (!formatOK)
					status = (false, "pid");
				break;

			default:
				break;
		}
	}
	("Data validation: " + status.valid).Dump();
	if (!status.valid)
		("Failing validation: " + status.errorMessage).Dump();
	return status.valid;
}



string[] GetInputLines()
{
	//utgår ifrån att namnsättningen på queries börjar med "<dag>_" att motsvarande inputs heter "<dag>_input.txt"
	string pathToQuery = Path.GetDirectoryName(Util.CurrentQueryPath);
	string queryName = Path.GetFileNameWithoutExtension(Util.CurrentQueryPath);
	string inputFilename = Regex.Split(queryName, @"_")[0] + "_input.txt";
	return File.ReadAllLines(Path.Combine(pathToQuery, inputFilename));
}