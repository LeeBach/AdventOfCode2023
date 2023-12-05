using System.Text.RegularExpressions;

List<string> inputTxt = new(File.ReadAllLines(@"..\..\..\input\input.txt"));

int sum = 0;

foreach (string card in inputTxt) {
    string[] cardSplit = card.Split(':', '|');
    
    string thing = cardSplit[1];
    List<string> winList = new List<string>();
    for (int i = 1; i < thing.Length - 1; i += 3) {
        winList.Add(string.Join("", new char[] {thing[i], thing[i + 1]}));
    }
    string[] win = winList.ToArray();
    
    thing = cardSplit[2];
    List<string> numList = new List<string>();
    for (int i = 1; i < thing.Length; i += 3) {
        numList.Add(string.Join("", new char[] {thing[i], thing[i + 1]}));
    }
    string[] nums = numList.ToArray();
    
    int score = (win.Any(string.Join("", nums).Contains)) ? 1 : 0;
    foreach (var num in nums) {
        for (int i = 0; i < win.Length; i++) {
            if (num == win[i]) {
                score *= 2;
            }
        }
    }
    sum += (score / 2);
}

Console.WriteLine(sum);