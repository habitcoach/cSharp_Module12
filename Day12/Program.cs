using System.Reflection;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Net.Http;

namespace test
{
    public class Program
    {

        public static void Main(string[] args)
        {




            // add collection package


            //Assemby information using using Assembly.LoadFrom

            var path = Assembly.GetExecutingAssembly().Location;
            var assembly = Assembly.LoadFrom(path);

            foreach (var type in assembly.GetReferencedAssemblies())
            {

                Console.WriteLine(type.FullName);


            }



            //Assembly info using using Assembly.Load

            //var path01 = Assembly.GetExecutingAssembly().Location;

            //var rawBytes = File.ReadAllBytes(path);

            // var assembly01 = Assembly.Load(rawBytes);
            //Console.WriteLine("********************************");
            //foreach (var type in assembly01.GetReferencedAssemblies())
            //{

            //    Console.WriteLine(type.FullName);
            //}

        }
    }

}

//Both are same in first we read it from path and in the second we read it using file