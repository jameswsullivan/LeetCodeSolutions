string a, b;

while (true)
{
    a = Console.ReadLine();
    b = Console.ReadLine();

    int[] intA, intB;
    string result;
    int highestDigit;

    if (a.Length <= b.Length)
    {
        intA = new int[b.Length];
        intB = new int[a.Length];
        for (int x = 0; x < b.Length; x++)
            intA[x] = (int)Char.GetNumericValue(b[x]);
        for (int x = 0; x < a.Length; x++)
            intB[x] = (int)Char.GetNumericValue(a[x]);
    }
    else
    {
        intA = new int[a.Length];
        intB = new int[b.Length];
        for (int x = 0; x < a.Length; x++)
            intA[x] = (int)Char.GetNumericValue(a[x]);
        for (int x = 0; x < b.Length; x++)
            intB[x] = (int)Char.GetNumericValue(b[x]);
    }

    for (int x = intA.Length - 1; x >= 0; x--)
    {
        intA[x] += intB[x - intA.Length + intB.Length];
        if (x - intA.Length + intB.Length == 0) break;
    }

    result= String.Join("", intA);

    Console.WriteLine(result);

    for (int x = intA.Length - 1; x >=1; x--)
    {
        intA[x - 1] = intA[x - 1] + intA[x] / 2;
        intA[x] = intA[x] % 2;
    }

    if (intA[0] < 2) result = String.Join("", intA);
    else
    {
        highestDigit =  intA[0] / 2;
        intA[0] %= 2;
        result = highestDigit + String.Join("", intA);
    }

    Console.WriteLine(result);

}