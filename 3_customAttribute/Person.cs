using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace _3_customAttribute
{

	
	
	public class Person
	{
		[MaxLength(3)]
		[Required]
		public string Name { get; set; }

		public int Age { get; set; }

		
		public Person()
		{

		}
		public Person(string name, int age)
		{
			this.Age = age;
			this.Name = name;
		}
	}
}

