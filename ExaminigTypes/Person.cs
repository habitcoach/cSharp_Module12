using System;

	public class Person
	{
        public string Name { get; set; }
        public int Age { get; set; }
       

        public Person()
        {
            this.Name = "default";
            this.Age = 0;
            
        }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
           
        }
       // [Obsolete("This is obsolete use new method",false)]

        public void SayHello()
        {
            Console.WriteLine($"Hello, my name is {Name}, and I am {Age} years old.");
        }

   

    }


