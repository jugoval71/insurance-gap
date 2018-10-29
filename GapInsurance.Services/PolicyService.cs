using GapInsurance.Repositories;
using GapInsurance.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GapInsurance.Services
{
    public class PolicyService : IPolicyService
    {
        IUnitOfWork _unitOfWork;
        public PolicyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Models.Policy> CreateUpdateAsync(Models.Policy policy)
        {
            try
            {
                var uow = _unitOfWork.GetRepositoryAsync<Entities.Policy>();
                var existingPolicy = await uow.SingleAsync((p) => p.Id == policy.Id).ConfigureAwait(false);
                var entity = MapPolicy(policy, existingPolicy);

                if (existingPolicy != null)
                {
                    uow.UpdateAsync(entity);
                    return policy;
                };
                await uow.AddAsync(entity).ConfigureAwait(false);
                policy.Id = entity.Id;
                return policy;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Models.Policy> Delete(Guid id)
        {
            try
            {
                var uow = _unitOfWork.GetRepository<Entities.Policy>();
                var uowAsync = _unitOfWork.GetRepositoryAsync<Entities.Policy>();
                var existingPolicy = await uowAsync.SingleAsync((p) => p.Id == id).ConfigureAwait(false);
                var model = MapPolicy(existingPolicy);
                uow.Delete(id);
                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Models.Policy> Get(Guid id)
        {
            try
            {
                var uowAsync = _unitOfWork.GetRepositoryAsync<Entities.Policy>();
                var existingPolicy = await uowAsync.SingleAsync((p) => p.Id == id).ConfigureAwait(false);
                var model = MapPolicy(existingPolicy);
                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Models.Policy>> GetAll()
        {
            try
            {
                var uowAsync = _unitOfWork.GetRepositoryAsync<Entities.Policy>();
                var existingPolicies = await uowAsync.GetListAsync().ConfigureAwait(false);
                var policies = existingPolicies.Items.ToList().ConvertAll(p => MapPolicy(p));
                return policies;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Models.Policy>> GetByUser(string userName)
        {
            try
            {
                var uowAsync = _unitOfWork.GetRepositoryAsync<Entities.Policy>();
                var existingPolicies = await uowAsync.GetListAsync(p => p.User == userName).ConfigureAwait(false);
                var policies = existingPolicies.Items.ToList().ConvertAll(p => MapPolicy(p));
                return policies;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Entities.Policy MapPolicy(Models.Policy policy, Entities.Policy existingPolicy = null)
        {
            var entity = Entities.Policy.Create(policy.Name, policy.Description, policy.StartDate, policy.DurationMonths, policy.Price, (Entities.RiskType)policy.Risk, policy.User);
            entity.Id = existingPolicy == null ? Guid.NewGuid() : existingPolicy.Id;
            return entity;
        }

        private Models.Policy MapPolicy(Entities.Policy existingPolicy)
        {
            if (existingPolicy == null)
            {
                return new Models.Policy();
            }

            var model = new Models.Policy()
            {
                Id = existingPolicy.Id,
                Name = existingPolicy.Name,
                Description = existingPolicy.Description,
                StartDate = existingPolicy.StartDate,
                DurationMonths = existingPolicy.DurationMonths,
                Price = existingPolicy.Price,
                Risk = (RiskType)existingPolicy.Risk,
                User = existingPolicy.User
            };

            return model;
        }
    }
}
