List<string> inputTxt = new(File.ReadAllLines(@"..\..\..\input\input.txt"));

int sum = 0;
int[] cardCopies = new int[inputTxt.Count];
Console.WriteLine("# of Cards: {0}", inputTxt.Count);

int index = 0;
foreach (string card in inputTxt) {
    cardCopies[index] += 1;
    string[] cardSplit = card.Split(':', '|');
    int matches = 0;

    string[] win = ParseToArray(cardSplit[1]);
    string[] nums = ParseToArray(cardSplit[2]);
        
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
    //Console.WriteLine("# of Matches:{0}", matches);

    //Console.WriteLine("# of copies of card @ index[{0}]: {1}", index, cardCopies[index]);
    //Console.WriteLine("----");

    for (int i = 1; i <= matches; i++) {
        cardCopies[index + i] += cardCopies[index];
    }
    index++;
}

Console.WriteLine("Part 1: {0}", sum);
Console.WriteLine("Part 2: {0}", cardCopies.Sum());
return;



string[] ParseToArray(string thing) {
    List<string> list = new List<string>();
    for (int i = 1; i < thing.Length - 1; i += 3)
        list.Add(string.Join("", new char[] {thing[i], thing[i + 1]}));
    return list.ToArray();
}