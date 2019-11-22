using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsArr
{
    class Program
    {
        static void Main(string[] args)
        {
            BitArray vec = new BitArray(5);
            vec[1] = 1;
            if(vec[1]==vec[3])
            { Console.WriteLine("true"); }
            else { Console.WriteLine("false"); }
            foreach (var item in vec)
            {
                Console.Write(item);
            }
            Console.ReadLine();
            
        }
    }

    public class BitArray:IEnumerable<int>
    {
        private int[] vect = new int[64];
        private ulong nr;
        public BitArray(ulong a)
        {
            for (int i = 0; i < vect.Length; i++)
            {
                vect[i] = 0;
            }
            int c = 63;
            this.nr = a;
            while(nr>0)
            {
                vect[c] = (int)(nr % (ulong)2);
                nr = nr / 2;
                c--;
            }
        }
        
        public void Print()
        {
            for (int i = 0; i < vect.Length; i++)
            {
                Console.Write(vect[i]);
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < 64; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public int this[int index]
        {
            get { return vect[index]; }
            set
            {
                try
                {
                    if (value == 1 || value == 0)
                    { vect[index] = value; }

                    else
                    {
                        throw new DiferentException();
                    }
                }
                catch(DiferentException e)
                {
                    Console.WriteLine($"Ati introdus o alta valoare de 1 sau 0 {e.StackTrace}");
                    
                }
            }
        }
    }

    [Serializable]
    public class DiferentException : Exception
    {
        public DiferentException() { }
        public DiferentException(string message) : base(message) { }
        public DiferentException(string message, Exception inner) : base(message, inner) { }
        protected DiferentException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
