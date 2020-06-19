using System;
using Xamabrouk.MySQLJsonBased.Attributes;
using Xamabrouk.MySQLJsonBased.Driver;
using Xamabrouk.MySQLJsonBased.Entity;
using Xamabrouk.MySQLJsonBased.Interface;
using Xamabrouk.MySQLJsonBased.Queries;

namespace MySQLJsonBasedSimple
{
    class Program
    {
        static void Main(string[] args)
        {
            MySQLDriver driver = new MySQLDriver($"Server=YOUR_SERVER;Port=YOUR_PORT;Database=YOUR_DB;User=YOUR_USER;Pwd=USER_PASSWORD;");

            var result = driver.Save(new UserRole() { Name = "Administrator" });
            //var result = await driver.SaveAsync<UserRole>(new UserRole());
            var cb = new CriteriaBuilder().Equal<UserRole, string>(ur => ur.Name, "Administrator");
            var collection = driver.Search<UserRole>(cb);
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            } 
        }

        [JsonTable(name:"YourTableName",jsonFieldName:"JsonDocument")]
        public class UserRole : IJsonTable
        {
            public ObjectId Id { get; set; }
            public string Name { get; set; }

            public override string ToString() => $"{Id} => {Name}";
        }
    }
}
