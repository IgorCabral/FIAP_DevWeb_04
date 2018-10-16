using System;
using System.Collections.Generic;
using System.Text;

namespace fp_stack.web.Models
{
    public class LoginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsPersistent { get; set; }
    }
}
