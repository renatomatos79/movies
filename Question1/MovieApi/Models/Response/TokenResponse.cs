using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Movie.Api.Models.Response
{
    [Serializable]
    [DataContract(Name = "TokenResponse", Namespace = "Movie.Api.Models.Response")]
    public class TokenResponse : BaseResponse
    {
        [DataMember]
        public string Token { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string DtExpiration { get; set; }

        public static TokenResponse FromModel(Domain.Models.Tokens token, Domain.Models.Users user)
        {
            return new TokenResponse
            {
                Token = token.Token,
                UserName = user.Name,
                DtExpiration = token.DtExpiration.ToString("yyyy-MM-dd hh:mm:ss tt", new CultureInfo("en-US", false).DateTimeFormat),
                Message = string.Empty,
                Success = true
            };
        }
    }
}
