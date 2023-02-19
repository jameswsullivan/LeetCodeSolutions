if (m == 0) for (int x = 0; x < n; x++) nums1[x] = nums2[x];
else
{
    for (int x = 0; x < n; x++)
        nums1[m + x] = nums2[x];
    Array.Sort(nums1);
}