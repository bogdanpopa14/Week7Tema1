using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image
{
    class Program
    {
        static void Main(string[] args)
        {

            using (WebClient wb = new WebClient())
            {

                string fileName = "ss";
                string adress = "https://edia.istockphoto.com/vectors/cartoon-ninja-illustration-vector-id831242374?k=6&m=831242374&s=612x612&w=0&h=oFlsidw155KOEv5DsDvSPGFs06Fbe5Y2mJwGK2NIMpY=";


                try
                {
                    if (fileName == null || fileName.Length == 0)
                    {
                        throw new NoFileNameException();
                    }
                    if (adress == null || adress.Length == 0)
                    {
                        throw new NoAdrerssException();
                    }
                    if (!(LinkExist(adress)))
                    {
                        throw new InvalidLinkException();
                    }

                    wb.DownloadFile(adress, fileName);
                }



                catch (NoFileNameException e)
                {
                    Console.WriteLine($"Nu a fost setat un nume pt fisierul dll {e.StackTrace}");
                }

                catch (NoAdrerssException e)
                {
                    Console.WriteLine($"Adresa este inexistenta {e.StackTrace}");
                }
                catch (InvalidLinkException e)
                {
                    Console.WriteLine($"Linkul este invalid {e.StackTrace}");
                }

                finally
                {
                    if (wb != null)
                        wb.Dispose();
                }

                Console.ReadLine();
            }
        }
        
        public static bool LinkExist(string adress)
        {
            WebRequest req = WebRequest.Create(adress);
            WebResponse res;
            try
            {
                res = req.GetResponse();
            }
            catch
            {
                return false;
            }
            return true;
        }



        [Serializable]
        public class InvalidLinkException : Exception
        {
            public InvalidLinkException() { }
            public InvalidLinkException(string message) : base(message) { }
            public InvalidLinkException(string message, Exception inner) : base(message, inner) { }
            protected InvalidLinkException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }

        [Serializable]
        public class NoAdrerssException : Exception
        {
            public NoAdrerssException() { }
            public NoAdrerssException(string message) : base(message) { }
            public NoAdrerssException(string message, Exception inner) : base(message, inner) { }
            protected NoAdrerssException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }


        [Serializable]
        public class NoFileNameException : Exception
        {
            public NoFileNameException() { }
            public NoFileNameException(string message) : base(message) { }
            public NoFileNameException(string message, Exception inner) : base(message, inner) { }
            protected NoFileNameException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }
    }
}
