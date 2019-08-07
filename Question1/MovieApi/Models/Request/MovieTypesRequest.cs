using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Movie.Api.Models.Request
{
    [Serializable]
    [DataContract(Name = "MovieTypesRequest", Namespace = "Movie.Api.Models.Request")]
    public class MovieTypesRequest
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public bool Active { get; set; }
    }
}
