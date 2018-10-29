using GapInsurance.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GapInsurance.Services.Interfaces
{
    public interface IPolicyService
    {
        Task<Policy> Get(Guid id);
        Task<IEnumerable<Policy>> GetByUser(string userName);
        Task<IEnumerable<Policy>> GetAll();
        Task<Policy> CreateUpdateAsync(Policy policy);
        Task<Policy> Delete(Guid id);
    }
}
