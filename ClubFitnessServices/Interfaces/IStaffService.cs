using ClubFitnessDomain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubFitnessServices.Interfaces
{
    public interface IStaffService
    {
        // Method to get all staff records
        Task<IEnumerable<Staff>> GetAllAsync();

        // Method to get a staff record by ID
        Task<Staff> GetByIdAsync(int staffId);

        // Method to add a new staff record
        Task AddAsync(Staff staff);

        // Method to update an existing staff record
        Task UpdateAsync(Staff staff);

        // Method to delete a staff record by ID
        Task DeleteAsync(int staffId, int deletedBy);

        // Method to retrieve staff records with related account details
    }
}