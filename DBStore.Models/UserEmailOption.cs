using System;
using System.Collections.Generic;
using System.Text;

namespace DBStore.Models
{
   public class UserEmailOption
    {
        public List<string> ToEmails { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<KeyValuePair<string, string>> PlaceHolders { get; set; }
    }
}
