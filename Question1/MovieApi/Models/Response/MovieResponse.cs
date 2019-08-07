using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Movie.Api.Models.Response
{
    [Serializable]
    [DataContract(Name = "MovieListResponse", Namespace = "Movie.Api.Models.Response")]
    public class MovieListResponse : BaseListResponse<MovieResponse> { }

    [Serializable]
    [DataContract(Name = "MovieResponse", Namespace = "Movie.Api.Models.Response")]
    public class MovieResponse  
    {
        [DataMember]
        public string Poster { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public int Year { get; set; }
        [DataMember]
        public string imdbID { get; set; }

        public static MovieResponse FromModel(Domain.Models.Movies model)
        {
            return new MovieResponse
            {
                Poster = model.Poster,
                Title = model.Title,
                Type = model.MovieType?.Name,
                Year = model.Year,
                imdbID = model.ImdbId
            };
        }
    }
}
