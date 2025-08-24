using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities; 


namespace DataAccessLayer
{
    public static class DataGenerator
    {
        public static readonly List<User> Users = new();

        public const int NumberOfUsers = 10;
        private static Faker<User> GetUserGenerator()
        {
            return new Faker<User>()
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.Phone, f => f.Phone.PhoneNumber())
                .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
                .RuleFor(u => u.HashedPassword, f => f.Internet.Password(10));
        }

        public static List<User> GetBogusUserData()
        {
            var generator = GetUserGenerator();
            var generatedUsers = generator.Generate(NumberOfUsers);
            Users.AddRange(generatedUsers);
            return generatedUsers;
        }

    }
}
