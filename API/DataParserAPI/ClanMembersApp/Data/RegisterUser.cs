using ClanMembersApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClanMembershipApplication.Models;
using ClanMembersApp.Validators;

namespace ClanMembersApp.Data
{
    public class RegisterUser:IRegister
    {
        public bool Register(string[] fields)
        {
            using(var dbContext = new ClanMembersDbContext())
            {
                UserModel user = new UserModel()
                {
                    EmailAddress = fields[(int)FieldConstants.UserRegistrationField.EmailAddress],
                    FirstName = fields[(int)FieldConstants.UserRegistrationField.FirstName],
                    LastName = fields[(int)FieldConstants.UserRegistrationField.LastName],
                    MiddleName = fields[(int)FieldConstants.UserRegistrationField.MiddleName],
                    Password = fields[(int)FieldConstants.UserRegistrationField.Password],
                    BirthDay = fields[(int)FieldConstants.UserRegistrationField.BirthDay],
                    PhoneNumber = fields[(int)FieldConstants.UserRegistrationField.PhoneNumber],
                    AddressFirstLine = fields[(int)FieldConstants.UserRegistrationField.AddressFirstLine],
                    AddressSecondLine = fields[(int)FieldConstants.UserRegistrationField.AddressSecondLine],
                    AddressCity = fields[(int)FieldConstants.UserRegistrationField.AddressCity],
                    PostCode = fields[(int)FieldConstants.UserRegistrationField.PostCode],
                };
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
            }

            
            return true;
        }

        public bool EmailExists(string emailAddress)
        {
            bool emailExists = false;

            using(var dbContext = new ClanMembersDbContext())
            {
                emailExists = dbContext.Users.Any(user => user.EmailAddress.ToLower().Trim() == emailAddress.Trim().ToLower());
            }
            return emailExists;// it return false
        }
    }
}