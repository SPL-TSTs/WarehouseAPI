using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Business.Enums;
using Warehouse.Business.Models;
using Warehouse.Data.Entities;
using Warehouse.Data.Repositories;

namespace Warehouse.Business.Services
{
    public class WaterMeterService : IWaterMeterService
    {
        private readonly IMapper _mapper;
        private readonly IWaterMeterRepository _waterMeterRepo;

        public WaterMeterService(IMapper mapper, IWaterMeterRepository waterMeterRepo)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _waterMeterRepo = waterMeterRepo ?? throw new ArgumentNullException(nameof(waterMeterRepo));
        }

        public async Task<bool> ExistDeviceAsync(WaterMeterModel device)
        {
            var result = await _waterMeterRepo.GetByIdAsync(DeviceTypes.WaterMeter.ToString(), device.SerialNumber) != null;
            return result;
        }

        public async Task<WaterMeterModel> AddDeviceAsync(WaterMeterModel device)
        {
            var electricEntity = _mapper.Map<WaterMeterEntity>(device);
            var result = await _waterMeterRepo.AddAsync(electricEntity);

            return _mapper.Map<WaterMeterModel>(result);
        }

        public IEnumerable<WaterMeterModel> GetAll()
        {
            var result = _waterMeterRepo.GetListAsync(DeviceTypes.WaterMeter.ToString());
            return _mapper.Map<IEnumerable<WaterMeterModel>>(result);
        }
    }
}
