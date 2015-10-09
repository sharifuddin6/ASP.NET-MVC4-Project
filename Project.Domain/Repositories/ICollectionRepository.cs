using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Domain.Repositories
{
    public interface ICollectionRepository
    {
        IEnumerable<int> GetAllItemsId();

        IEnumerable<string> GetAllItemsName();

        void AddItem(string name, string code);
    }
}
