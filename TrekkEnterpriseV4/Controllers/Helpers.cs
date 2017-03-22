using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrekkEnterpriseV4.Models;

namespace TrekkEnterpriseV4.Controllers
{
    public class Helpers
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public string GenerateEntryCode()
        {
            Random random = new Random();
            const string legalChars = "ABCDEFGHIJKMNPQRSTUVWXYZabcdefghijkmnpqrstuvwxyz23456789";
            var accessCode = string.Empty;
            var count = 1;

            do
            {
                var tmp = (Enumerable.Repeat(legalChars, 20).Select(s => s[random.Next(s.Length)]).ToArray());
                accessCode = string.Join("", tmp); ;
                count = db.Users.Count(theID => theID.AccessCode == accessCode);
            } while (count > 0);

            return accessCode;
        }
    }
}