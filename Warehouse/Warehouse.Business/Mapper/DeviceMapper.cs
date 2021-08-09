using AutoMapper;
using Warehouse.Business.Models;
using Warehouse.Data.Entities;

namespace Warehouse.Business.Mapper
{
    public class DeviceMapper : Profile
    {
        public DeviceMapper()
        {
            CreateMap<ElectricMeterModel, ElectricMeterEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.RowKey, opt => opt.MapFrom(src => src.SerialNumber))
                .ForMember(dest => dest.PartitionKey, opt => opt.Ignore());
            
            CreateMap<WaterMeterModel, WaterMeterEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.RowKey, opt => opt.MapFrom(src => src.SerialNumber))
                .ForMember(dest => dest.PartitionKey, opt => opt.Ignore());
            
            CreateMap<GatewayModel, GatewayEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.RowKey, opt => opt.MapFrom(src => src.SerialNumber))
                .ForMember(dest => dest.PartitionKey, opt => opt.Ignore());
            
            CreateMap<ElectricMeterEntity, ElectricMeterModel>()
                .ForMember(dest => dest.SerialNumber, opt => opt.MapFrom(src => src.RowKey));
            
            CreateMap<WaterMeterEntity, WaterMeterModel>()
                .ForMember(dest => dest.SerialNumber, opt => opt.MapFrom(src => src.RowKey));
            
            CreateMap<GatewayEntity, GatewayModel>()
                .ForMember(dest => dest.SerialNumber, opt => opt.MapFrom(src => src.RowKey));

        }
    }
}
