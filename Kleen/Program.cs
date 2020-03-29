using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kleen
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] result = SetOrTuple();
            Console.WriteLine("\n");
            foreach (var item in result)
            {
                Console.WriteLine(item.ToString());
            }
            Console.Write("Press any key to close the console app...");
            Console.ReadKey();
        }

        public static string[] SetOrTuple(){
            string[] kleen = new string[10];
            Console.WriteLine("Enter S for Set or T for Tuple: ");
            string setOrTuple = Console.ReadLine();
            setOrTuple = setOrTuple.Trim(' ');
            if (setOrTuple.Length > 1 || string.IsNullOrEmpty(setOrTuple))
            {
                kleen = SetOrTuple();
            }
            else
            {
                if (setOrTuple.Equals("T") || setOrTuple.Equals("t"))
                {
                    string[] listEntry = EntryValidation();
                    kleen = TupleKleen(listEntry);
                }
                else if (setOrTuple.Equals("S") || setOrTuple.Equals("s"))
                {
                    string[] listEntry = EntryValidation();
                    kleen = SetKleen(listEntry);
                }
                else
                {
                    kleen = SetOrTuple();
                }
            }
            return kleen;
        }

        public static string[] SetKleen(string[]  entry)
        {
            string emptyElem = "∅";
            string[] setKleen = new string[10];
            setKleen[0] = emptyElem;
            string concatenated = "";
            int entrySize = entry.Length;

            for (int i=0; i < entrySize; i++)
            {
                setKleen[i+1] = entry[i];
            }

            int setKleenSize = setKleen.Length;
            var random = new Random();

            for (int i = entrySize; i < 9; i++)
            {
                int random1 = random.Next(0, entry.Length);
                concatenated = concatenated + entry[random1];
                string element = concatenated;
                if (setKleen.Any(elementInSetKleen => elementInSetKleen == element))
                {
                    i--;
                }
                else
                {
                    setKleen[i + 1] = element;
                    
                }
            }
            return setKleen;
        }

        public static string[] TupleKleen(string[] entry)
        {
            string emptyElem = "∅";
            string[] tupleKleen = new string[10];
            tupleKleen[0] = emptyElem;
            string concatenated = "";

            for (int i = 0; i < entry.Count(); i++)
            {
                concatenated += entry[i];
            }

            string concatenated2 = concatenated;
            for (int i = 1; i < 10; i++)
            {
                tupleKleen[i] = concatenated;
                concatenated = concatenated + concatenated2;
            }
            return tupleKleen;
        }

        public static string[] EntryValidation()
        {
            string[] lettersAndNumbers = {"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r",
                                          "s","t","u","v","w","x","y","z","0","1","2","3","4","5","6","7","8","9"};
            const char space = ' ';
            int i = 0;
            string[] listEntry = { };

            Console.WriteLine("Enter size (at least 1, at most 3): " );
            string setOrTupleSize = Console.ReadLine();
            if (setOrTupleSize.Length > 1 || string.IsNullOrEmpty(setOrTupleSize))
            {
                Console.WriteLine("Enter a number between 1 and 3.");
                listEntry = EntryValidation();
            }
            else
            {
                char setOrTupleSizeC = Convert.ToChar(setOrTupleSize);
                if (Char.IsNumber(setOrTupleSizeC))
                {
                    int setOrTupleSizeInt = Convert.ToInt32(setOrTupleSize.ToString());
                    listEntry = new string[setOrTupleSizeInt];

                    if (setOrTupleSizeInt > 3 || setOrTupleSizeInt < 1)
                    {
                        Console.WriteLine("Enter a number between 1 and 3.");
                        listEntry = EntryValidation();
                    }
                    else
                    {
                        while (i < setOrTupleSizeInt)
                        {
                            Console.WriteLine("Enter any character among [a-z] or [0-9]: ");
                            string entry = Console.ReadLine();
                            string entrym = entry.Trim(space);

                            if (!lettersAndNumbers.Any(elementInLettersAndNumbers => elementInLettersAndNumbers.Equals(entrym)))
                            {
                                Console.WriteLine("The character must be among [a-z] or [0-9]");
                            }
                            else
                            {
                                if (lettersAndNumbers.Any(elementInLettersAndNumbers => elementInLettersAndNumbers.Equals(entrym)))
                                {
                                    listEntry[i] = entrym;
                                }
                                i++;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Must be a number.");
                    listEntry = EntryValidation();
                }
            }
            return listEntry;
        }


    }
}
