namespace StatisticCalculator;

public static class StatisticCalculator
{
    /// <summary>
    /// Метод для вычисления моды
    /// </summary>
    /// <param name="numbers">Числовой ряд</param>
    /// <returns>Мода числового ряда</returns>
    public static double CalculateMode(double[] numbers)
    {
        var mode = numbers.GroupBy(n => n)
            .OrderByDescending(g => g.Count())
            .Select(g => g.Key)
            .FirstOrDefault();
        
        return mode;
    }

    /// <summary>
    /// Метод для вычисления медианы
    /// </summary>
    /// <param name="numbers">Числовой ряд</param>
    /// <returns>Медиана числового ряда</returns>
    public static double CalculateMedian(double[] numbers)
    {
        Array.Sort(numbers);
        int length = numbers.Length;
        
        if (length % 2 == 0)
        {
            return (numbers[length / 2 - 1] + numbers[length / 2]) / 2.0;
        }
        
        return numbers[length / 2];
    }
    
    /// <summary>
    /// Метод для вычисления матожидания
    /// </summary>
    /// <param name="numbers">Числовой ряд</param>
    /// <returns>Матожидание числового ряда</returns>
    public static double CalculateDiscreteExpectation(Dictionary<double, double> numbers) => 
        numbers.Sum(x => x.Key * x.Value);
    
    /// <summary>
    /// Метод для вычисления дисперсии
    /// </summary>
    /// <param name="numbers">Числовой ряд</param>
    /// <returns>Дисперсия числового ряда</returns>
    public static double CalculateVariance(Dictionary<double, double> numbers)
    {
        double mean = CalculateDiscreteExpectation(numbers);

        var result = numbers.Sum(x => Math.Pow(x.Key - mean, 2) * x.Value);
    
        return double.Round(result, 2);
    }
}