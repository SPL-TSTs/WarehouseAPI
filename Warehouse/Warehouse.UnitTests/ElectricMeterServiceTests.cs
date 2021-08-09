using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using NUnit.Framework;
using Warehouse.Business.Enums;
using Warehouse.Business.Mapper;
using Warehouse.Business.Models;
using Warehouse.Business.Services;
using Warehouse.Data.Entities;
using Warehouse.Data.Repositories;

namespace Warehouse.UnitTests
{
    public class ElectricMeterServiceTests
    {
        private Mock<IElectricMeterRepository> _electricMeterRepo;
        private IElectricMeterService _electricMeterService;
        private IMapper _mapper;
        private Device _nonExistingDevice;
        private Device _existingDevice;
        private readonly List<ElectricMeterEntity> listResult = new List<ElectricMeterEntity>();

        [SetUp]
        public void Setup()
        {
            listResult.Add(new ElectricMeterEntity());

            var mockMapper = new MapperConfiguration(cfg => { cfg.AddProfile(new DeviceMapper()); });
            _mapper = mockMapper.CreateMapper();

            _electricMeterRepo = new Mock<IElectricMeterRepository>();
            _electricMeterRepo.Setup(repo =>
                    repo.GetByIdAsync(It.Is<string>(p => p == "ElectricMeter"), It.Is<string>(p => p == "00001")))
                .Returns(Task.FromResult(new ElectricMeterEntity {RowKey = "test"}));
            _electricMeterRepo.Setup(repo => repo.AddAsync(It.IsNotNull<ElectricMeterEntity>()))
                .Returns(Task.FromResult(new ElectricMeterEntity {RowKey = "test"}));
            _electricMeterRepo.Setup(repo => repo.GetListAsync(It.Is<string>(p => p == "ElectricMeter")))
                .Returns(listResult);


            _electricMeterService = new ElectricMeterService(_mapper, _electricMeterRepo.Object);

            _nonExistingDevice = new Device
            {
                Type = DeviceTypes.ElectricMeter,
                FirmwareVersion = "1",
                SerialNumber = Guid.NewGuid().ToString(),
                State = "ok"
            };

            _existingDevice = new Device
            {
                Type = DeviceTypes.ElectricMeter,
                FirmwareVersion = "1",
                SerialNumber = "00001",
                State = "ok"
            };
        }

        [Test]
        public async Task When_EntityExist_ReturnTrue()
        {
            //Action
            var resultKO = await _electricMeterService.ExistDeviceAsync(_nonExistingDevice);
            var resultOK = await _electricMeterService.ExistDeviceAsync(_existingDevice);

            //Assert
            Assert.IsTrue(resultOK);
            Assert.IsFalse(resultKO);
        }

        [Test]
        public async Task When_AddingEntity_ReturnEntity()
        {
            //Action
            var result = await _electricMeterService.AddDeviceAsync(_existingDevice);

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task When_GetAll_ReturnsList()
        {
            //Action
            var result = _electricMeterService.GetAll();
            
            //Assert
            Assert.IsTrue(result.Count() > 0);
        }


        [Test]
        public async Task When_ArgumentsAreNull_ThrowException()
        {
            //Actions
            var argumentNull = Assert.Throws<ArgumentNullException>(() => new ElectricMeterService(null, _electricMeterRepo.Object));
            var argumentNull2 = Assert.Throws<ArgumentNullException>(() => new ElectricMeterService(_mapper, null));

            //Asserts
            Assert.AreEqual("mapper", argumentNull.ParamName);
            Assert.AreEqual("electricMeterRepo", argumentNull2.ParamName);
        }
    }
}
