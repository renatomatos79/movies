using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Movie.Api.Models.Response
{
    [Serializable]
    [DataContract(Name = "BaseResponse{0}", Namespace = "Movie.Api.Models.Response")]
    public class BaseResponse
    {
        public BaseResponse()
        {
            this.Success = false;
            this.Message = string.Empty;
        }

        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public bool Success { get; set; }
    }

    [Serializable]
    [DataContract(Name = "BaseListResponse{0}", Namespace = "Movie.Api.Models.Response")]
    public class BaseListResponse<T> : BaseResponse where T : class
    {
        public BaseListResponse()
        {
            
        }

        [DataMember]
        public int Page { get; set; }
        [DataMember]
        public int PerPage { get; set; }
        [DataMember]
        public int Total { get; set; }
        [DataMember]
        public int TotalPages { get; set; }
        [DataMember]
        public List<T> Data { get; set; }
    }


}
