List<string> inputTxt = new(File.ReadAllLines(@"..\..\..\input\input.txt"));

const int redNum = 12;
const int greenNum = 13;
const int blueNum = 14;

int sum = 0;

foreach (string inputLine in inputTxt) {
    bool gamePossible = true;
    
    string[] splitGame = inputLine.Split(':');
    int gameNumber = int.Parse(splitGame[0].Split(' ')[1]);
    string[] rounds = splitGame[1].Split(';');

    foreach (string round in rounds) {
        string[] cubes = round.Split(',');
        
        foreach (string cube in cubes) {
            string[] splitCube = cube.Split(' ');
            if (splitCube[2] == "red" && int.Parse(splitCube[1]) > redNum)
                gamePossible = false;

            if (splitCube[2] == "green" && int.Parse(splitCube[1]) > greenNum)
                gamePossible = false;

            if (splitCube[2] == "blue" && int.Parse(splitCube[1]) > blueNum)
                gamePossible = false;
        }
    }
    if (gamePossible) sum += gameNumber;
}

Console.WriteLine(sum);