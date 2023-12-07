string inputTxt = File.ReadAllText(@"..\..\..\input\inputCopy.txt");

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

List<List<string>> seedRanges = new List<List<string>>();
string[] seedRangeStrings = splitInput[0].Split(':')[1].Split(new char[] { '\r', '\n', ' ' }, StringSplitOptions.RemoveEmptyEntries);

for (int i = 0; i < seedRangeStrings.Length; i += 2) {
    seedRanges.Add(new List<string>());
    seedRanges[i/2].Add(seedRangeStrings[i]);
    seedRanges[i/2].Add(seedRangeStrings[i + 1]);
}

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
    foreach (string s in mapSetArray) {
        maps[i - 1].Add(s);
    }
}

long lowestLocation = long.MaxValue;

foreach (List<string> seedRange in seedRanges) {
    for (long i = long.Parse(seedRange[0]); i < long.Parse(seedRange[0]) + long.Parse(seedRange[1]); i++) {
        long value = i;
        foreach (List<string> mapSet in maps) {
            foreach (string map in mapSet) {
                string[] mapSplit = map.Split(' ');
                long mappedValue = Map(value, long.Parse(mapSplit[0]), long.Parse(mapSplit[1]), long.Parse(mapSplit[2]));
                if (value != mappedValue) {
                    value = mappedValue;
                    break;
                }
            }
        }
        if (value < lowestLocation)
            lowestLocation = value;
    }
}

Console.WriteLine(lowestLocation);

Console.WriteLine("*");
return;


long Map(long value, long destinationRange, long sourceRange, long rangeLength) {
    if (value >= sourceRange && value <= sourceRange + rangeLength) {
        return destinationRange + value - sourceRange;
    }
    return value;
}