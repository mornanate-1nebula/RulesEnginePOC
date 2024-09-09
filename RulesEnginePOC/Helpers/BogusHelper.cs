using Bogus;
using RulesEnginePOC.Core.Models;
using Address = RulesEnginePOC.Core.Models.Address;

namespace RulesEnginePOC.Helpers;

public static class BogusHelper
{
    public static void GenerateNewUsersData(string[] filePaths, int dataCount)
    {
        var orderIds = 0;
        var testAddresses = new Faker<Address>()
            .StrictMode(true)
            .RuleFor(o => o.ID, f => orderIds++)
            .RuleFor(_ => _.Street, f => f.Address.StreetAddress())
            .RuleFor(_ => _.City, f => f.Address.City())
            .RuleFor(_ => _.State, f => f.Address.State())
            .RuleFor(_ => _.PostalCode, f => f.Address.ZipCode())
            .RuleFor(_ => _.Country, f => f.Address.Country());
        
        var userIds = 0;
        var testUsers = new Faker<User>()
            .CustomInstantiator(f => new User())
            .StrictMode(true)
            .RuleFor(o => o.ID, f => userIds++)
            .RuleFor(_ => _.FirstName, f => f.Name.FirstName())
            .RuleFor(_ => _.LastName, f => f.Name.LastName())
            .RuleFor(_ => _.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
            .RuleFor(_ => _.PhoneNumber, f => f.Phone.PhoneNumber())
            .RuleFor(u => u.Addresses, f => testAddresses.Generate(3).ToList());

        var users = testUsers.Generate(dataCount);
        if (users == null)
        {
            throw new Exception("Failed to generate bugos users data");
        }
        
        FileHelper.WriteFile(filePaths, users);
    }
}