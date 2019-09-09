using POC.Business.Interface;
using POC.BusinessEntities;
using System.Linq;

namespace POC.Business.Service
{
    public class AddressService : IAddressService
    {
        private readonly IActionFactory _actionFactory;
        private readonly IRepositoryFactory _repositoryFactory;

        public AddressService(IActionFactory actionFactory, IRepositoryFactory repositoryFactory)
        {
            _actionFactory = actionFactory;
            _repositoryFactory = repositoryFactory;
        }

        public Address Create(Address address)
        {
            return _repositoryFactory.GetRepository<Address>().Create(address);
        }

        public Address GetAdreessById(int id)
        {
            return _repositoryFactory.GetRepository<Address>().GetAllData().FirstOrDefault(x => x.Id == id);
        }
    }
}
