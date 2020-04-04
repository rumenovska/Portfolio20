using System;
using System.Collections.Generic;
using System.Text;
using VehicleApp.WebModels;

namespace VehicleApp.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductViewModel> GetAllProducts();
        ProductViewModel GetProductById(int id);
        int CreateProduct(ProductViewModel product);
        int UpdateProduct(ProductViewModel product);
        int RemoveProduct(int id);
    }
}
