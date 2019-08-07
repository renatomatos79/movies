using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Movie.Api.Models.Response
{
    [Serializable]
    [DataContract(Name = "MovieTypesResponse", Namespace = "Movie.Api.Models.Response")]
    public class MovieTypesResponse : BaseResponse
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public bool Active { get; set; }

        public static MovieTypesResponse FromModel(Domain.Models.MovieTypes model)
        {
            return new MovieTypesResponse
            {
                Active = model.Active,
                ID = model.Id,
                Name = model.Name,
                Success = true,
                Message = string.Empty
            };
        }
    }
}
