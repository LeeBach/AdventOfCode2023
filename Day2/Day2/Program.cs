using System.Collections;
using System.Text.RegularExpressions;

const int redNum = 12;
const int greenNum = 13;
const int blueNum = 14;

int redMax = 0;
int greenMax = 0;
int blueMax = 0;

try
{
    StreamReader sr = new StreamReader("C:\\Users\\Magnumic\\Documents\\GitHub\\AdventOfCode2023\\Day2\\Day2\\input\\" +
                                       "inputTest.txt");
    string inputLine = sr.ReadLine();
    while (inputLine != null)
    {
        
        string filteredLine = Regex.Replace(inputLine, @"[^0-9rgb]", "");
        Console.WriteLine(filteredLine);
        //sum += Int32.Parse(charStr);

        inputLine = sr.ReadLine();
    }
    sr.Close();
}
catch(Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}