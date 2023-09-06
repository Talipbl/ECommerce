using ECommerce.Brand;
using ECommerce.Category;
using ECommerce.Manufacturer;
using ECommerce.Product;
using ECommerce.Systems;

namespace ECommerce.AdminUI.Models
{
    public class ProductModifyModel
    {
        public ProductMasterModelDto Product { get; set; }
        public List<DefBrand> Brands { get; set; }
        public List<DefManufacturer> Manufacturers { get; set; }
        public List<DefCategory> Categories { get; set; }
        public List<SysStatusType> Status { get; set; }
        public List<SysCurrency> Currencies { get; set; }
        public List<SysVatRatio> VatRatios { get; set; }
        public List<SysUnitType> UnitTypes { get; set; }
    }
}
