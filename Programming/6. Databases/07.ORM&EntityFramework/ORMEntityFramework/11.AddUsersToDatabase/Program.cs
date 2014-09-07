// 11.Create a database holding users and groups. Create a transactional EF based method that creates an user and puts it in a group "Admins".
// In case the group "Admins" do not exist, create the group in the same transaction. If some of the operations fail (e.g. the username already
// exist), cancel the entire transaction.

namespace _11.AddUsersToDatabase
{
    using System;
    using System.Linq;

    internal class Program
    {
        internal static void Main()
        {
            RegisterUser("Gosho", "67890");
        }

        private static void RegisterUser(string name, string password)
        {
            var db = new UsersTestEntities();
            using (db)
            {
                var tr = db.Database.BeginTransaction();
                try
                {
                    if (db.Users.Any(u => u.Name == name))
                    {
                        throw new ApplicationException("Duplicated username!");
                    }

                    int id = 0;
                    if (db.Groups.All(g => g.Name != "Admin"))
                    {
                        var newGroup = new Group() { Name = "Admin" };
                        db.Groups.Add(newGroup);
                        db.SaveChanges();
                        id = newGroup.Id;
                    }
                    else
                    {
                        id = db.Groups.First(g => g.Name == "Admin").Id;
                    }

                    db.Users.Add(new User() { Name = name, Password = password, GroupId = id });
                    db.SaveChanges();
                    Console.WriteLine("Changes saved successfully!");
                    tr.Commit();
                }
                catch (Exception e)
                {
                    tr.Rollback();
                    Console.WriteLine("Changes not saved!");
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
