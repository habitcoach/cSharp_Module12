using System;
using System.Reflection;

namespace _3_customAttribute
{
	public class Program
	{
		public static void Main(string[] args) {

            // Create an instance of the Person class
            var person = new Person();

            var person01 = new Person("John", 20);

            

            // Get the type information using reflection
            Type type = person01.GetType();

            var properties = type.GetProperties();
            var attributes = type.GetCustomAttributes(typeof(MaxLengthAttribute));
           
           

                Console.WriteLine(attributes);
            


            if (!IsValid(person01))
            {
                Console.WriteLine("User object is not valid.");
            }
            else
            {
                Console.WriteLine("User object is valid.");
            }

        }

        static bool IsValid(object obj)
        {
            var type = obj.GetType();
            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                var maxLengthAttribute = (MaxLengthAttribute)Attribute.GetCustomAttribute(property, typeof(MaxLengthAttribute));
                if (maxLengthAttribute != null)
                {
                    var value = (string)property.GetValue(obj);
                    if (value != null && value.Length > maxLengthAttribute.MaxLength)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

    }


}

