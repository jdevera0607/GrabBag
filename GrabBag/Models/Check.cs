using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GrabBag.Models
{
    public class Check
    {
        public static string EmailExists(RegistrationContext context, string email)
        {
            string msg = "";
            if (!string.IsNullOrEmpty(email))
            {
                var customer = context.Registers.FirstOrDefault(
                c => c.EmailAddress.ToLower() == email.ToLower());
                if (customer != null)
                    msg = $"Email address {email} already in use.";
            }
            return msg;
        }
    }
}
