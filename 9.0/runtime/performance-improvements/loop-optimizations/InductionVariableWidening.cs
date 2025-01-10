using System.Runtime.InteropServices;

public static class InductionVariableWidening {
    /// <summary>
    /// Function that takes an array of int and outputs the summation of all the values
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static int Sum(int[] nums)
    {
        int sum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
        }

        return sum;
    }

    //We will consume the functions from induction_variable_widening using interop services

    [DllImport("induction_variable_widening.so", EntryPoint="sum")]
    static extern int sum(IntPtr nums, int length);
   
    [DllImport("induction_variable_widening.so", EntryPoint="performant_sum")]
    static extern int performant_sum(IntPtr nums, int length);

    public static int SumWithoutIVW(int[] nums, int length){
        
        IntPtr numsPtr = Marshal.AllocHGlobal(length * sizeof(int));
        Marshal.Copy(nums, 0, numsPtr, length);
        int result = sum(numsPtr, length);
        Console.WriteLine("Sum: " + result);
        Marshal.FreeHGlobal(numsPtr);
        return result;
    }

        public static int SumWithIVW(int[] nums, int length){
        IntPtr numsPtr = Marshal.AllocHGlobal(length * sizeof(int));
        Marshal.Copy(nums, 0, numsPtr, length);
        int result = performant_sum(numsPtr, length);
        Console.WriteLine("Sum: " + result);
        Marshal.FreeHGlobal(numsPtr);
        return result;
    }
}