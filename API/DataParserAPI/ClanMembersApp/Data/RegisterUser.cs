using ClanMembersApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    Password = fields[(int)FieldConstants.UserRegistrationField.Password],
                    BirthDay = DateTime.Parse(fields[(int)FieldConstants.UserRegistrationField.DateOfBirth]),
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