using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conceito01.Model
{
    public class User
    {
        [JsonProperty("userid")]
        public string UserId { get; set; }
    }
}
