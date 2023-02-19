int[] nums = { 2, 0, 1 };
Console.Write("Original nums: ");
foreach (int x in nums) Console.Write("{0},",x);
Console.WriteLine();

//i is RED, j is GREEN
int i = 0, j = 0, temp = 0;

if (nums.Length == 2)
{
    if (nums[0] > nums[1]) { temp = nums[0]; nums[0] = nums[1]; nums[1] = temp; }
}

if (nums.Length >= 3)
{
    i = 2;
    if (nums[0] > nums[1]) { temp = nums[0]; nums[0] = nums[1]; nums[1] = temp; }

    while (i < nums.Length)
    {
        j = i;
        Console.WriteLine($"BEGIN WHILE i: i={i}, j={j}, nums[i]={nums[i]}, nums[j]={nums[j]}");
        if (nums[j] >= nums[j-1]) {
            Console.WriteLine($"element IN ORDER: i={i}, i will increment");
            i++;
        } else
        {
            temp = nums[i]; nums[i] = nums[i-1]; j = i - 1;
            Console.WriteLine($"element NOT in order: i={i}, j={j}, temp={temp}, nums[i]={nums[i]}, nums[j]={nums[j]}");
            while (nums[j - 1] >= temp && j - 1 >= 0)
            {
                Console.WriteLine($"Looking for insertion pos: i={i}, j={j}, j-1={j-1}, temp={temp}, nums[j]={nums[j]}, nums[j-1]={nums[j-1]}");
                nums[j] = nums[j - 1];
                j--;
                if (j == 0)
                {
                    Console.WriteLine($"j=0, break out of while j"); break;
                }
            }
            Console.WriteLine($"Found pos, j is pos, j={j}, num[j]={nums[j]} will be changed to {temp} and i will be {i+1} next");
            nums[j] = temp;
            i++;
        }
        Console.WriteLine($"END WHILE i: i={i}, j={j}\r\n");
    }
}

Console.Write("Sorted nums: ");
foreach (int x in nums) Console.Write("{0},", x);
Console.WriteLine("\r\n");

