using StatisticCalculator.Response;

namespace StatisticCalculator;

public static class StatisticCalculator
{
    /// <summary>
    /// Метод для вычисления моды
    /// </summary>
    /// <param name="numbers">Числовой ряд</param>
    /// <returns>Мода числового ряда</returns>
    public static BaseResponse CalculateMode(List<Double> numbers)
    {
        var mode = numbers
            .GroupBy(n => n)
            .OrderByDescending(g => g.Count())
            .Select(g => g.Key)
            .FirstOrDefault();
        
        return new OkResponse(mode);
    }

    /// <summary>
    /// Метод для вычисления медианы
    /// </summary>
    /// <param name="numbers">Числовой ряд</param>
    /// <returns>Медиана числового ряда</returns>
    public static BaseResponse CalculateMedian(List<Double> numbers)
    {
        var orderedNumbers = numbers
            .OrderBy(x => x)
            .ToList();
        
        int length = orderedNumbers.Count;
        
        if (length % 2 == 0)
        {
            return new OkResponse((orderedNumbers[length / 2 - 1] + orderedNumbers[length / 2]) / 2.0);
        }
        
        return new OkResponse(orderedNumbers[length / 2]);
    }

    /// <summary>
    /// Метод для вычисления матожидания
    /// </summary>
    /// <param name="numbers">Числовой ряд</param>
    /// <returns>Матожидание числового ряда</returns>
    public static BaseResponse CalculateDiscreteExpectation(Dictionary<double, double> numbers)
    {
        if (numbers.Sum(x => x.Value) > 1 + double.Epsilon)
            return new ErrorResponse("Вероятности в сумме не должны превышать 1");
        
        return new OkResponse(double.Round(numbers.Sum(x => x.Key * x.Value), 2));
    }
    
    /// <summary>
    /// Метод для вычисления дисперсии
    /// </summary>
    /// <param name="numbers">Числовой ряд</param>
    /// <returns>Дисперсия числового ряда</returns>
    public static BaseResponse CalculateVariance(Dictionary<double, double> numbers)
    {
        BaseResponse mean = CalculateDiscreteExpectation(numbers);

        if (mean is ErrorResponse)
            return mean;

        var meanResult = mean as OkResponse;
            
        var result = numbers.Sum(x => Math.Pow(x.Key - (double)meanResult!.Data!, 2) * x.Value);
    
        return new OkResponse(double.Round(result, 2));
    }
}