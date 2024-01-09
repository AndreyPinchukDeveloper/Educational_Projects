using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldValidatorAPI
{
    public delegate bool RequiredValidDelegate(string fieldValue);
    public delegate bool StringLengthValidDelegate(string fieldValue, int min, int max);
    public delegate bool DateValidDelegate(string fieldValue, out DateTime validDate);
    public delegate bool PatternMatchValidDelegate(string fieldValue, string pattern);
    public delegate bool CompareFieldsValidDelegate(string fieldValue, string fieldValCompare);
    sealed class CommonFieldValidatorFunctions
    {

        private static RequiredValidDelegate _requiredValidDelegate = null;
        private static StringLengthValidDelegate _stringLengthValidDelegate = null;
        private static DateValidDelegate _dateValidDelegate = null;
        private static PatternMatchValidDelegate _patternMatchValidDelegate = null;
        private static CompareFieldsValidDelegate _compareFieldsValidDelegate = null;

        private static bool RequiredValidDelegate(string fieldValue)
        {
            return !String.IsNullOrWhiteSpace(fieldValue) ? true : false;
        }
    }
}
