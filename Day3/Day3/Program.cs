List<string> inputTxt = new(File.ReadAllLines(@"..\..\..\input\inputTest.txt"));

int sum = 0;

for (int row = 2; row < inputTxt.Count; row++) {
    for (int col = 2; col < inputTxt[row].Length; col++) {
        if (!char.IsLetterOrDigit(inputTxt[row][col])) {
            int rowAbove = row - 1;
            int rowBelow = row + 1;
            int colLeft = col - 1;
            int colRight = col + 1;

            if (char.IsDigit(inputTxt[rowAbove][colLeft]))
                Console.Write(inputTxt[rowAbove][colLeft]);
                sum += GetNum(rowAbove, colLeft);
            /*if (char.IsDigit(inputTxt[rowAbove][col]))
                sum += GetNum(rowAbove, col);
            if (char.IsDigit(inputTxt[rowAbove][colRight]))
                sum += GetNum(rowAbove, colRight);

            if (char.IsDigit(inputTxt[row][colLeft]))
                sum += GetNum(row, colLeft);
            if (char.IsDigit(inputTxt[row][colRight]))
                sum += GetNum(row, colRight);
                
            if (char.IsDigit(inputTxt[rowBelow][colLeft]))
                sum += GetNum(rowBelow, colLeft);
            if (char.IsDigit(inputTxt[rowBelow][col]))
                sum += GetNum(rowBelow, col);
            if (char.IsDigit(inputTxt[rowBelow][colRight]))
                sum += GetNum(rowBelow, colRight);*/
        }
    }
}

Console.Write(sum);

/*Console.Write(inputTxt[1][3]);
Console.Write(!char.IsLetterOrDigit(inputTxt[1][3]));*/
/*List<char> numChars = new List<char> {'1','1','4'};
Console.Write(int.Parse(string.Join("", numChars)));*/

return;

int GetNum(int row, int col) {
    List<char> numChars = new List<char>();
    while (char.IsDigit(inputTxt[row][col])) {
        col--;
    }
    while (char.IsDigit(inputTxt[row][col])) {
        numChars.Add(inputTxt[row][col]);
        col++;
    }
    Console.Write(numChars);
    int.Parse(string.Join("", numChars));
}