using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleApp.DataAccess.Interfaces;
using VehicleApp.Domain.Models;
using VehicleApp.Services.Interfaces;
using VehicleApp.WebModels;

namespace VehicleApp.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public IEnumerable<ProductViewModel> GetAllProducts()
        {
            return _mapper.Map<List<ProductViewModel>>(_productRepository.GetAll());
        }

        public ProductViewModel GetProductById(int id)
        {
            return _mapper.Map<ProductViewModel>(_productRepository.GetById(id));
        }
        public int CreateProduct(ProductViewModel product)
        {
            Product mappedProduct = _mapper.Map<Product>(product);
            return _productRepository.Insert(mappedProduct);
        }
        public int UpdateProduct(ProductViewModel product)
        {
            Product mappedProduct = _mapper.Map<Product>(product);
            return _productRepository.Update(mappedProduct);
        }
        public int RemoveProduct(int id)
        {
            throw new NotImplementedException();
        }
    }
}
