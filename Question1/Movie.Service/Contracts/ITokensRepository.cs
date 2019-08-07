using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Service.Contracts
{
    public interface ITokensRepository : IBaseRepository<Domain.Models.Tokens, string>
    {
        
    }
}