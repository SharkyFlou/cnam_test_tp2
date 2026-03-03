using LoanLibrary.InsuranceInterest;
using LoanLibrary.InsuranceInterest.InterstModifiersFileLoader;

namespace LoanTest
{
    public class InterstModifiersFileLoaderTests : IDisposable
    {
        private readonly List<string> _tempFiles = new List<string>();

        private string CreateTempFile(string content)
        {
            string path = Path.GetTempFileName();
            File.WriteAllText(path, content);
            _tempFiles.Add(path);
            return path;
        }

        public void Dispose()
        {
            foreach (var path in _tempFiles)
            {
                if (File.Exists(path))
                    File.Delete(path);
            }
        }


        [Fact]
        public void GetAllInterestInsuranceModifier_ValidFile_ShouldReturnAllModifiers()
        {
            string content = "Sportif;-0,05;Habits\nFumeur;0,15;Habits\nPilote;0,15;Job";
            string path = CreateTempFile(content);
            var loader = new InterstModifiersFileLoader(path);

            var result = loader.GetAllInterestInsuranceModifier();

            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void GetAllInterestInsuranceModifier_ValidFile_ShouldParseNamesCorrectly()
        {
            string content = "Sportif;-0,05;Habits\nPilote;0,15;Job";
            string path = CreateTempFile(content);
            var loader = new InterstModifiersFileLoader(path);

            var result = loader.GetAllInterestInsuranceModifier();

            Assert.Equal("Sportif", result[0]._name);
            Assert.Equal("Pilote", result[1]._name);
        }

        [Fact]
        public void GetAllInterestInsuranceModifier_ValidFile_ShouldParseTypesCorrectly()
        {
            string content = "Sportif;-0,05;Habits\nPilote;0,15;Job";
            string path = CreateTempFile(content);
            var loader = new InterstModifiersFileLoader(path);

            var result = loader.GetAllInterestInsuranceModifier();

            Assert.Equal(InterestInsuranceType.Habits, result[0]._interestInsuranceType);
            Assert.Equal(InterestInsuranceType.Job, result[1]._interestInsuranceType);
        }


        [Fact]
        public void GetAllInterestInsuranceModifier_EmptyFile_ShouldReturnEmptyList()
        {
            string path = CreateTempFile("");
            var loader = new InterstModifiersFileLoader(path);

            var result = loader.GetAllInterestInsuranceModifier();

            Assert.Empty(result);
        }


        [Fact]
        public void GetAllInterestInsuranceModifier_NonExistentFile_ShouldReturnEmptyList()
        {
            var loader = new InterstModifiersFileLoader("nonexistent_file_path.txt");

            var result = loader.GetAllInterestInsuranceModifier();

            Assert.Empty(result);
        }


        [Theory]
        [InlineData("InvalidLine")]
        [InlineData("OnlyTwo;Fields")]
        [InlineData("Too;Many;Fields;Here")]
        public void GetAllInterestInsuranceModifier_InvalidLineFormat_ShouldReturnEmptyList(string invalidContent)
        {
            string path = CreateTempFile(invalidContent);
            var loader = new InterstModifiersFileLoader(path);

            var result = loader.GetAllInterestInsuranceModifier();

            Assert.Empty(result);
        }


        [Fact]
        public void GetAllInterestInsuranceModifier_InvalidModifierType_ShouldReturnEmptyList()
        {
            string content = "Test;0,1;InvalidType";
            string path = CreateTempFile(content);
            var loader = new InterstModifiersFileLoader(path);

            var result = loader.GetAllInterestInsuranceModifier();

            Assert.Empty(result);
        }


        [Fact]
        public void GetAllInterestInsuranceModifier_SingleEntry_ShouldReturnOneModifier()
        {
            string content = "Ingenieur;-0,05;Job";
            string path = CreateTempFile(content);
            var loader = new InterstModifiersFileLoader(path);

            var result = loader.GetAllInterestInsuranceModifier();

            Assert.Single(result);
            Assert.Equal("Ingenieur", result[0]._name);
            Assert.Equal(InterestInsuranceType.Job, result[0]._interestInsuranceType);
        }
    }
}
