using _3_DataAccess.QueryModels;
using _3_DataAccess.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace _3_DataAccessLayer.Tests.HighSchoolStudentQueryRepositoryTest
{
    public class HighSchoolStudentQueryRepositoryTest
    {
        private readonly Mock<IGenericRepository<HighSchoolStudentQueryModel>> _sut;
        public HighSchoolStudentQueryRepositoryTest()
        {
            _sut = new Mock<IGenericRepository<HighSchoolStudentQueryModel>>();
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
            var expected = new List<HighSchoolStudentQueryModel>() { DummyStudents()[0] };
            var filter = "andrej";
            _sut.Setup(s => s.Search(filter)).Returns(expected);

            var actual = _sut.Object.Search(filter);

            Assert.Equal(expected, actual);
        }

        private List<HighSchoolStudentQueryModel> DummyStudents()
        {
            List<HighSchoolStudentQueryModel> list = new List<HighSchoolStudentQueryModel>();

            var cs1 = new HighSchoolStudentQueryModel
            {
                UserID = Guid.NewGuid(),
                FirstName = "Andrej",
                LastName = "Markovic",
                BirthDate = DateTime.Parse("01/01/1997"),
                EnrollmentDate = DateTime.Parse("01/01/2005"),
                SchoolName="TestSchool"


            };



            var cs2 = new HighSchoolStudentQueryModel
            {
                UserID = Guid.NewGuid(),
                FirstName = "Nikola",
                LastName = "Markovic",
                BirthDate = DateTime.Parse("01/01/1997"),
                EnrollmentDate = DateTime.Parse("01/01/2005"),
                SchoolName = "TestSchool"


            };


            list.Add(cs1);
            list.Add(cs2);
            return list;


        }
    }
}
