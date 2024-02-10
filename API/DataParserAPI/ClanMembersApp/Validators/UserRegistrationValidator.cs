using FieldValidatorAPI;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClanMembersApp.Validators
{
    public class UserRegistrationValidator : IFieldValidator
    {
        const int FIRST_NAME_MIN_LENGTH = 2;
        const int FIRST_NAME_MAX_LENGTH = 100;
        const int LAST_NAME_MIN_LENGTH = 2;
        const int LAST_NAME_MAX_LENGTH = 100;

        delegate bool EmailExistsDelegate(string emailAddress);

        private FieldValidatorDelegate _fieldValidatorDelegate = null;
        private RequiredValidDelegate _requiredValidDelegate = null;
        private StringLengthValidDelegate _stringLengthValidDelegate = null;
        private DateValidDelegate _dateValidDelegate = null;
        private PatternMatchValidDelegate _patternMatchValidDelegate = null;
        private CompareFieldsValidDelegate _compareFieldsValidDelegate = null;
        //private EmailExistsDelegate _emailExistsDelegate = null;

        private string[] _fieldArray = null;
        public string[] FieldArray
        {
            get 
            {
                if (_fieldArray == null)
                    _fieldArray = new string[Enum.GetValues(typeof(FieldConstants.UserRegistrationField)).Length];
                return _fieldArray;
            }
        }

        public FieldValidatorDelegate FieldValidatorDel => _fieldValidatorDelegate;
        public UserRegistrationValidator()
        {
            
        }

        public void InitialiseValidatorDelegates()
        {
            _fieldValidatorDelegate = new FieldValidatorDelegate(ValidField);

            _requiredValidDelegate = CommonFieldValidatorFunctions.RequiredValidDelegate;
            _stringLengthValidDelegate = CommonFieldValidatorFunctions.StringLengthValidDelegate;
            _dateValidDelegate = CommonFieldValidatorFunctions.DateValidDelegate;
            _patternMatchValidDelegate = CommonFieldValidatorFunctions.PatternMatchValidDelegate;
            _compareFieldsValidDelegate = CommonFieldValidatorFunctions.CompareFieldsValidDelegate;
        }   

        private bool ValidField(int fieldIndex, string fieldValue, string[] fieldArray, out string fieldInvalidMessage)
        {
            fieldInvalidMessage = "";
            FieldConstants.UserRegistrationField userRegistrationField = (FieldConstants.UserRegistrationField)fieldIndex;
            switch(userRegistrationField)
            {
                case FieldConstants.UserRegistrationField.EmailAddress:
                    fieldInvalidMessage = (!_requiredValidDelegate(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_patternMatchValidDelegate(fieldValue, RegularExpressionValidationPatterns.Email_Address_RegEx_Pattern)) ? $"You must enter valid email address:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationField.FirstName:
                    fieldInvalidMessage = (!_requiredValidDelegate(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_stringLengthValidDelegate(fieldValue, FIRST_NAME_MIN_LENGTH, FIRST_NAME_MAX_LENGTH)) ? $"The length for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)} must be between {FIRST_NAME_MIN_LENGTH} and {FIRST_NAME_MAX_LENGTH}{Environment.NewLine}" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationField.LastName:
                    fieldInvalidMessage = (!_requiredValidDelegate(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_stringLengthValidDelegate(fieldValue, LAST_NAME_MIN_LENGTH, LAST_NAME_MAX_LENGTH)) ? $"The length for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)} must be between {LAST_NAME_MIN_LENGTH} and {LAST_NAME_MAX_LENGTH}{Environment.NewLine}" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationField.Password:
                    fieldInvalidMessage = (!_requiredValidDelegate(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_patternMatchValidDelegate(fieldValue, RegularExpressionValidationPatterns.Strong_Password_RegEx_Pattern)) ? $"Your password must contain at least 1 small-case letter, 1 capital letter, 1 special character and the length should be between 6 - 10 characters {Environment.NewLine}" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationField.PasswordToCompare:
                    fieldInvalidMessage = (!_requiredValidDelegate(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_compareFieldsValidDelegate(fieldValue, fieldArray[(int)FieldConstants.UserRegistrationField.Password])) ? $"Your entry did not match your password{Environment.NewLine}" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationField.DateOfBirth:
                    fieldInvalidMessage = (!_requiredValidDelegate(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_dateValidDelegate(fieldValue, out DateTime validDateTime)) ? $"You did not enter valid date !" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationField.PhoneNumber:
                    fieldInvalidMessage = (!_requiredValidDelegate(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_patternMatchValidDelegate(fieldValue, RegularExpressionValidationPatterns.Uk_PhoneNumber_RegEx_Pattern)) ? $"You did not enter valid phone number !" : fieldInvalidMessage;
                    break;
                case FieldConstants.UserRegistrationField.AddressFirstLine:
                    fieldInvalidMessage = (!_requiredValidDelegate(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    break;
                case FieldConstants.UserRegistrationField.AddressSecondLine:
                    fieldInvalidMessage = (!_requiredValidDelegate(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    break;
                case FieldConstants.UserRegistrationField.AddressCity:
                    fieldInvalidMessage = (!_requiredValidDelegate(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    break;
                case FieldConstants.UserRegistrationField.PostCode:
                    fieldInvalidMessage = (!_requiredValidDelegate(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_patternMatchValidDelegate(fieldValue, RegularExpressionValidationPatterns.Uk_Post_Code_RegEx_Pattern)) ? $"You did not enter valid post code !" : fieldInvalidMessage;
                    break;
                default:
                    throw new ArgumentException("This field does not exists");
            }
            return (fieldInvalidMessage == "");
        }
    }       
}           