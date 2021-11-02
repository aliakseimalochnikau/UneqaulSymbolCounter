using System;
using System.Collections.Generic;
using System.Linq;

namespace UnequalSymbolsCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            // do-while is used for console being active until closed
            do
            {
                Console.WriteLine("Please enter a sequence of symbols...");
                Console.WriteLine();
                string input = Console.ReadLine();
                Console.WriteLine();
                char[] array = input.ToCharArray();

                int x = CountSymbols(array);

                Console.WriteLine($"Max {x} unequal consecutive symbol(s) in the string entered");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
            while(true);
        }

        public static int CountSymbols(char[] array)
        {
            int _currentMax = 0;
            List<char> _currentSequence = new List<char>();
            List<char> _maxSequence = new List<char>();
            
            for (int k = 0; k < array.Length; k++)
            {
                if (_currentMax > array.Length - (k + 1))
                {
                    break;
                }

                for (int i = k; i < array.Length; i++)
                {
                    if (i == 0)
                    {
                        _currentSequence.Add(array[i]); 
                        _maxSequence.Add(array[i]); 
                        _currentMax = _maxSequence.Count();
                    }
                    else
                    {
                        if (!_maxSequence.Contains(array[i]))
                        {
                            _currentSequence.Add(array[i]);
                        }
                        else 
                        {
                            if (_currentSequence.Count() > _currentMax)
                            {
                                _currentMax = _currentSequence.Count();
                                _currentSequence.Clear();
                                _maxSequence.Clear();
                                break;
                            }
                            else 
                            {
                                _currentSequence.Clear();
                                _maxSequence.Clear();
                                break;
                            }
                        }

                        _maxSequence.Add(_currentSequence.LastOrDefault());
                    }
                }

                if (_currentSequence.Count() > _currentMax) 
                { 
                    _currentMax = _currentSequence.Count();
                    _currentSequence.Clear();
                    _maxSequence.Clear();
                }
            }

            return _currentMax;
        }
    }
}
