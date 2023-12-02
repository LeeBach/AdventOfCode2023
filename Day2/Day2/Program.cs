List<string> inputTxt = new(File.ReadAllLines(@"..\..\..\input\input.txt"));

int sum = 0;

foreach (string inputLine in inputTxt) {
    int redCubes = 0;
    int greenCubes = 0;
    int blueCubes = 0;
    
    string[] splitGame = inputLine.Split(':');
    int gameNumber = int.Parse(splitGame[0].Split(' ')[1]);
    string[] rounds = splitGame[1].Split(';');

    foreach (string round in rounds) {
        string[] cubes = round.Split(',');
        
        foreach (string cube in cubes) {
            string[] splitCube = cube.Split(' ');
            if (splitCube[2] == "red" && int.Parse(splitCube[1]) > redCubes)
                redCubes = int.Parse(splitCube[1]);

            if (splitCube[2] == "green" && int.Parse(splitCube[1]) > greenCubes)
                greenCubes = int.Parse(splitCube[1]);

            if (splitCube[2] == "blue" && int.Parse(splitCube[1]) > blueCubes)
                blueCubes = int.Parse(splitCube[1]);
        }
    }

    sum += redCubes * greenCubes * blueCubes;
}

Console.WriteLine(sum);