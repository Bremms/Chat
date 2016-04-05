using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ChatApp.Models;
using Microsoft.AspNet.SignalR;
using ChatApp.Models.MessageModels;
using System.Collections.Concurrent;

namespace ChatApp.PConn
{
    public class ChatConnection : PersistentConnection
    {
        protected override Task OnConnected(IRequest request, string connectionId)
        {
            Message message;
            try
            {
            var groupname = request.Cookies["GroupNameChat"].Value;
            var username = request.Cookies["UserNameChat"].Value;
            Groups.Add(connectionId, groupname);
            message = new Message(String.Format("Welcome to {0} {1}!",groupname,username),"Server",connectionId,0);
            }catch(Exception e)
            {
                message = new Message("Your request is invalid please try again", "Server", connectionId, 0);
            }
            
            return Connection.Send(connectionId, message);
        }

        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            Message message;
            string groupname;
            try
            {
            groupname = request.Cookies["GroupNameChat"].Value;
            var username = request.Cookies["UserNameChat"].Value;
            message = new Message(data, username, connectionId,1);
            }
            catch (Exception e)
            {
                message = new Message("Your request is invalid please try again", "Server", connectionId, 1);
                return Connection.Send(connectionId, message);
            }
            return Groups.Send(groupname, message);
           // return Connection.Broadcast(data);
        }
    }
}