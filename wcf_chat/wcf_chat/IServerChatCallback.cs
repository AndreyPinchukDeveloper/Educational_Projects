using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace wcf_chat
{
    public interface IServerChatCallback
    {
        [OperationContract(IsOneWay = true)]//isoneway means that the server won't wait answer, do their own job immedeately
        void MessageCallback(string message, int id);
    }
}
