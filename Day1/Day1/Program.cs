using System.IO;
using System.Text.RegularExpressions;

int sum = 0;

try
{
    StreamReader sr = new StreamReader("C:\\Users\\Magnumic\\Documents\\GitHub\\AdventOfCode2023\\input\\input.txt");
    string inputLine = sr.ReadLine();
    while (inputLine != null)
    {
        string output = Regex.Replace(inputLine, @"[^0-9\-]", "");
        char[] chars = {output[0], output[^1]};
        sum += Int32.Parse(new string(chars));
        
        inputLine = sr.ReadLine();
    }
    sr.Close();
}
catch(Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}

Console.WriteLine(sum);