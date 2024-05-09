using FoodToOrderDB;
using Microsoft.DotNet.Scaffolding.Shared.ProjectModel;
using Microsoft.EntityFrameworkCore;

namespace FoodToOrderApi.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private FoodToOrderWpfAdithyanContext context;
        public AddressRepository(FoodToOrderWpfAdithyanContext injectedContext)
        {
            context = injectedContext;
        }
        public void DeleteAddress(int id)
        {
            var r = context.Addresses.AsNoTracking().Where(x => x.id == id).FirstOrDefault();
            context.Addresses.Remove(r);
        }

        public void Dispose()
        {
            Console.WriteLine("Disposed");
        }

        public Address GetAddressByID(int id)
        {
            return context.Addresses.AsNoTracking().Where(a => a.id == id).FirstOrDefault();
        }

        public IEnumerable<Address> GetAddresses()
        {
            return context.Addresses.ToList();
        }

        public void InsertAddress(Address address)
        {
            context.Addresses.Add(address);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateAddress(Address address)
        {
            context.Addresses.Update(address);
            //context.Users.UpdateRange(address.users);
        }
    }
}
