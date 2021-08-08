using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Warehouse.Business.Enums;
using Warehouse.Business.Models;
using Warehouse.Data.Entities;
using Warehouse.Data.Repositories;

namespace Warehouse.Business.Services
{
    public class ElectricMeterService : IElectricMeterService
    {
        private readonly IMapper _mapper;
        private readonly IElectricMeterRepository _electricMeterRepo;

        public ElectricMeterService(IMapper mapper, IElectricMeterRepository electricMeterRepo)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _electricMeterRepo = electricMeterRepo ?? throw new ArgumentNullException(nameof(electricMeterRepo));
        }

        public async Task<bool> ExistDeviceAsync(Device device)
        {
            var result = await _electricMeterRepo.GetByIdAsync(device.Type.ToString(), device.SerialNumber) != null;
            return result;
        }

        public async Task<ElectricMeterModel> AddDeviceAsync(Device device)
        {
            var electricEntity = _mapper.Map<ElectricMeterEntity>(device);
            var result = await _electricMeterRepo.AddAsync(electricEntity);

            return _mapper.Map<ElectricMeterModel>(result);
        }

        public IEnumerable<ElectricMeterModel> GetAll()
        {
            var result = _electricMeterRepo.GetListAsync(DeviceTypes.ElectricMeter.ToString());
            return _mapper.Map<IEnumerable<ElectricMeterModel>>(result);
        }
    }
}
