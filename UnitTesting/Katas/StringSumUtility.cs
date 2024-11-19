using System;

public class StringSumUtility
{
    public string Sum(string num1, string num2)
    {
        int number1 = ParseNaturalNumber(num1);
        int number2 = ParseNaturalNumber(num2);

        int sum = number1 + number2;
        return sum.ToString();
    }

    private int ParseNaturalNumber(string num)
    {
        if (int.TryParse(num, out int result) && result >= 0)
        {
            return result;
        }
        return 0;
    }
}