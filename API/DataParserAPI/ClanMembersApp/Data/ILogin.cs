using ClanMembersApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClanMembersApp.Data
{
    public interface ILogin
    {
        UserModel Login(string emailAddress, string password); 
    }
}
