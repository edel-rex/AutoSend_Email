using System;
using AutoSend_Email.Models;

namespace AutoSend_Email.Interface
{
    public interface IEmailService
    {
        void SendEmail(Email request);
    }
}
