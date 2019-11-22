using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = 1;
            int end = 100;
            int nr_use = 10;
            
            int comp = start;
            
            List<int> lista = new List<int>();
            for ( int i = 0; i < nr_use; i++)
            {
                try
                {
                    int a = ReadNumber(start, end);
                    if (comp < a)
                    {
                        comp = a;
                        lista.Add(a);
                    }
                    else
                    {
                        
                        throw new FalseInequality();
                        
                    }
                }
                catch(FalseInequality e)
                {
                    Console.WriteLine("Nu respecta egalitatea");
                    break;
                }
            }
            if(lista.Count==nr_use)
            {
                Console.Write($"{start}<");
                for (int i = 0; i < lista.Count; i++)
                {
                    Console.Write($"{lista[i]}<");
                }
                Console.Write($"{end}");
            }
            
           
            Console.ReadLine();
        }


        public static int ReadNumber(int start, int end)
        {
            int nr;
            Console.WriteLine($"Introduceti un nr intre: {start}-{end}");
            try
            {
                 nr = Convert.ToInt32(Console.ReadLine());
                if (nr < start || nr > end)
                {
                    throw new OutOfRangeException();
                }
                return nr;
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Formatul introdus este gresit {e.StackTrace}");
            }

            catch (OutOfRangeException e)
            {
                Console.WriteLine($"Numarul introdus nu apartine intervalului cerut {e.StackTrace}");
            }

            return 0;

        }
    
    }

    [Serializable]
    public class FalseInequality : Exception
    {
        public FalseInequality() { }
        public FalseInequality(string message) : base(message) { }
        public FalseInequality(string message, Exception inner) : base(message, inner) { }
        protected FalseInequality(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

public class OutOfRangeException : Exception
{
    public OutOfRangeException() { }
    public OutOfRangeException(string message) : base(message) { }
    public OutOfRangeException(string message, Exception inner) : base(message, inner) { }
    protected OutOfRangeException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}
}
