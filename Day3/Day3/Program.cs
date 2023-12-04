using System.Data;

List<string> inputTxt = new(File.ReadAllLines(@"..\..\..\input\input.txt"));

for (int row = 0; row < inputTxt.Count; row++) {
    for (int col = 0; col < inputTxt[row].Length; col++) {
        if (!char.IsLetterOrDigit(inputTxt[row][col])) {
            int rowAbove = row - 1;
            int rowBelow = row + 1;
            int colLeft = col - 1;
            int colRight = col + 1;

            if (char.IsLetterOrDigit(inputTxt[rowAbove][colLeft]))
                sum += getNum(rowAbove, colLeft);

            /*
            if (char.IsLetterOrDigit(inputTxt[rowAbove][col]))
            if (char.IsLetterOrDigit(inputTxt[rowAbove][colRight]))
                
            if (char.IsLetterOrDigit(inputTxt[row][colLeft]))
            if (char.IsLetterOrDigit(inputTxt[row][colRight]))
                
            if (char.IsLetterOrDigit(inputTxt[rowBelow][colLeft]))
            if (char.IsLetterOrDigit(inputTxt[rowBelow][col]))
            if (char.IsLetterOrDigit(inputTxt[rowBelow][colRight]))
            */
        }
    }
}

int getNum(int row, int col) {
    int digits = 0;
    List<char> numChars = new List<char> {};
    while (char.IsDigit(inputTxt[row][col])) {
        col--;
    }
    while (char.IsDigit(inputTxt[row][col])) {
        numChars.Add(inputTxt[row][col]);
        digits++;
        col++;
    }
    return Int32.Parse("".join(numChars));
}