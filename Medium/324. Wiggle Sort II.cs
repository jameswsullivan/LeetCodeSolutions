int[] nums = { 1, 4, 3, 4, 1, 2, 1, 3, 1, 3, 2, 3, 3 };

int i = 0, j = 0, temp = 0;
int lengthLeft = 0, lengthRight = 0;
if (nums.Length % 2 == 0) lengthLeft = lengthRight = nums.Length / 2;
else { lengthLeft = nums.Length / 2 + 1; lengthRight = nums.Length / 2; }

int[] left = new int[lengthLeft], right = new int[lengthRight];

if (nums.Length == 2)
{
    if (nums[0] > nums[1]) { temp = nums[0]; nums[0] = nums[1]; nums[1] = temp; }
}

if (nums.Length >= 3)
{
    //Sort sums first.
    i = 2;
    if (nums[0] > nums[1]) { temp = nums[0]; nums[0] = nums[1]; nums[1] = temp; }

    while (i < nums.Length)
    {
        j = i;
        if (nums[j] >= nums[j - 1])
        {
            i++;
        }
        else
        {
            temp = nums[i]; nums[i] = nums[i - 1]; j = i - 1;
            while (nums[j - 1] >= temp && j - 1 >= 0)
            {
                nums[j] = nums[j - 1];
                j--;
                if (j == 0)
                {
                    break;
                }
            }
            nums[j] = temp;
            i++;
        }
    }
    Console.Write("Sorted nums: ");
    foreach (int x in nums) Console.Write("{0},", x);
    Console.WriteLine("\r\n");
    //sums has been sorted.

    //Divide
    for (int x = 0; x < lengthLeft - 1; x++)
    {
        left[x] = nums[x];
        right[x] = nums[x + lengthLeft];
    }

    if (lengthLeft == lengthRight)
    {
        left[lengthLeft - 1] = nums[lengthLeft - 1];
        right[lengthRight - 1] = nums[nums.Length - 1];
    }
    else
    {
        left[lengthLeft - 1] = nums[lengthLeft - 1];
    }
    Console.Write("Left: ");
    foreach (int x in left) Console.Write("{0},", x);
    Console.WriteLine("\r\n");
    Console.Write("Right: ");
    foreach (int x in right) Console.Write("{0},", x);
    Console.WriteLine("\r\n");

    //Insert
    if (lengthLeft == lengthRight)
    {
        Console.WriteLine($"Length is EVEN");
        for (int x = 0; x < lengthLeft; x++)
        {
            nums[2 * x] = left[lengthLeft - 1 - x];
            nums[2 * x + 1] = right[lengthRight - 1 - x];
        }
        Console.Write("current nums: ");
        foreach (int x in nums) Console.Write("{0},", x);
        Console.WriteLine("\r\n");
    }
    else
    {
        Console.WriteLine($"Length is ODD");
        for (int x = 0; x < lengthLeft - 1; x++)
        {
            nums[2 * x] = left[lengthLeft - 1 - x];
            nums[2 * x + 1] = right[lengthRight - 1 - x];
        }
        nums[nums.Length - 1] = left[0];

        Console.Write("current nums: ");
        foreach (int x in nums) Console.Write("{0},", x);
        Console.WriteLine("\r\n");
    }
}