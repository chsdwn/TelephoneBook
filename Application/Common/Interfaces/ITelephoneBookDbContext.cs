using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface ITelephoneBookDbContext
    {
        DbSet<Person> Persons { get; set; }
        DbSet<PhoneNumber> PhoneNumbers { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        int SaveChanges();
    }
}