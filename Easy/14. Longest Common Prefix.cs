string inputString = String.Empty;
string[] strs = new string[200];

while (true)
{

    inputString = Console.ReadLine();
    inputString = inputString.Replace("[", "");
    inputString = inputString.Replace("]", "");
    inputString = inputString.Replace("\"", "");
    strs = inputString.Split(',');

    Console.WriteLine($"Input String is now: {inputString}");

    int length = strs.Length;
    int shortestStringLength = strs[0].Length;
    string shortestString = String.Empty;

    for (int i = 0; i < length; i++)
        if (strs[i].Length <= shortestStringLength)
        {
            shortestStringLength = strs[i].Length;
            shortestString = strs[i].Substring(0, shortestStringLength);
        }
    Console.WriteLine($"Shortest substring is now: {shortestString}, Shortest string lenght is: {shortestStringLength}, length is: {length}");

    for (int i = shortestStringLength - 1; i >= 0; i--)
    {
        for (int j = 1; j < length; j++)
        {
            if ((strs[0][i] != strs[j][i]) && (shortestString != ""))
                shortestString = shortestString.Remove(i);
        }
    }

    Console.WriteLine($"FINAL Shortest substring is now: {shortestString}");

}