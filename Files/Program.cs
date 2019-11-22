using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\ls.txt";


            try
            {
                
                
                if(!(File.Exists(path)))
                {
                    throw new NoExist();
                }
                    
                string text = File.ReadAllText(path);
                if(text.Length==0)
                {
                    throw new EmptyException();
                }
                Console.WriteLine(text);

            }
            catch(NoExist e)
            {
                Console.WriteLine($"Fisierul nu exista {e.StackTrace}");
            }

            catch(EmptyException e)
            {
                Console.WriteLine($"Fisierul este gol {e.StackTrace}");
            }
                
                
                Console.ReadLine();
        }
    }


    [Serializable]
    public class EmptyException : Exception
    {
        public EmptyException() { }
        public EmptyException(string message) : base(message) { }
        public EmptyException(string message, Exception inner) : base(message, inner) { }
        protected EmptyException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class NoExist : Exception
    {
        public NoExist() { }
        public NoExist(string message) : base(message) { }
        public NoExist(string message, Exception inner) : base(message, inner) { }
        protected NoExist(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
