#include <stdio.h>

int sum(int* nums, int length) {
    int sum = 0;
    __asm__ (
        "push ebp\n"
        "mov ebp, esp\n"
        "sub esp, 12\n"
        "mov eax, 0\n"
        "mov ecx, %1\n"  // load the array
        "mov esi, 0\n"  // initialize i
        "loop_start:\n"
        "cmp esi, %2\n"  // compare i with the length of the array
        "jge loop_end\n"
        "mov edx, [ecx+esi*4]\n"  // load the current element
        "add eax, edx\n"  // add the element to the sum
        "add esi, 1\n"  // increment i
        "jmp loop_start\n"
        "loop_end:\n"
        "mov esp, ebp\n"
        "pop ebp\n"
        : "+a" (sum)  // output: sum
        : "g" (nums), "g" (length)  // input: nums, length
        : "ecx", "esi", "edx"  // clobbered registers
    );
    return sum;
}

int sum_performant(int* nums, int length) {
    int sum = 0;
    __asm__ (
        "push rbp\n"
        "mov rbp, rsp\n"
        "mov rax, %1\n"  // load the array
        "mov rsi, 0\n"  // initialize i
        "loop_start:\n"
        "cmp rsi, %2\n"  // compare i with the length of the array
        "jge loop_end\n"
        "mov rax, [rbp+rsi*8]\n"  // load the current element
        "add rax, %3\n"  // add the element to the sum
        "add rsi, 1\n"  // increment i
        "jmp loop_start\n"
        "loop_end:\n"
        "mov rsp, rbp\n"
        "pop rbp\n"
        : "+a" (sum)  // output: sum
        : "g" (nums), "g" (length)  // input: nums, length
        : "rax", "rsi", "rbp"  // clobbered registers
    );
    return sum;
}

int main() {
    int nums[] = {1, 2, 3, 4, 5};
    int length = sizeof(nums) / sizeof(nums[0]);
    int resultWithoutIVW = SumBeforeInductionVariableWidening(nums, length);
    int resultWithIVW = SumAfterInductionVariableWidening(nums, length);
    printf("Sum: %d\n", resultWithoutIVW);
    printf("Performant Sum: %d\n", resultWithIVW);
    return 0;
}