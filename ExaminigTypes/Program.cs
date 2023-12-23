using System;
using System.Reflection;


class Program
{
    static void Main()
    {
        // Create an instance of the Person class
        var person = new Person { Name = "John Doe", Age = 30 };
        
        // Get the type information using reflection
        Type typedummy = person.GetType();


        var assembly = Assembly.GetExecutingAssembly();

        var type = assembly.GetType("Person");


        // Inspect properties
        Console.WriteLine("Properties:");

        PropertyInfo[] properties = type.GetProperties();
        foreach (var property in properties)
        {
            Console.WriteLine($"{property.Name}: {property.GetValue(person)}");
        }

        // Inspect methods
        Console.WriteLine("\nMethods:");
        MethodInfo[] methods = type.GetMethods();
        foreach (var method in methods)
        {
            Console.WriteLine($"{method.Name}");
        }

        //Inspect constructors
        Console.WriteLine("Constructors");
        ConstructorInfo[] constructorinfo = type.GetConstructors();
        foreach (var constructor in constructorinfo)
        {
            Console.WriteLine($"{constructor.Name}");
        }

        //invoking method
        MethodInfo sayHelloMethod = type.GetMethod("SayHello");
        sayHelloMethod.Invoke(person, null);
       


        // Invoke the default constructor using reflection
        Person person1 = (Person)Activator.CreateInstance(type);

       

        // Set property values using reflection
        PropertyInfo nameProperty = type.GetProperty("Name");
        nameProperty.SetValue(person1, "Joey");

        PropertyInfo ageProperty = type.GetProperty("Age");
        ageProperty.SetValue(person1, 30);

       

        // Invoke the parameterized constructor using reflection
        object[] constructorArgs = new object[] { "Chandler", 25 };
        Person person2 = (Person)Activator.CreateInstance(type, constructorArgs);

        // Now let's see the details of the created instances
        person2.SayHello();

    }
}
