using System.Data.Entity;
using AlutechShopDiploma.Models;
using System.Security.Claims;
using System.Threading.Tasks;
using AlutechShopDiploma.Models.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using AlutechShopDiploma.Models.Entities.Goods;
using AlutechShopDiploma.Models.Entities.Goods.Category_1;
using AlutechShopDiploma.Models.Entities.Goods.Category_2;
using AlutechShopDiploma.Models.Entities.Goods.Category_3;

namespace AlutechShopDiploma.Models
{
    // В профиль пользователя можно добавить дополнительные данные, если указать больше свойств для класса ApplicationUser. Подробности см. на странице https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public int Age { get; set; } // добавляем свойство Age
        public double bonusAmmount { get; set; } //бонусный счёт
        public bool isBanned { get; set; } // добавление свойства заблокирован
        public int purchasesAmmount { get; set; } //кол-во покупок
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя
            userIdentity.AddClaim(new Claim("age", this.Age.ToString()));
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Good> Goods { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<UserMessage> UserMessages { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ImageContainer> ImageContainers { get; set; }
        public DbSet<GoodsTable> GoodsTables { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<ShippingDetail> ShippingDetails { get; set; }

        //-----------------------------ALUTECH GOODS-----------------------------//
        //-----------------------------CATEGORY 1--------------------------------//
        public DbSet<AdditionalComplectation> AdditionalComplectations { get; set; }
        public DbSet<AlutechBarrier> AlutechBarriers { get; set; }
        public DbSet<ComunelloAccessory> ComunelloAccessories { get; set; }
        public DbSet<ComunelloDriveUnit> ComunelloDriveUnits { get; set; }
        public DbSet<GarageGateOperatorAnMotors> GarageGateOperatorAnMotors { get; set; }
        public DbSet<RecoilingGateOperatorAnMotors> RecoilingGateOperatorAnMotors { get; set; }

        //-----------------------------CATEGORY 2--------------------------------//
        public DbSet<BusProfile> BusProfiles { get; set; }
        public DbSet<RollerAndSteelComplect> RollerAndSteelComplects { get; set; }

        //-----------------------------CATEGORY 3--------------------------------//
        public DbSet<Bracket> Brackets { get; set; }
        public DbSet<Clutch> Clutches { get; set; }
        public DbSet<DeadboltAndLockingDevice> DeadboltAndLockingDevices { get; set; }
        public DbSet<InsertAndSeal> InsertAndSeals { get; set; }
        public DbSet<Loop> Loops { get; set; }
        public DbSet<RollerAndRing> RollerAndRings { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}