using AlutechShopDiploma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlutechShopDiploma.Models.Abstract
{
    public interface IWarehouseRepository
    {
        IEnumerable<Warehouse> Warehouses { get; }
        void EditWarehouse(Warehouse warehouse);
        void CreateWarehouse(Warehouse warehouse);
        void DeleteWarehouse(int warehouseId);
    }
}
