using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
        {
            StringBuilder sb = new StringBuilder();

            Type type = Type.GetType(investigatedClass);

            sb.AppendLine($"Class under investigation: {investigatedClass}");
            
            FieldInfo[] fieldsInfo = type.GetFields(
                BindingFlags.NonPublic 
                | BindingFlags.Public
                | BindingFlags.Static 
                | BindingFlags.Instance);

            Object classInstance = Activator.CreateInstance(type, new object[] { });

            foreach (FieldInfo field in fieldsInfo)
            {
                if (requestedFields.Contains(field.Name))
                {
                    sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
