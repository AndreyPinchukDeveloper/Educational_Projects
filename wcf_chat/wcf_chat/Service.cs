using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace wcf_chat
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service : IServiceChat
    {
        List<ServerUser> users = new List<ServerUser>();
        int nextId = 1;
        public int Connect(string name)
        {
            ServerUser userToAdd = new ServerUser() 
            {
                ID = nextId, 
                Name = name, 
                operationContext = OperationContext.Current 
            };

            nextId++;
            SendMessage(userToAdd.Name + "was connected.", userToAdd.ID);
            users.Add(userToAdd);//adding new user in list
            return userToAdd.ID;
        }

        public void Disconnect(int id)
        {
            var userToRemove = users.FirstOrDefault(i => i.ID == id);
            if (userToRemove != null)
            {
                users.Remove(userToRemove);
                SendMessage(userToRemove.Name + "has left.", userToRemove.ID);
            }
        }

        public void SendMessage(string message, int id)
        {
            
        }
    }
}
