using Microsoft.Extensions.Logging;
using Moq;
using TapTest.Domain.Repositories;
using TapTest.Interfaces;
using TapTest.Models;
using TapTest.Options;
using TapTest.Services;

namespace TapTest.Tests
{
    internal class InstituteServiceTests
    {
        private InstituteService _service;
        private IDepartmentService _departmentService;
        private BaseRepository<Institute> _instituteRepository;
        private ILogger _logger;

        [SetUp]
        public void Setup()
        {
            _logger = new Mock<ILogger>().Object;
            _departmentService = new Mock<IDepartmentService>().Object;
            var mockDepartment = new Mock<IDepartment>();
            mockDepartment.Setup(c => c.Id).Returns(1);
            _departmentService.Setup(c => c.Create(It.IsAny<DepartmentOptions>())).Returns(mockDepartment.Object);
            _instituteRepository = new Mock<BaseRepository<Institute>>(_logger).Object;
            _service = new InstituteService(_departmentService, _instituteRepository, _logger);
        }

        [Test]
        public void CreateInstitute()
        {
            var institute = _service.Create(new InstituteOptions()
            {
                Departments = new[]
                {
                    new DepartmentOptions()
                    {
                        DepartmentKey = 'c',
                        SelectionOptions = new List<SelectionOptions>()
                    }
                }
            });


            Assert.IsNotNull(institute);
            _instituteRepository.MockObj().Verify(r => r.Add(It.Is<Institute>(i => i.GetDepartments().Count == 1)));
        }

        [Test]
        public void ApplyForInstitute()
        {
            var key = 'c';

            var mockDepartment = new Mock<IDepartment>();
            mockDepartment.Setup(c => c.Id).Returns(1);
            mockDepartment.Setup(c => c.Key).Returns(key);
            _departmentService.Setup(c => c.Create(It.IsAny<DepartmentOptions>())).Returns(mockDepartment.Object);
            _departmentService.Setup(c => c.Apply(It.IsAny<int>(), It.IsAny<IApplication>())).Returns(true);
            var institute = _service.Create(new InstituteOptions()
            {
                Departments = new[]
                {
                    new DepartmentOptions()
                    {
                        DepartmentKey = key,
                        SelectionOptions = new List<SelectionOptions>()
                    }
                }
            });
            Assert.IsNotNull(institute);
            _instituteRepository.Setup(r => r.Get(It.Is<int>(id => id ==1))).Returns((institute as Institute)!);
            var res = _service.Apply(1, new Application() { Subject = key});
            Assert.IsTrue(res);
            
        }



        [Test]
        public void ApplyForInstituteMissingError()
        {
            var key = 'c';

            var mockDepartment = new Mock<IDepartment>();
            mockDepartment.Setup(c => c.Id).Returns(1);
            mockDepartment.Setup(c => c.Key).Returns('a');
            _departmentService.Setup(c => c.Create(It.IsAny<DepartmentOptions>())).Returns(mockDepartment.Object);
            _departmentService.Setup(c => c.Apply(It.IsAny<int>(), It.IsAny<IApplication>())).Returns(true);
            var institute = _service.Create(new InstituteOptions()
            {
                Departments = new[]
                {
                    new DepartmentOptions()
                    {
                        DepartmentKey = key,
                        SelectionOptions = new List<SelectionOptions>()
                    }
                }
            });
            Assert.IsNotNull(institute);
            _instituteRepository.Setup(r => r.Get(It.Is<int>(id => id == 1))).Returns((institute as Institute)!);
            var ex = Assert.Throws<Exception>(() => _service.Apply(1, new Application() { Subject = key }));
            ex.Message.Contains("Not Found");

        }
    }
}
