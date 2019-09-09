using Moq;
using NUnit.Framework;
using POC.Business.Interface;
using POC.Business.Service;
using POC.BusinessEntities;

namespace POC.Business.UnitTests
{
    public class EmployeeServiceTest
    {

        private EmployeeService EmployeeService { get; set; }
        private Mock<IActionFactory> _actionFactoryMock;
        private Mock<IRepositoryFactory> _repositoryFactoryMock;


        [Test]
        public void AddEmployee_CheckFullName()
        {
            //Arrange
            var emp = GetEmployee();
            var address = GetAddress();

            _repositoryFactoryMock = new Mock<IRepositoryFactory>();
            _repositoryFactoryMock.Setup(repo => repo.GetRepository<Employee>().Create(It.IsAny<Employee>())).Returns(emp);

            _actionFactoryMock = new Mock<IActionFactory>();
            _actionFactoryMock.Setup(action => action.AddressService.Create(It.IsAny<Address>()));
            _actionFactoryMock.Setup(action => action.AddressService.GetAdreessById(It.IsAny<int>())).Returns(address);

            EmployeeService = new EmployeeService(_actionFactoryMock.Object, _repositoryFactoryMock.Object);

            //Act
            var employee = EmployeeService.AddEmployees(emp, address);

            //Assert
            Assert.AreEqual(employee.FullName, emp.FirstName + " " + emp.LastName);
            _actionFactoryMock.Verify(action => action.AddressService.Create(address), Times.Once);
            _actionFactoryMock.Verify(action => action.AddressService.GetAdreessById(employee.AddressId), Times.Once);
        }

        private Address GetAddress()
        {
            var address = new Address()
            {
                City = "Pune",
                Landmark = "POC",
                Street = "High street",
                ZipCode = 54321
            };
            return address;
        }

        private Employee GetEmployee()
        {
            var emp = new Employee()
            {
                FirstName = "Akshay",
                LastName = "Tilekar",
                Designation = "SE"
            };
            return emp;
        }
    }
}