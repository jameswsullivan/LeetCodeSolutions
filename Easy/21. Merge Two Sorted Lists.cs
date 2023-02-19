int[] arr1 = new int[3] { 5, 9, 10 };
int[] arr2 = new int[3] { 1, 2, 5 };

ListNode list1 = new ListNode(arr1[0],null);
ListNode list2 = new ListNode(arr2[0],null);
ListNode pointer1 = null, pointer2 = null, result = null, pointer = null ;

pointer1 = list1;
for (int i = 1; i<arr1.Length; i++)
{
    pointer1.next = new ListNode(arr1[i],null);
    pointer1 = pointer1.next;
}

pointer2 = list2;
for (int i = 1; i < arr2.Length; i++)
{
    pointer2.next = new ListNode(arr2[i], null);
    pointer2 = pointer2.next;
}

pointer1 = list1;
while (pointer1 != null)
{
    Console.WriteLine($"List1 Elements: {pointer1.val}");
    pointer1 = pointer1.next;
}
Console.WriteLine();

pointer2 = list2;
while (pointer2 != null)
{
    Console.WriteLine($"List2 Elements: {pointer2.val}");
    pointer2 = pointer2.next;
}
Console.WriteLine();

if (list1.val <= list2.val) result = new ListNode(list1.val, null);
else
{
    pointer = list1; list1 = list2; list2 = pointer;
    result = new ListNode(list1.val, null);
}
pointer = result;
list1 = list1.next;

while (list1 != null && list2 != null)
{
    if ((list1.val - pointer.val) <= (list2.val - pointer.val))
    {
        pointer.next = new ListNode(list1.val, null);
        pointer = pointer.next;
        list1 = list1.next;
    }
    else
    {
        pointer.next = new ListNode(list2.val, null);
        pointer = pointer.next;
        list2 = list2.next;
    }
}

if (list1 == null && list2 != null) pointer.next = list2;
if (list1 != null && list2 == null) pointer.next = list1;

Console.WriteLine($"Merging complete. Final list is:");
pointer = result;
while (pointer != null)
{
    Console.WriteLine($"result elements: {pointer.val}");
    pointer = pointer.next;
}

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}
