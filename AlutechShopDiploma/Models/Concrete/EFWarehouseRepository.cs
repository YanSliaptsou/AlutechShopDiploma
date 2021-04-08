using AlutechShopDiploma.Models.Abstract;
using AlutechShopDiploma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlutechShopDiploma.Models.Concrete
{
    public class EFWarehouseRepository : IWarehouseRepository
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IEnumerable<Warehouse> Warehouses
        {
            get { return context.Warehouses; }
        }

        public void CreateWarehouse(Warehouse warehouse)
        {
            context.Warehouses.Add(
                new Warehouse
                {
                    Good = warehouse.Good,
                    GoodAmmount = warehouse.GoodAmmount
                }) ;
            context.SaveChanges();
        }

        public void DeleteWarehouse(int warehouseId)
        {
            context.Warehouses.Remove(context.Warehouses.FirstOrDefault(x => x.WarehouseID == warehouseId));
            context.SaveChanges();
        }

        public void EditWarehouse(Warehouse warehouse)
        {
            if (warehouse.WarehouseID == 0)
            {
                context.Warehouses.Add(warehouse);
            }
            else
            {
                Warehouse dbEntry = context.Warehouses.Find(warehouse.WarehouseID);
                if (dbEntry != null)
                {
                    dbEntry.Good = warehouse.Good;
                    dbEntry.GoodAmmount = warehouse.GoodAmmount;
                }
            }
            context.SaveChanges();

        }
    }
}