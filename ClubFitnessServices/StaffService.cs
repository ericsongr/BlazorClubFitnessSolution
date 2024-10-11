using ClubFitnessDomain;
using ClubFitnessInfrastructure.Interfaces;
using ClubFitnessServices.Interfaces;

namespace ClubFitnessServices
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _repository;

        public StaffService(IStaffRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Staff>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Staff> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Staff staff)
        {
            await _repository.AddAsync(staff);
        }

        public async Task UpdateAsync(Staff staff)
        {
            await _repository.UpdateAsync(staff);
        }

        public async Task DeleteAsync(int id, int deletedBy)
        {
            await _repository.DeleteAsync(id, deletedBy);
        }
    }
}