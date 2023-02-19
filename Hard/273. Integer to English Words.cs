Dictionary<int, string> underTwentyDict = new Dictionary<int, string>() {
    {0, "Zero" }, {1,"One"}, {2,"Two"}, {3,"Three"}, {4, "Four"}, {5, "Five"}, {6, "Six"}, {7, "Seven"}, {8, "Eight"}, {9, "Nine"}, {10, "Ten"},
    {11, "Eleven"},{12, "Twelve"},{13, "Thirteen"},{14, "Fourteen"},{15, "Fifteen"},{16, "Sixteen"},{17, "Seventeen"},{18, "Eighteen"},{19, "Nineteen"}, {20, "Twenty"}
};

Dictionary<int, string> midRangeDict = new Dictionary<int, string>() {
    {2, "Twenty"}, {3, "Thirty"},{4, "Fourty"},{5, "Fifty"},{6, "Sixty"},{7, "Seventy"},{8, "Eighty"},{9, "Ninety"}
};

while (true)
{
    int num = 0;
    char[] hundreds, thousands, millions;
    string finalResult = String.Empty, numString = String.Empty;
    string hResult = String.Empty, tResult = String.Empty, mResult = String.Empty;
    int billions = 0;
    int length = 0;
    hundreds = new char[3]; thousands = new char[3];  millions = new char[3];

    num = Convert.ToInt32(Console.ReadLine());

    if (num < 20)
    {
        finalResult = underTwentyDict[num];
        Console.WriteLine($"FINAL RESULT: {finalResult}$$$");
    } 
    else
    {
        
        numString = num.ToString();
        length = numString.Length;

        switch (length)
        {
            case 2:
                hundreds[0] = '0';
                hundreds[1] = numString[0];
                hundreds[2] = numString[1];

                break;
            case 3:
                hundreds[0] = numString[0];
                hundreds[1] = numString[1];
                hundreds[2] = numString[2];

                break;
            case 4:
                thousands[0] = '0';
                thousands[1] = '0';
                thousands[2] = numString[0];

                hundreds[0] = numString[1];
                hundreds[1] = numString[2];
                hundreds[2] = numString[3];

                break;
            case 5:
                thousands[0] = '0';
                thousands[1] = numString[0];
                thousands[2] = numString[1];

                hundreds[0] = numString[2];
                hundreds[1] = numString[3];
                hundreds[2] = numString[4];

                break;
            case 6:
                thousands[0] = numString[0];
                thousands[1] = numString[1];
                thousands[2] = numString[2];

                hundreds[0] = numString[3];
                hundreds[1] = numString[4];
                hundreds[2] = numString[5];

                break;
            case 7:
                millions[0] = '0';
                millions[1] = '0';
                millions[2] = numString[0];
                
                thousands[0] = numString[1];
                thousands[1] = numString[2];
                thousands[2] = numString[3];

                hundreds[0] = numString[4];
                hundreds[1] = numString[5];
                hundreds[2] = numString[6];

                break;
            case 8:
                millions[0] = '0';
                millions[1] = numString[0];
                millions[2] = numString[1];

                thousands[0] = numString[2];
                thousands[1] = numString[3];
                thousands[2] = numString[4];

                hundreds[0] = numString[5];
                hundreds[1] = numString[6];
                hundreds[2] = numString[7];

                break;
            case 9:
                millions[0] = numString[0];
                millions[1] = numString[1];
                millions[2] = numString[2];

                thousands[0] = numString[3];
                thousands[1] = numString[4];
                thousands[2] = numString[5];

                hundreds[0] = numString[6];
                hundreds[1] = numString[7];
                hundreds[2] = numString[8];

                break;
            case 10:
                billions = numString[0];

                millions[0] = numString[1];
                millions[1] = numString[2];
                millions[2] = numString[3];

                thousands[0] = numString[4];
                thousands[1] = numString[5];
                thousands[2] = numString[6];

                hundreds[0] = numString[7];
                hundreds[1] = numString[8];
                hundreds[2] = numString[9];

                break;
            default:
                break;
        }

        Console.WriteLine($"{billions} billions, {String.Join("",millions)} millions, {String.Join("",thousands)} thousands, {String.Join("",hundreds)} hundreds, length is {length}");

        string processThreeDigits(char dChar, char tChar, char hChar)
        {
            string tempResult = String.Empty;
            int d = 0, t = 0, h = 0;

            d = (int)Char.GetNumericValue(dChar); t = (int)Char.GetNumericValue(tChar); h = (int)Char.GetNumericValue(hChar);

            if (d == 0 && t == 0 && h == 0) tempResult = "";
            else if (d == 0 && t == 0 && h != 0) tempResult = underTwentyDict[h] + " Hundred";
            else if ((t * 10 + d) < 20 && (t * 10 + d) != 0)
            {
                if (h == 0) tempResult = underTwentyDict[t * 10 + d];
                else { tempResult = underTwentyDict[t * 10 + d]; tempResult = tempResult.Insert(0, underTwentyDict[h] + " Hundred "); }
            }
            else
            {
                if (d == 0 && t != 0)
                {
                    tempResult = midRangeDict[t];
                    if (h != 0) tempResult = tempResult.Insert(0, underTwentyDict[h] + " Hundred ");
                }
                else
                {
                    tempResult = underTwentyDict[d];
                    tempResult = tempResult.Insert(0, midRangeDict[t] + " ");
                    if (h != 0) tempResult = tempResult.Insert(0, underTwentyDict[h] + " Hundred ");
                }
            }
            Console.WriteLine($"TEMP RESULT: {tempResult}");

            return tempResult;
        }

        if (length == 2 || length == 3) finalResult = processThreeDigits(hundreds[2], hundreds[1], hundreds[0]);
        if (length >= 4 && length <= 6)
        {
            hResult = processThreeDigits(hundreds[2], hundreds[1], hundreds[0]);
            tResult = processThreeDigits(thousands[2], thousands[1], thousands[0]);
            if (hResult != "") finalResult = tResult + " Thousand " + hResult;
            else finalResult = tResult + " Thousand";
        }
        if (length >= 7 && length <= 9)
        {
            hResult = processThreeDigits(hundreds[2], hundreds[1], hundreds[0]);
            tResult = processThreeDigits(thousands[2], thousands[1], thousands[0]);
            mResult = processThreeDigits(millions[2], millions[1], millions[0]);
            if (hResult != "" && tResult != "") finalResult = mResult + " Million " + tResult + " Thousand " + hResult;
            else if (hResult == "" && tResult != "") finalResult = mResult + " Million " + tResult + " Thousand";
            else if (hResult != "" && tResult == "") finalResult = mResult + " Million " + hResult;
            else if (hResult == "" && tResult == "") finalResult = mResult + " Million";
        }
        if (length == 10)
        {
            billions = num / 1000000000;
            hResult = processThreeDigits(hundreds[2], hundreds[1], hundreds[0]);
            tResult = processThreeDigits(thousands[2], thousands[1], thousands[0]);
            mResult = processThreeDigits(millions[2], millions[1], millions[0]);

            if (hResult != "" && tResult != "" && mResult != "") finalResult = underTwentyDict[billions] + " Billion " + mResult + " Million " + tResult + " Thousand " + hResult;
            else if (hResult == "" && tResult != "" && mResult != "") finalResult = underTwentyDict[billions] + " Billion " + mResult + " Million " + tResult + " Thousand";
            else if (hResult == "" && tResult == "" && mResult != "") finalResult = underTwentyDict[billions] + " Billion " + mResult + " Million";
            else if (hResult == "" && tResult == "" && mResult == "") finalResult = underTwentyDict[billions] + " Billion";
            else if (hResult == "" && tResult != "" && mResult == "") finalResult = underTwentyDict[billions] + " Billion " + tResult + " Thousand";
            else if (hResult != "" && tResult == "" && mResult != "") finalResult = underTwentyDict[billions] + " Billion " + mResult + " Million " + hResult;
            else if (hResult != "" && tResult == "" && mResult == "") finalResult = underTwentyDict[billions] + " Billion " + hResult;
            else if (hResult != "" && tResult != "" && mResult == "") finalResult = underTwentyDict[billions] + " Billion " + tResult + " Thousand" + hResult;
        }

        Console.WriteLine($"FINAL RESULT: {finalResult}$$$");

    }

}