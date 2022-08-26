using System;
using System.Collections.Generic;
using System.Reflection;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        { 
            Type startUp = typeof(StartUp);

            MethodInfo[] methods = startUp.GetMethods(
                BindingFlags.Public
                | BindingFlags.NonPublic
                | BindingFlags.Instance 
                | BindingFlags.Static);

            foreach (var method in methods)
            {
                ICollection<AuthorAttribute> attributes = 
                    (ICollection<AuthorAttribute>)method.GetCustomAttributes<AuthorAttribute>();

                if (attributes.Count > 0)
                {
                    foreach (var attribute in attributes)
                    {
                         Console.WriteLine($"{method.Name} is written by {attribute.Name}");
                    }
                }
            } 
        }
    }
}
