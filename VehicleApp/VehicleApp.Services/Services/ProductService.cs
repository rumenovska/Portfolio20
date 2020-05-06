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
    public class ExpenceTypeService : IExpenceTypeService
    {
        private readonly IRepository<ExpenceType> _expenceTypeRepository;
        private readonly IMapper _mapper;
        public ExpenceTypeService(IRepository<ExpenceType> expenceTypeRepository, IMapper mapper)
        {
            _expenceTypeRepository = expenceTypeRepository;
            _mapper = mapper;
        }

        public IEnumerable<ExpenceTypeViewModel> GetAllExpenceTypes()
        {
            return _mapper.Map<List<ExpenceTypeViewModel>>(_expenceTypeRepository.GetAll());
        }

        public ExpenceTypeViewModel GetExpenceTypeById(int id)
        {
            return _mapper.Map<ExpenceTypeViewModel>(_expenceTypeRepository.GetById(id));
        }
        public int CreateExpenceType(ExpenceTypeViewModel expenceType)
        {
            ExpenceType mappedExpenceType = _mapper.Map<ExpenceType>(expenceType);
            return _expenceTypeRepository.Insert(mappedExpenceType);
        }
        public int UpdateExpenceType(ExpenceTypeViewModel expenceType)
        {
            ExpenceType mappedExpenceType = _mapper.Map<ExpenceType>(expenceType);
            return _expenceTypeRepository.Update(mappedExpenceType);
        }
        public int RemoveExpenceType(int id)
        {
            throw new NotImplementedException();
        }
    }
}
