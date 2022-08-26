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

            Type classType = Type.GetType(investigatedClass);

            sb.AppendLine($"Class under investigation: {investigatedClass}");
            
            FieldInfo[] fieldsInfo = classType.GetFields(
                BindingFlags.NonPublic 
                | BindingFlags.Public
                | BindingFlags.Static 
                | BindingFlags.Instance);

            Object classInstance = Activator.CreateInstance(classType, new object[] { });

            foreach (FieldInfo field in fieldsInfo)
            {
                if (requestedFields.Contains(field.Name))
                {
                    sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();

            Type classType = Type.GetType($"StealerModification.{className}");

            FieldInfo[] fieldsInfo = classType.GetFields(
                BindingFlags.NonPublic
                | BindingFlags.Public
                | BindingFlags.Static
                | BindingFlags.Instance);

            MethodInfo[] publicMethodsInfo = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance);

            MethodInfo[] nonPublicMethodsInfo = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (FieldInfo field in fieldsInfo)
            {
                if (field.IsPublic)
                {
                    sb.AppendLine($"{field.Name} must be private!");
                }
            }

            foreach (MethodInfo method in nonPublicMethodsInfo.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }

            foreach (MemberInfo method in publicMethodsInfo.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
