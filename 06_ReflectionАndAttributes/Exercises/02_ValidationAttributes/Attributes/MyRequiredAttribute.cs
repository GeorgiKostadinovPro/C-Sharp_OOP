using System;

namespace ValidationAttributes.Attributes
{

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            if (obj is string value)
            {
                return !string.IsNullOrEmpty(value);
            }

            return obj != null;
        }
    }
}
