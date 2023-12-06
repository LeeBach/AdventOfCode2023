using System.Text;

string inputTxt = File.ReadAllText(@"..\..\..\input\inputTest.txt");

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

foreach (string seed in seeds) {
    int value = int.Parse(seed);
    foreach (List<string> mapSet in maps) {
        foreach (string map in mapSet) {
            string[] mapSplit = map.Split(' ');
            int destinationRange = int.Parse(mapSplit[0]);
            int sourceRange = int.Parse(mapSplit[1]);
            int rangeLength = int.Parse(mapSplit[2]);
            value = Map(value, destinationRange, sourceRange, rangeLength);
        }
    }
    Console.WriteLine(value);
}

Console.WriteLine("*");

return;


int Map(int value, int destinationRange, int sourceRange, int rangeLength) {
    if (value >= sourceRange && value <= sourceRange + rangeLength) {
        return destinationRange + value - sourceRange;
    }
    return value;
}

/*
int thing = 55;

thing = Map(thing, 50, 98, 2);
thing = Map(thing, 52, 50, 48);

thing = Map(thing, 0, 15, 37);
thing = Map(thing, 37, 52, 2);
thing = Map(thing, 39, 0, 15);

thing = Map(thing, 49, 53, 8);
thing = Map(thing, 0, 11, 42);
thing = Map(thing, 42, 0, 7);
thing = Map(thing, 57, 7, 4);

thing = Map(thing, 88, 18, 7);
thing = Map(thing, 18, 25, 70);

thing = Map(thing, 45, 77, 23);
thing = Map(thing, 81, 45, 19);
thing = Map(thing, 68, 64, 13);

thing = Map(thing, 0, 69, 1);
thing = Map(thing, 1, 0, 69);

thing = Map(thing, 60, 56, 37);
thing = Map(thing, 56, 93, 4);

Console.WriteLine(thing);
*/