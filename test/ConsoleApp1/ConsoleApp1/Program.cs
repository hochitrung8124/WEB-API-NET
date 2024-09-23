using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var numbers = new List<int> { 1, 2, 3, 4, 5 };

        // Trả về số duy nhất thỏa mãn điều kiện
        var singleNumber = numbers.SingleOrDefault(n => n == 3);
        Console.WriteLine(singleNumber); // Kết quả: 3

        // Trả về giá trị mặc định nếu không tìm thấy
        var noNumber = numbers.SingleOrDefault(n => n == 10);
        Console.WriteLine(noNumber); // Kết quả: 0

        // Trường hợp ném ngoại lệ nếu có nhiều phần tử
        var duplicates = new List<int> { 1, 1, 2 };
        try
        {
            var duplicateResult = duplicates.SingleOrDefault(n => n == 1);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message); // Kết quả: "Sequence contains more than one element"
        }
    }
}