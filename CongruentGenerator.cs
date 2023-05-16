namespace Lab_1
{
    public class CongruentGenerator
    {
        private readonly int _a;
        private readonly int _c;
        private readonly int _m;
        private readonly int _initialValue;
        public int CurrentElement { get; private set; }
        private int SequenceLength { get; set; }
        private int EvenCounter { get; set; }
        private int OddCounter { get; set; }
        private int ZeroCounter { get; set; }
        private int OneCounter { get; set; }
        /// List нужен только для отображения последовательности в двоичном виде
        /// Обработка членов последовательности происходит по мере их генерации 
        private List<int> DecimalList { get; }

        public CongruentGenerator(int a, int c, int m, int initialValue)
        {
            _a = a;
            _c = c;
            _m = m;
            _initialValue = initialValue;
            CurrentElement = initialValue;
            SequenceLength = 0;
            DecimalList = new List<int> { Convert.ToInt32(Convert.ToString(initialValue, 2)) };
        }
        
        /// <summary>
        /// Просто вывод условия
        /// </summary>
        public void PrintInfo()
        {
            Console.WriteLine(
                "Рекуррентное соотношение, определяющее линейный конгруэнтный генератор псевдослучайных последовательностей");
            Console.WriteLine("x(n+1) = ax(n) + c mod m\n");
            Console.WriteLine("a = {0}", _a);
            Console.WriteLine("c = {0}", _c);
            Console.WriteLine("m = {0}", _m);
            Console.WriteLine("x(0) = {0}", _initialValue);
        }

        /// <summary>
        /// Вывод системы счисления, в которой будет записана последовательность
        /// </summary>
        /// <param name="notation"></param>
        public void PrintNotation(int notation)
        {
            switch (notation)
            {
                case 10:
                    Console.WriteLine("\nДесятичное представление последовтельности:");
                    break;
                case 2:
                    Console.WriteLine("\n\nДвоичное представление последовтельности:");
                    break;
            }
        }

        /// <summary>
        /// Вывод значения элемента последовательности в консоль
        /// </summary>
        /// <param name="element"></param>
        public void PrintElement(int element)
        {
            Console.Write("{0} ", element);
        }

        /// <summary>
        /// Вывод последовательности в двоичном виде по 8 бит
        /// </summary>
        public void PrintBinarySequence()
        {
            foreach (var element in DecimalList)
            {
                var numberOfDigits = (int)Math.Floor(Math.Log10(element) + 1);

                if (numberOfDigits < 8) 
                {
                    for (var i = 0; i < 8 - numberOfDigits; i++)
                    {
                        Console.Write(0);
                    }
                }

                Console.Write("{0} ", element);
            }
        }

        /// <summary>
        /// Вычисление следующего элемента, если его значение не совпадает со значением первого
        /// элемента, то увеличиваем счетчики элементов последовательности и четных/нечетных элементов
        /// </summary>
        /// <param name="previousElement"></param>
        /// <returns></returns>
        public void CountCurrentElement(int previousElement)
        {
            CurrentElement = (_a * previousElement + _c) % _m;

            if (!IsCurrentElementEqualsFirst(CurrentElement))
            {
                SequenceLength++;
                var binaryCurrentElement = Convert.ToInt32(Convert.ToString(CurrentElement, 2));
                DecimalList.Add(binaryCurrentElement);
                IncrementEvenOddCounter(CurrentElement);
                IncrementZerosAndOnesCounters(CurrentElement);
            }
        }

        /// <summary>
        /// Определение конца последовательности
        /// </summary>
        /// <param name="currentElement"></param>
        /// <returns></returns>
        public bool IsCurrentElementEqualsFirst(int currentElement)
        {
            return currentElement == _initialValue;
        }

        /// <summary>
        /// Вывод количества четных и нечетных элементов
        /// </summary>
        public void PrintEventOddCounters()
        {
            Console.WriteLine("\nКоличество четных элементов {0}", EvenCounter);
            Console.WriteLine("Количество нечетных элементов {0}", OddCounter);
        }

        /// <summary>
        /// Вывод длины последовательности в консоль
        /// </summary>
        public void PrintSequenceLength()
        {
            Console.WriteLine("\n\nДлина последовательности равна {0} элементов или {1} бит\n", SequenceLength,
                SequenceLength * 8);
        }

        /// <summary>
        /// Подсчет количества четных и нечетных элементов
        /// </summary>
        /// <param name="element"></param>
        private void IncrementEvenOddCounter(int element)
        {
            if (element % 2 == 0)
            {
                EvenCounter++;
            }
            else
            {
                OddCounter++;
            }
        }

        /// <summary>
        /// Увеличиваем счетчики количества нулей и единиц в двоичном представлении
        /// элементов последовательности
        /// </summary>
        /// <param name="element"></param>
        private void IncrementZerosAndOnesCounters(int element)
        {
            var binary = Convert.ToString(element, 2);
            var digits = (int)Math.Floor(Math.Log10(Convert.ToInt32(binary)) + 1);

            if (digits < 8)
            {
                for (var i = 0; i < 8 - digits; i++)
                {
                    ZeroCounter++;
                }
            }

            foreach (var digit in binary)
            {
                switch (digit)
                {
                    case '0':
                        ZeroCounter++;
                        break;
                    case '1':
                        OneCounter++;
                        break;
                }
            }
        }

        /// <summary>
        /// Вывод количества нулей и единиц в последовательности в двоичном виде
        /// </summary>
        public void PrintZerosOnesCounters()
        {
            Console.WriteLine("В одном периоде в битовом представлении выходной последовательности");
            Console.WriteLine("Количество нулей {0}\nКоличество единиц {1}", ZeroCounter, OneCounter);
        }
    }
}
