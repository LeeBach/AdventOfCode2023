using System.Text.RegularExpressions;

List<string> inputTxt = new(File.ReadAllLines(@"..\..\..\input\input.txt"));

int sum = 0;

foreach(string inputLine in inputTxt)
{
    string filteredLine = Regex.Replace(inputLine, @"eightwo", "82");
    filteredLine = Regex.Replace(filteredLine, @"twone", "21");
    filteredLine = Regex.Replace(filteredLine, @"oneight", "18");
    filteredLine = Regex.Replace(filteredLine, @"one", "1");
    filteredLine = Regex.Replace(filteredLine, @"two", "2");
    filteredLine = Regex.Replace(filteredLine, @"three", "3");
    filteredLine = Regex.Replace(filteredLine, @"four", "4");
    filteredLine = Regex.Replace(filteredLine, @"five", "5");
    filteredLine = Regex.Replace(filteredLine, @"six", "6");
    filteredLine = Regex.Replace(filteredLine, @"seven", "7");
    filteredLine = Regex.Replace(filteredLine, @"eight", "8");
    filteredLine = Regex.Replace(filteredLine, @"nine", "9");
    filteredLine = Regex.Replace(filteredLine, @"[^0-9]", "");
    char[] chars = {filteredLine[0], filteredLine[^1]};
    string charStr = new string(chars);
    //Console.WriteLine(charStr);
    sum += Int32.Parse(charStr);
}

Console.WriteLine(sum);