using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        byte[] buffer = new byte[10];
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();
        int length = input.Length;

        // Copy the input string into the buffer
        Buffer.BlockCopy(Encoding.UTF8.GetBytes(input), 0, buffer, 0, length);

        // Print the buffer contents
        Console.WriteLine("Buffer contents:");
        foreach (byte b in buffer)
        {
            Console.Write(b + " ");
        }
        Console.WriteLine();
    }
}
