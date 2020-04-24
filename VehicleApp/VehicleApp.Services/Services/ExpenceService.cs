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
    public class ExpenceService : IExpenceService
    {
        private readonly IRepository<Expenses> _expenceRepository;
        private readonly IMapper _mapper;
        public ExpenceService(IRepository<Expenses> expenceRepository, IMapper mapper)
        {
            _expenceRepository = expenceRepository;
            _mapper = mapper;
        }

        public IEnumerable<ExpenseViewModel> GetAllExpences()
        {
            return _mapper.Map<List<ExpenseViewModel>>(_expenceRepository.GetAll());
        }

        public ExpenseViewModel GetExpenceById(int id)
        {
            return _mapper.Map<ExpenseViewModel>(_expenceRepository.GetById(id));
        }
        public int CreateExpence(ExpenseViewModel expence)
        {
            Expenses expensesModel = _mapper.Map<Expenses>(expence);
            return _expenceRepository.Insert(expensesModel);
        }
        public int UpdateExpence(ExpenseViewModel expence)
        {
            Expenses expensesModel = _mapper.Map<Expenses>(expence);
            return _expenceRepository.Update(expensesModel);
        }
        public int RemoveExpence(int id)
        {
            Expenses expence = _mapper.Map<Expenses>(GetExpenceById(id));
            return _expenceRepository.Delete(expence.Id);
        }

        public int TotalCost(ExpenseViewModel expenseViewModel)
        {
            return expenseViewModel.Products.Select(p => p.Price).Sum();

        }
        
    }
}
