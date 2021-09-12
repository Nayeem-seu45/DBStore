using System;
using System.Collections.Generic;
using System.Text;

namespace DBStore.Models.VModels
{
   public class LoginRegisterVM
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string LoginEmail { get; set; }
        public string RegisterPassword { get; set; }
        public string ConfirmRegisterPassword { get; set; }
        public string LoginPassword { get; set; }
        public string ReturnUrl { get; set; }
        public string IncorrectInput { get; set; }
    }
}
