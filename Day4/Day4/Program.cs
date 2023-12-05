List<string> inputTxt = new(File.ReadAllLines(@"..\..\..\input\inputTest.txt"));

int sum = 0;
int[] cardCopies = new int[inputTxt.Count];
Console.WriteLine(inputTxt.Count);
cardCopies[0] = 1;

int index = 0;
foreach (string card in inputTxt) {
    string[] cardSplit = card.Split(':', '|');
    int matches = 0;
    
    string thing = cardSplit[1];
    List<string> winList = new List<string>();
    for (int i = 1; i < thing.Length - 1; i += 3)
        winList.Add(string.Join("", new char[] {thing[i], thing[i + 1]}));
    string[] win = winList.ToArray();
    
    thing = cardSplit[2];
    List<string> numList = new List<string>();
    for (int i = 1; i < thing.Length; i += 3)
        numList.Add(string.Join("", new char[] {thing[i], thing[i + 1]}));
    string[] nums = numList.ToArray();
        
    bool hasMatches = win.Any(string.Join("", nums).Contains);
    if (hasMatches) {
        foreach (var num in nums) {
            foreach (var t in win) {
                if (num == t) {
                    matches += 1;
                }
            }
        }
    }
    sum += (int)Math.Pow(2, matches - 1);

    /*for (int i = index; i < cardCopies[index]; i++) {
        for (int j = 0; j < matches; j++) {
            cardCopies[index + j] += 1;
        }
    }*/
}

Console.WriteLine("Part 1: {0}", sum);
//Console.WriteLine("Part 2: {0}", cardCopies.Sum());