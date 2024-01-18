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
        private EmailExistsDelegate _emailExistsDelegate = null;

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
            return (fieldInvalidMessage == "");
        }
    }       
}           