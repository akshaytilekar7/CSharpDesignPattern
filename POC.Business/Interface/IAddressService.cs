using POC.BusinessEntities;

namespace POC.Business.Interface
{
    public interface IAddressService
    {
        Address GetAdreessById(int id);

        Address Create(Address address);
    }
}
