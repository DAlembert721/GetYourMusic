using System.Threading.Tasks;

namespace GetYourMusic.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
