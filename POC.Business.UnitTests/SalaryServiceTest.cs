using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using POC.Business.Helper;
using POC.Business.Interface;
using POC.Business.Service;
using POC.BusinessEntities;
using System;
using System.Collections.Generic;
using Assert = NUnit.Framework.Assert;

namespace POC.Business.UnitTests
{
    public class SalaryServiceTest
    {
        private SalaryService SalaryService { get; set; }
        private Mock<IActionFactory> _actionFactoryMock;
        private Mock<IRepositoryFactory> _repositoryFactoryMock;
        private Mock<HelperSer> _helperSer { get; set; }


        [Test]
        public void AddSalary()
        {
            //Arrange
            var salary = new Salary()
            {
                Basic = 5000_00,
                Bonus = 0,
                Incentives = 2000_00
            };
            _repositoryFactoryMock = new Mock<IRepositoryFactory>();
            _actionFactoryMock = new Mock<IActionFactory>();
            _helperSer = new Mock<HelperSer>();

            _repositoryFactoryMock.Setup(repo => repo.GetRepository<Salary>().Create(It.IsAny<Salary>()))
                .Returns(salary);

            //Act
            SalaryService = new SalaryService(_actionFactoryMock.Object, _repositoryFactoryMock.Object, _helperSer.Object);
            SalaryService.AddSalary(salary);

            //Assert
            _repositoryFactoryMock.Verify(repo => repo.GetRepository<Salary>().Create(salary), Times.Once);
        }

        [Test]
        public void GetSalaryByEmployeeIdAndCalulateGrossSalary()
        {
            //Arrange
            var salary = new Salary()
            {
                Incentives = 20_0,
                Basic = 30_0,
                Bonus = 10_0,

            };
            var employee = new Employee()
            {
                Id = 1,
                SalaryId = 2
            };

            List<Employee> lstEmp = new List<Employee>
            {
                employee
            };

            _actionFactoryMock = new Mock<IActionFactory>(); //Interface mocking
            _repositoryFactoryMock = new Mock<IRepositoryFactory>(); //Interface mocking
            _helperSer = new Mock<HelperSer>(); //class mocking

            _actionFactoryMock.Setup(action => action.EmployeeService.GetAllEmployees()).Returns(lstEmp);

            _repositoryFactoryMock.Setup(repo => repo.GetRepository<Salary>().GetById(It.IsAny<int>())).Returns(salary);

            SalaryService = new SalaryService(_actionFactoryMock.Object, _repositoryFactoryMock.Object, _helperSer.Object);

            //Act
            SalaryService.GetSalaryByEmployeeId(employee.Id);

            //Assert
            _actionFactoryMock.Verify(action => action.EmployeeService.GetAllEmployees(), Times.Once);
            _repositoryFactoryMock.Verify(x => x.GetRepository<Salary>().GetById(employee.SalaryId), Times.Once);
            Assert.AreEqual(salary.GrossSalary, 600);
        }

        [Test]
        [NUnit.Framework.Ignore("ask jenish about exception")]
        [ExpectedException(typeof(Exception), POCConstants.EmployeeNotFound)]
        public void GetSalaryByEmployeeId_ThrowException_WhenEmployeeNotFound()
        {
            //Arrange
            var employee = new Employee()
            {
                Id = 1,
                SalaryId = 2
            };

            List<Employee> lstEmp = new List<Employee>();

            _actionFactoryMock = new Mock<IActionFactory>();
            _repositoryFactoryMock = new Mock<IRepositoryFactory>();
            _helperSer = new Mock<HelperSer>();


            _actionFactoryMock.Setup(action => action.EmployeeService.GetAllEmployees()).Returns(lstEmp);

            SalaryService = new SalaryService(_actionFactoryMock.Object, _repositoryFactoryMock.Object, _helperSer.Object);

            //Act
            SalaryService.GetSalaryByEmployeeId(employee.Id);

            //Assert
            _actionFactoryMock.Verify(action => action.EmployeeService.GetAllEmployees(), Times.Once);
        }
    }
}
