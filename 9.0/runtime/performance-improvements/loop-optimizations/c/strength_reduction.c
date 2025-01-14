#include <stdio.h>
#include <stdlib.h>
#include <stdint.h>

//original code
int sum(int* nums, int len) {
    int sum = 0;
    for (int i = 0; i < len; i++) {
        sum += nums[i];
    }
    return sum;
}
//reduced strength logically equivalent code
int sum2(int* nums, int len) {
    int sum = 0;
    int* p = nums;
    int* end = p + len;
    while (p < end) {
        sum += *p;
        p++;
    }
    return sum;
}

int main() {
    int nums[] = {1, 2, 3, 4, 5};
    int len = sizeof(nums) / sizeof(nums[0]);
    int result = sum2(nums, len);
    printf("Result: %d\n", result);
    return 0;
}