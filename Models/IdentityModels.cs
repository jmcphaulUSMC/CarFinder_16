using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CarFinder_16.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //CARS Database 
        public DbSet<Cars> Car { get; set; }


        public async Task<List<string>> GetYears()
        {
            return await Database.SqlQuery<string>("GetAllYears").ToListAsync();
        }

        public async Task<List<string>> GetMakes(string _year)
        {
            return await Database.SqlQuery<string>("GetAllMakes @year", new SqlParameter("year", _year)).ToListAsync();
        }

        public async Task<List<string>> GetModels(string _year, string _make)
        {
            return await Database.SqlQuery<string>("GetAllCarModels @year, @make", 
                new SqlParameter("year", _year),
                new SqlParameter("make", _make))
                .ToListAsync();
        }

        public async Task<List<string>> GetTrim(string _year, string _make, string _model_name)
        {
            return await Database.SqlQuery<string>("GetAllTrim @year, @make, @model_name",
                new SqlParameter("year", _year),
                new SqlParameter("make", _make),
                new SqlParameter("model_name", _model_name))
                .ToListAsync();
        }

        public async Task<List<Cars>> GetCar(string _year, string _make, string _model_name, string _model_trim)
        {
            return await Database.SqlQuery<Cars>("GetCar @year, @make, @model_name, @model_trim",
                new SqlParameter("year", _year),
                new SqlParameter("make", _make),
                new SqlParameter("model_name", _model_name),
                new SqlParameter("model_trim", _model_trim))
                .ToListAsync();
        }
    }
}  