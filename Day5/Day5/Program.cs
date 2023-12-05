List<string> inputTxt = new(File.ReadAllLines(@"..\..\..\input\inputTest.txt"));

string seeds = "79 14 55 13";
string[] seedsArray = seeds.Split(' ');

int map(int value, int destinationRange, int sourceRange, int rangeLength) {
    if (value >= sourceRange && value <= sourceRange + rangeLength) {
        return destinationRange + value - sourceRange;
    }
    return value;
}

foreach (string seed in seedsArray) {
    if (map(int.Parse(seed), 50, 98, 2) != int.Parse(seed))
        Console.WriteLine(map(int.Parse(seed), 50, 98, 2));
    else
        Console.WriteLine(int.Parse(seed));
    
    if (map(int.Parse(seed), 52, 50, 48) != int.Parse(seed))
        Console.WriteLine(map(int.Parse(seed), 52, 50, 48));
    else
        Console.WriteLine(int.Parse(seed));
}