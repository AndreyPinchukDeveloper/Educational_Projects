using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        /// <summary>
        /// Singleton pattern. Only one delegate can be exist ! 
        /// </summary>
        #region Delegates' Properties
        public static CompareFieldsValidDelegate CompareFieldsValidDelegate
        {
            get
            {
                if (_compareFieldsValidDelegate == null)
                    _compareFieldsValidDelegate = new CompareFieldsValidDelegate(CompareFieldsValidDelegate);
                return _compareFieldsValidDelegate;
            }
        }
        public static PatternMatchValidDelegate PatternMatchValidDelegate
        {
            get
            {
                if (_patternMatchValidDelegate == null)
                    _patternMatchValidDelegate = new PatternMatchValidDelegate(PatternMatchValidDelegate);
                return _patternMatchValidDelegate;
            }
        }
        public static DateValidDelegate DateValidDelegate
        {
            get
            {
                if (_dateValidDelegate == null)
                    _dateValidDelegate = new DateValidDelegate(DateValidDelegate);
                return _dateValidDelegate;
            }
        }
        public static RequiredValidDelegate RequiredValidDelegate
        {
            get
            {
                if (_requiredValidDelegate == null) 
                    _requiredValidDelegate = new RequiredValidDelegate(RequiredValidDelegate);
                return _requiredValidDelegate;
            }
        }

        public static StringLengthValidDelegate StringLengthValidDelegate
        {
            get
            {
                if (_stringLengthValidDelegate == null)
                    _stringLengthValidDelegate = new StringLengthValidDelegate(StringLengthValidDelegate);
                return _stringLengthValidDelegate;
            }
        }
        #endregion


        #region Methods
        private static bool RequiredFieldValid(string fieldValue)
        {
            return !String.IsNullOrWhiteSpace(fieldValue) ? true : false;
        }

        private static bool RequiredFieldLengthValid(string fieldValue, int min, int max)
        {
            return fieldValue.Length >= min && fieldValue.Length<= max ? true : false;
        }

        private static bool DateFieldValid(string dateTime, out DateTime validDateTime)
        {
            return DateTime.TryParse(dateTime, out validDateTime) ? true : false;
        }

        private static bool FieldPatternValid(string fieldVal, string regularExpressionPattern)
        {
            Regex regex = new Regex(regularExpressionPattern);
            return regex.IsMatch(fieldVal) ? true : false;
        }

        private static bool FieldComparisonValid(string field1, string field2)
        {
            return field1.Equals(field2) ? true : false;
        }
        #endregion
    }
}
