using static StatisticCalculator.StatisticCalculator;

namespace TerVerHw;

class Program
{
    static void Main()
    {
        // Массив чисел
        double[] numbers = { 2, 4, 4, 4, 5, 5, 5, 5, 7, 9 };
        
        // Массив чисел с вероятностями {число, вероятность}
        Dictionary<double, double> numbers2 = new Dictionary<double, double>
        {
            {2, 0.1},
            {4, 0.4},
            {5, 0.5}
        };

        Console.WriteLine($"Моду ряда: {CalculateMode(numbers)}");
        Console.WriteLine($"Медиана ряда: {CalculateMedian(numbers)}");
        Console.WriteLine($"Математическое ожидание: {CalculateDiscreteExpectation(numbers2)}");
        Console.WriteLine($"Дисперсия: {CalculateVariance(numbers2)}");
    }
}