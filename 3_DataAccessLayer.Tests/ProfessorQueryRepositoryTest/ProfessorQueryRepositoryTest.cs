using _3_DataAccess.QueryModels;
using _3_DataAccess.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace _3_DataAccessLayer.Tests.ProfessorQueryRepositoryTest
{
    public class ProfessorQueryRepositoryTest
    {
        private readonly Mock<IGenericRepository<ProfessorQueryModel>> _sut;
        public ProfessorQueryRepositoryTest()
        {
            _sut = new Mock<IGenericRepository<ProfessorQueryModel>>();
        }

        [Fact]
        public void GetAll_Should_Return_List_If_List_Exists()
        {
            var expected = DummyProfessors();
            _sut.Setup(s => s.GetAll()).Returns(expected);

            var actual = _sut.Object.GetAll();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Search_Should_Return_Result_If_Result_Exist()
        {
            var expected = new List<ProfessorQueryModel>() { DummyProfessors()[0] };
            var filter = "andrej";
            _sut.Setup(s => s.Search(filter)).Returns(expected);

            var actual = _sut.Object.Search(filter);

            Assert.Equal(expected, actual);
        }
        private List<ProfessorQueryModel> DummyProfessors()
        {
            List<ProfessorQueryModel> list = new List<ProfessorQueryModel>();

            var prof1 = new ProfessorQueryModel
            {
                UserID = Guid.NewGuid(),
                FirstName = "Andrej",
                LastName = "Markovic",
                BirthDate = DateTime.Parse("01/01/1997"),

                Cabinet = "100",
                Subject = "P1",


            };


            var prof2 = new ProfessorQueryModel
            {
                UserID = Guid.NewGuid(),
                FirstName = "Nikola",
                LastName = "Markovic",
                BirthDate = DateTime.Parse("01/01/1997"),

                Subject = "P2",
                Cabinet = "103",


            };


            list.Add(prof1);
            list.Add(prof2);
            return list;


        }
    }
    
}
