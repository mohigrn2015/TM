﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TM.Entity.Request.Entity
{
    public class TokenValidationRequest : CommonRequestModel
    {
        public string tokenProviderId { get; set; }
        public int userId { get; set; }
    }
}
