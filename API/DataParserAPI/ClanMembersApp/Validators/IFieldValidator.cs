using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClanMembersApp.Validators
{
    public delegate bool FieldValidatorDelegate(int fireldIndex,  string fieldValue, string[] fieldArray, out string fieldIvalidMessage);
    public interface IFieldValidator
    {
        void InitialiseValidatorDelegates();
        string[] FieldArray { get; }
        FieldValidatorDelegate FieldValidatorDel { get; }
    }
}
