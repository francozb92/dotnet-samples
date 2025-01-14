; strength_reduction.asm

section .data
nums dd 1, 2, 3, 4, 5
len equ $ - nums

section .text
global strength_reduction

strength_reduction:
    push ebp
    mov ebp, esp
    sub esp, 8

    ; Initialize sum to 0
    mov eax, 0

    ; Get the reference to the start of the array
    mov ecx, nums
    mov edx, len
    mov esi, ecx

    ; Get the reference to the end of the array
    add esi, edx

    ; Loop until we reach the end of the array
    while_loop:
        cmp esi, ecx
        jge end_loop

        ; Add the value at the current pointer to the sum
        mov eax, [esi]
        add eax, [ebp+4] ; [ebp+4] = sum

        ; Increment the pointer
        add esi, 4

        ; Loop again
        jmp while_loop

    end_loop:
        ; Return the sum
        mov [ebp+4], eax
        mov esp, ebp
        pop ebp
        ret

section .data
result dd 0

section .text
global main

main:
    ; Create an array of integers
    mov eax, nums
    mov edx, len

    ; Call the strength_reduction function
    push eax
    push edx
    call strength_reduction
    add esp, 8

    ; Print the result
    mov eax, result
    mov edx, 4
    mov ecx, 1
    int 0x80

    ; Exit the program
    mov eax, 1
    xor ebx, ebx
    int 0x80