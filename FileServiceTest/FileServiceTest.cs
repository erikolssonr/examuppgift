using Assignment_Catalogue.Services;

namespace FileServiceTest
{
    public class FileServiceTest
    {
        public class ReadFromFileServiceTest
        {
            [Fact]
            public void ReadFromFile_FileDoesNotExist_ReturnsNull() //xUnit test that checks if the file exists, if it doesnt exist it will return null and the test will succeed. If the file exists
                                                                    //it will fail due to not returning null.
            {
                // Arrange
                var filePath = @"C:\Users\eriko\contacts.json";

                // Act
                var result = FileService.ReadFromFile(filePath);

                // Assert
                Assert.Null(result);
            }
        }
    }
}