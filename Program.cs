namespace Lab_1
{
    internal abstract class Program
    {
        private static void Main()
        {
            const int dec = 10;
            const int bin = 2;

            CongruentGenerator generator = new(53, 23, 187, 10);

            generator.PrintInfo();
            generator.PrintNotation(dec);
            generator.PrintElement(generator.CurrentElement);
            generator.CountCurrentElement(generator.CurrentElement);
            
            do
            {
                generator.CountCurrentElement(generator.CurrentElement);

                if (generator.IsCurrentElementEqualsFirst(generator.CurrentElement))
                {
                    break;
                }

                generator.PrintElement(generator.CurrentElement);
                
            } while (true);

            generator.PrintNotation(bin);
            generator.PrintBinarySequence();
            generator.PrintSequenceLength();
            generator.PrintZerosOnesCounters();
            generator.PrintEventOddCounters();

            Console.ReadKey();
        }
    }
}