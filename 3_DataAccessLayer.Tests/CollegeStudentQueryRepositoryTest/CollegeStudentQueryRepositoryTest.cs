using _3_DataAccess.QueryModels;
using _3_DataAccess.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace _3_DataAccessLayer.Tests.CollegeStudentQueryRepositoryTest
{
    public class CollegeStudentQueryRepositoryTest
    {
        private readonly Mock<IGenericRepository<CollegeStudentQueryModel>> _sut;
        public CollegeStudentQueryRepositoryTest()
        {
            _sut = new Mock<IGenericRepository<CollegeStudentQueryModel>>();
        }

        [Fact]
        public void GetAll_Should_Return_List_If_List_Exists()
        {
            var expected = DummyStudents();
            _sut.Setup(s => s.GetAll()).Returns(expected);

            var actual = _sut.Object.GetAll();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Search_Should_Return_Result_If_Result_Exist()
        {
            var expected = new List<CollegeStudentQueryModel>() { DummyStudents()[0] };
            var filter = "andrej";
            _sut.Setup(s => s.Search(filter)).Returns(expected);

            var actual = _sut.Object.Search(filter);

            Assert.Equal(expected, actual);
        }

        private List<CollegeStudentQueryModel> DummyStudents()
        {
            List<CollegeStudentQueryModel> list = new List<CollegeStudentQueryModel>();

            var cs1 = new CollegeStudentQueryModel
            {
                UserID = Guid.NewGuid(),
                FirstName = "Andrej",
                LastName = "Markovic",
                BirthDate = DateTime.Parse("01/01/1997"),
                Generation = 2015,
                InstitutionName = "FON",
                

            };
           
            

            var cs2 = new CollegeStudentQueryModel
            {
                UserID = Guid.NewGuid(),
                FirstName = "Nikola",
                LastName = "Markovic",
                BirthDate = DateTime.Parse("01/01/1997"),
               
                Generation = 2015,
                InstitutionName = "FON",
                

            };
           

            list.Add(cs1);
            list.Add(cs2);
            return list;


        }
    }
}
