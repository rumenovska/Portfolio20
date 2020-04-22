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
    public class VehicleService : IVehicleService
    {
        private readonly IRepository<Vehicle> _vehicleRepository;
        private readonly IMapper _mapper;
        public VehicleService(IRepository<Vehicle> vehicleRepository, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }
        public IEnumerable<VehicleViewModel> GetAllVehicles()
        {
            return _mapper.Map<List<VehicleViewModel>>(_vehicleRepository.GetAll());
        }

        public VehicleViewModel GetVehicleById(int id)
        {
            return _mapper.Map<VehicleViewModel>(_vehicleRepository.GetById(id));
        }
        public int CreateVehicle(VehicleViewModel vehicle)
        {
            Vehicle mappedVehicle = _mapper.Map<Vehicle>(vehicle);
            return _vehicleRepository.Insert(mappedVehicle);
        }

        public int UpdateVehicle(VehicleViewModel vehicle)
        {
            Vehicle mappedVehicle = _mapper.Map<Vehicle>(vehicle);
            return _vehicleRepository.Update(mappedVehicle);
        }
        public int RemoveVehicle(int id)
        {
            Vehicle vehicle = _mapper.Map<Vehicle>(GetVehicleById(id));
            return _vehicleRepository.Delete(vehicle.Id);
        }

       
    }
}
