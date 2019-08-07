using System;
using System.Collections.Generic;

namespace Movie.Domain.Models
{
    public partial class Tokens
    {
        public string Token { get; set; }
        public int UserId { get; set; }
        public bool Active { get; set; }
        public DateTime DtExpiration { get; set; }
        public DateTime DtCreated { get; set; }

        public virtual Users User { get; set; }
    }
}
