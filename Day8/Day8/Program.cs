using System.Collections;

var inputTxt = new List<string>(File.ReadAllLines(@"..\..\..\input\inputTest3.txt"));

var instructions = inputTxt[0];
inputTxt.Remove(instructions);
inputTxt.Remove("");
var instructionsArray = instructions.ToCharArray();

var allStartingNodes = new List<string>();
var map = new Hashtable();
foreach (var entryString in inputTxt) {
    var keyString = entryString.Split('=')[0].Trim();
    var valueString = entryString.Split('=')[1].Trim(' ', '(', ')');
    map.Add(keyString, valueString);
    allStartingNodes.Add(keyString);
}

var startingNodes = new List<string>();
foreach (string node in allStartingNodes) {
    if (node[2] == 'A') {
        startingNodes.Add(node);
    }
}

foreach (string node in startingNodes) {
    string value = node;
    int steps = 0;
    int instructionIndex = 0;
    while (value[2] != 'Z') {
        string paths = (string)map[value];
        string[] pathsArray = paths.Split(',');
        if (instructionsArray[instructionIndex] == 'R') {
            value = pathsArray[1].Trim();
        }
        else if (instructionsArray[instructionIndex] == 'L') {
            value = pathsArray[0].Trim();
        }

        steps++;
        instructionIndex++;
        if (instructionIndex - instructions.Length >= 0)
            instructionIndex = 0;
    }
    Console.WriteLine(steps);
}

