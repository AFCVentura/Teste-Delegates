using Delegates.Services;

namespace Delegates
{
    // Um delegate que referencia qualquer método que receba dois double
    // como parâmetros e retorne um double
    delegate double BinaryNumericOperation(double n1, double n2);

    // Multicast
    delegate void BinaryNumericOperationMultiCast(double n1, double n2);

    internal class Program
    {
        static void Main(string[] args)
        {
            double a = 10;
            double b = 12;

            BinaryNumericOperation op = CalculationService.Max;
            BinaryNumericOperation op2 = new BinaryNumericOperation(CalculationService.Sum);

            // Multicast
            BinaryNumericOperationMultiCast opmc = CalculationService.ShowSum;
            opmc += CalculationService.ShowMax;

            double result = op(a, b);
            double result2 = op2.Invoke(a, b);
            double result3 = CalculationService.Square(b);

            /*Console.WriteLine(result);
            Console.WriteLine(result2);
            Console.WriteLine(result3);*/

            opmc(a, b);
        }
    }
}
