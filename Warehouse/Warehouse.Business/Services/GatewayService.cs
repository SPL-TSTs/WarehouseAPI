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
    public class GatewayService : IGatewayService
    {
        private readonly IMapper _mapper;
        private readonly IGatewayRepository _gatewayRepo;

        public GatewayService(IMapper mapper, IGatewayRepository gatewayRepo)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _gatewayRepo = gatewayRepo ?? throw new ArgumentNullException(nameof(gatewayRepo));
        }

        public async Task<bool> ExistDeviceAsync(GatewayModel device)
        {
            var result = await _gatewayRepo.GetByIdAsync(DeviceTypes.Gateway.ToString(), device.SerialNumber) != null;
            return result;
        }

        public async Task<GatewayModel> AddDeviceAsync(GatewayModel device)
        {
            var electricEntity = _mapper.Map<GatewayEntity>(device);
            var result = await _gatewayRepo.AddAsync(electricEntity);

            return _mapper.Map<GatewayModel>(result);
        }

        public IEnumerable<GatewayModel> GetAll()
        {
            var result = _gatewayRepo.GetListAsync(DeviceTypes.Gateway.ToString());
            return _mapper.Map<IEnumerable<GatewayModel>>(result);
        }
    }
}
