using AutoMapper;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using VehicleApp.DataAccess.Interfaces;
using VehicleApp.Domain.Models;
using VehicleApp.Services.Interfaces;
using VehicleApp.WebModels;

namespace VehicleApp.Services.Services
{
    public class ExpenceService: IExpenceService
    {
        private readonly IRepository<Expense> _expenceRepository;
        private readonly IMapper _mapper;
        public ExpenceService(IRepository<Expense> expenceRepository, IMapper mapper)
        {
            _expenceRepository = expenceRepository;
            _mapper = mapper;
        }

        public VehicleExpencesViewModel GetAllExpencesForVehicle(int vehicleId)
        {
            var expences = _expenceRepository.GetAll().Where(e => e.VehicleId == vehicleId).ToList();
            var result = new VehicleExpencesViewModel
            {
                VehicleId = vehicleId,
                Expences = _mapper.Map<List<ExpenceViewModel>>(expences)
            };
            return result;
        }

        //public ExpenseViewModel GetExpenceById(int id)
        //{
        //    return _mapper.Map<ExpenseViewModel>(_expenceRepository.GetById(id));
        //}
        //public int CreateExpence(ExpenseViewModel expence)
        //{
        //    Expense expensesModel = _mapper.Map<Expense>(expence);
        //    return _expenceRepository.Insert(expensesModel);
        //}
        //public int UpdateExpence(ExpenseViewModel expence)
        //{
        //    Expense expensesModel = _mapper.Map<Expense>(expence);
        //    return _expenceRepository.Update(expensesModel);
        //}
        //public int RemoveExpence(int id)
        //{
        //    Expense expence = _mapper.Map<Expense>(GetExpenceById(id));
        //    return _expenceRepository.Delete(expence.Id);
        //}

        //public IEnumerable<ExpenceViewModel> GetAllExpences()
        //{
        //    throw new NotImplementedException();
        //}

        //ExpenceViewModel IExpenceService.GetExpenceById(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public int CreateExpence(ExpenceViewModel expence)
        //{
        //    throw new NotImplementedException();
        //}

        //public int UpdateExpence(ExpenceViewModel expence)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
