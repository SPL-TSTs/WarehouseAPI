using AutoMapper;
using Warehouse.Business.Models;
using Warehouse.Data.Entities;

namespace Warehouse.Business.Mapper
{
    public class DeviceMapper : Profile
    {
        public DeviceMapper()
        {
            CreateMap<Device, ElectricMeterEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.RowKey, opt => opt.MapFrom(src => src.SerialNumber))
                .ForMember(dest => dest.PartitionKey, opt => opt.MapFrom(src => src.Type.ToString()));
            
            CreateMap<Device, WaterMeterEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.RowKey, opt => opt.MapFrom(src => src.SerialNumber))
                .ForMember(dest => dest.PartitionKey, opt => opt.MapFrom(src => src.Type.ToString()));
            
            CreateMap<Device, GatewayEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.RowKey, opt => opt.MapFrom(src => src.SerialNumber))
                .ForMember(dest => dest.PartitionKey, opt => opt.MapFrom(src => src.Type.ToString()));
            
            CreateMap<ElectricMeterEntity, ElectricMeterModel>()
                .ForMember(dest => dest.SerialNumber, opt => opt.MapFrom(src => src.RowKey));
            
            CreateMap<WaterMeterEntity, WaterMeterModel>()
                .ForMember(dest => dest.SerialNumber, opt => opt.MapFrom(src => src.RowKey));
            
            CreateMap<GatewayEntity, GatewayModel>()
                .ForMember(dest => dest.SerialNumber, opt => opt.MapFrom(src => src.RowKey));

        }
    }
}
