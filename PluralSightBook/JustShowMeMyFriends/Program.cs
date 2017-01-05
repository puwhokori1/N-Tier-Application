using System;
using System.Configuration;
using System.Linq;
using StructureMap;

namespace JustShowMeMyFriends
{
    class Program
    {
        static void Main(string[] args)
        {
            StructureMapBootStrap.Configure();

            string userEmail = ConfigurationManager.AppSettings["userEmailAddress"];

            var friendsReport = ObjectFactory.GetInstance<FriendsReport>();

            Console.Write(friendsReport.ShowFriendsReport(userEmail));
            Console.WriteLine();
            Console.WriteLine("Press any key to close...");
            Console.ReadLine();
        }
    }
}