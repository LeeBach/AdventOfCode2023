using System.Text;

string inputTxt = File.ReadAllText(@"..\..\..\input\input.txt");

string[] delimitingStrings = {
    "seed-to-soil map:",
    "soil-to-fertilizer map:",
    "fertilizer-to-water map:",
    "water-to-light map:",
    "light-to-temperature map:",
    "temperature-to-humidity map:",
    "humidity-to-location map:",
};

string[] splitInput = inputTxt.Split(delimitingStrings, StringSplitOptions.None);

List<string> seeds = new List<string>();
foreach (string s in splitInput[0].Split(':')[1].Split(new char[] {'\r', '\n', ' '}, StringSplitOptions.RemoveEmptyEntries))
    seeds.Add(s);

List<List<string>> maps = new List<List<string>> {
    new List<string>(),
    new List<string>(),
    new List<string>(),
    new List<string>(),
    new List<string>(),
    new List<string>(),
    new List<string>()
};
for (int i = 1; i <= 7; i++) {
    string[] mapSetArray = splitInput[i].Split(new char[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
    string mapSetString = "";
    foreach (string s in mapSetArray) {
        maps[i - 1].Add(s);
    }
}

List<long> locations = new List<long>();

foreach (string seed in seeds) {
    long value = long.Parse(seed);
    foreach (List<string> mapSet in maps) {
        foreach (string map in mapSet) {
            string[] mapSplit = map.Split(' ');
            long destinationRange = long.Parse(mapSplit[0]);
            long sourceRange = long.Parse(mapSplit[1]);
            long rangeLength = long.Parse(mapSplit[2]);
            if (value != Map(value, destinationRange, sourceRange, rangeLength)) {
                value = Map(value, destinationRange, sourceRange, rangeLength);
                break;
            }
        }
    }
    locations.Add(value);
}

locations.Sort();
Console.WriteLine(locations[0]);

Console.WriteLine("*");
return;


long Map(long value, long destinationRange, long sourceRange, long rangeLength) {
    if (value >= sourceRange && value <= sourceRange + rangeLength) {
        return destinationRange + value - sourceRange;
    }
    return value;
}