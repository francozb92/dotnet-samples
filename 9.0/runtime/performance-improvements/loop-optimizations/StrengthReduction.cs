//Base example

static int Sum(int[] nums)
{
    int sum = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        sum += nums[i];
    }

    return sum;
}

//Logically equivalent operation after compilation with the new improvement

static int Sum2(Span<int> nums)
{
    int sum = 0;
    ref int p = ref MemoryMarshal.GetReference(nums);
    ref int end = ref Unsafe.Add(ref p, nums.Length);
    while (Unsafe.IsAddressLessThan(ref p, ref end))
    {
        sum += p;
        p = ref Unsafe.Add(ref p, 1);
    }

    return sum;
}