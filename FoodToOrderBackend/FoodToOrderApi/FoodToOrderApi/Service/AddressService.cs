using FoodToOrderApi.Repository;
using FoodToOrderDB;

namespace FoodToOrderApi.Service
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository repo;

        public AddressService(IAddressRepository repo)
        {
            this.repo = repo;
        }
        public void AddAddress(Address address)
        {
            repo.InsertAddress(address);
        }

        public void DeleteAddress(int id)
        {
            repo.DeleteAddress(id);
        }

        public Address GetAddressByID(int id)
        {
            var address = repo.GetAddressByID(id);
            return address;
        }

        public List<Address> GetAddresses()
        {
            return repo.GetAddresses().ToList();
        }

        public void Save()
        {
            repo.Save();
        }

        public void UpdateAddress(Address address)
        {
            repo.UpdateAddress(address);
        }
    }
}
