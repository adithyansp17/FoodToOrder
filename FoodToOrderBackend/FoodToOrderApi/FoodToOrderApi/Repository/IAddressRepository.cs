using FoodToOrderDB;

namespace FoodToOrderApi.Repository
{
    public interface IAddressRepository : IDisposable
    {
        IEnumerable<Address> GetAddresses();
        Address GetAddressByID(int id);
        void InsertAddress(Address address);
        void UpdateAddress(Address address);
        void DeleteAddress(int id);
        void Save();
    }
}
