using FoodToOrderDB;

namespace FoodToOrderApi.Service
{
    public interface IAddressService
    {
        List<Address> GetAddresses();
        Address GetAddressByID(int id);
        void AddAddress(Address address);
        void DeleteAddress(int id);
        void UpdateAddress(Address address);
        void Save();
    }
}
