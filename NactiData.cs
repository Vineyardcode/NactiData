using System;
using System.Globalization;
using System.Text;


namespace NactiData
{
    class NactiData
    {
        static int Main(string[] args)
        {
            // Nastavení kódování pro konzoli na UTF-8 (pro podporu české diakritiky)
            Console.OutputEncoding = Encoding.UTF8;
            try
            {
                // Ověření počtu parametrů
                if (args.Length != 3)
                {
                    throw new ArgumentException("Chyba: Program vyžaduje přesně 3 číselné parametry.");
                }

                // Konverze s ošetřením neplatných hodnot
                if (!double.TryParse(args[0], NumberStyles.Float, CultureInfo.InvariantCulture, out double num1))
                    throw new FormatException($"Neplatný formát čísla: {args[0]}");

                if (!double.TryParse(args[1], NumberStyles.Float, CultureInfo.InvariantCulture, out double num2))
                    throw new FormatException($"Neplatný formát čísla: {args[1]}");

                if (!double.TryParse(args[2], NumberStyles.Float, CultureInfo.InvariantCulture, out double num3))
                    throw new FormatException($"Neplatný formát čísla: {args[2]}");

                // Ověření platných numerických hodnot
                if (double.IsNaN(num1) || double.IsNaN(num2) || double.IsNaN(num3))
                    throw new ArithmeticException("Hodnota NaN není platný vstup");

                if (double.IsInfinity(num1) || double.IsInfinity(num2) || double.IsInfinity(num3))
                    throw new ArithmeticException("Hodnota Infinity není platný vstup");


                double soucet = num1 + num2 + num3;
                double soucin = num1 * num2 * num3;

                // Ošetření dělení nulou
                if (num3 == 0.0)
                {
                    throw new DivideByZeroException("Chyba: Třetí parametr nesmí být nula při dělení.");
                }

                double podil = (num1 + num2) / num3;

                // Použit G formát pro vyšší přesnost výstupu
                Console.WriteLine($"Součet všech tří čísel: {soucet.ToString("G", CultureInfo.InvariantCulture)}");
                Console.WriteLine($"Součin všech tří čísel: {soucin.ToString("G", CultureInfo.InvariantCulture)}");
                Console.WriteLine($"Součet prvních dvou čísel dělený třetím: {podil.ToString("G", CultureInfo.InvariantCulture)}");

                return 0;
            }
            catch (FormatException ex)
            {
                Console.Error.WriteLine($"Chyba: {ex.Message}");
                return 1;
            }
            catch (DivideByZeroException ex)
            {
                Console.Error.WriteLine(ex.Message);
                return 2;
            }
            catch (OverflowException)
            {
                Console.Error.WriteLine("Chyba: Došlo k přetečení při výpočtu (příliš velké/malé číslo)");
                return 3;
            }
            catch (ArithmeticException ex)
            {
                Console.Error.WriteLine($"Chyba numerické operace: {ex.Message}");
                return 4;
            }
            catch (ArgumentException ex)
            {
                Console.Error.WriteLine(ex.Message);
                return 5;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Neočekávaná chyba: {ex.Message}");
                return 99;
            }
        }
    }
}