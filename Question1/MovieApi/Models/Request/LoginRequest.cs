using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Movie.Api.Models.Request
{

    [Serializable]
    [DataContract(Name = "LoginRequest", Namespace = "Movie.Api.Models.Request")]
    public class LoginRequest
    {
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
}
