using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationValidation.Models
{
    public static class Check
    {
        // Check if null 
        public static string EmailExists(RegistrationContext context, string email)
        {
            string msg = "";
            if (!string.IsNullOrEmpty(email))
            {
                var customer = context.Customers.FirstOrDefault(
                    c => c.EmailAddress.ToLower() == email.ToLower());
                if (customer != null)
                    msg = $"Email address {email} already in use.";
            }
            return msg;
        }
    }
}
