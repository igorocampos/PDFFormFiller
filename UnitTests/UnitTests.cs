using PDFFormFiller.Controllers;
using PDFFormFiller.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class UnitTests
    {
        const int TOTAL_RECORDS = 5;
        const string FIELD_NAME = "FieldName";
        const string PDF_NAME = "PDFName";

        [Fact]
        public async Task TestTotalRecords()
        {
            //dbContext will be created with 5 records
            using (var dbContext = DBContextMocker.GetContext(nameof(TestTotalRecords), TOTAL_RECORDS))
            {
                // Arrange
                var controller = new FieldNamingsController(dbContext);

                // Act
                var response = await controller.GetFieldNaming();

                // Assert
                Assert.Equal(TOTAL_RECORDS, response.Value.Count());
            }
        }

        [Theory]
        [InlineData(0, TOTAL_RECORDS)]
        [InlineData(1, 1)]
        [InlineData(2, TOTAL_RECORDS - 1)]
        [InlineData(3, 0)]
        public async Task TestTotalRecords_PageFilter(int page, int expected)
        {
            //dbContext will be created with 5 records
            using (var dbContext = DBContextMocker.GetContext($"{nameof(TestTotalRecords_PageFilter)}_{page}", TOTAL_RECORDS))
            {
                // Arrange
                foreach (var fieldNaming in dbContext.FieldNaming)
                    fieldNaming.Page = 2;

                dbContext.FieldNaming.First().Page = 1;
                dbContext.SaveChanges();

                var controller = new FieldNamingsController(dbContext);

                // Act
                var response = await controller.GetFieldNaming(page);

                // Assert
                Assert.Equal(expected, response.Value.Count());
            }
        }

        [Theory]
        [InlineData("")]
        [InlineData(FIELD_NAME)]
        public async Task TestGetRecipe(string id)
        {
            //dbContext will be created with 5 records
            using var dbContext = DBContextMocker.GetContext($"{nameof(TestGetRecipe)}_{id}", TOTAL_RECORDS);

            // Arrange
            dbContext.FieldNaming.Add(new FieldNaming
            {
                ModelFieldName = FIELD_NAME,
                PdfFieldName = PDF_NAME,
                Page = 1
            });
            dbContext.SaveChanges();

            var controller = new FieldNamingsController(dbContext);

            // Act
            var response = await controller.GetFieldNaming(id);

            // Assert
            Assert.True(id != FIELD_NAME ? response.Result is NotFoundResult : response.Value.ModelFieldName == id, "Either the returned ID was different from the requested, or it found a model when it should not.");
        }

        [Theory]
        [InlineData(FIELD_NAME, PDF_NAME, 1, nameof(CreatedAtActionResult))]
        [InlineData(null, PDF_NAME, 1)]
        [InlineData("", PDF_NAME, 1)]
        [InlineData(FIELD_NAME, null, 1)]
        [InlineData(FIELD_NAME, "", 1)]
        [InlineData(FIELD_NAME, PDF_NAME, null)]
        [InlineData(FIELD_NAME, PDF_NAME, 0)]
        [InlineData(FIELD_NAME, PDF_NAME, 14)]
        public async Task TestCreate(string modelName, string pdfName, int? page, string expectedResultName = null)
        {
            //dbContext will be created with 0 records
            using var dbContext = DBContextMocker.GetContext(nameof(TestCreate), 0);

            // Arrange
            var record = new FieldNaming
            {
                ModelFieldName = modelName,
                PdfFieldName = pdfName
            };

            //This simulates when user don't fill difficulty field in the JSON that is sent
            if (page is int intPage)
                record.Page = intPage;

            var controller = new FieldNamingsController(dbContext);

            // Act
            ActionResult<FieldNaming> response = null;

            // Mimic the behaviour of the model binder which is responsible for Validating the Model
            if (controller.Validate(record))
                response = await controller.PostFieldNaming(record);

            // Assert
            Assert.True(response?.Result.GetType().Name == expectedResultName, expectedResultName is null
                                                                               ? "It was expected that this test case would not pass the model biding validation, however it did."
                                                                               : $"It was expected that this test case would have a '{expectedResultName}' return, however it did not.");
        }

        [Theory]
        [InlineData(FIELD_NAME, FIELD_NAME, nameof(NoContentResult))]
        [InlineData(FIELD_NAME, "", nameof(BadRequestResult))]
        [InlineData("", "", nameof(NotFoundResult))]
        public async Task TestUpdate(string id, string jsonId, string expectedResultName)
        {
            //dbContext will be created
            using var dbContext = DBContextMocker.GetContext($"{nameof(TestUpdate)}_{id}_{jsonId}", TOTAL_RECORDS);

            // Arrange
            var record = new FieldNaming
            {
                ModelFieldName = FIELD_NAME,
                PdfFieldName = PDF_NAME,
                Page = 1
            };
            dbContext.FieldNaming.Add(record);
            dbContext.SaveChanges();

            //Changing data for update
            record.PdfFieldName = "Changed Name";
            record.ModelFieldName = jsonId;

            var controller = new FieldNamingsController(dbContext);

            // Act
            var response = await controller.PutFieldNaming(id, record);

            // Assert
            Assert.True(response.GetType().Name == expectedResultName, $"It was expected that this test case would have a '{expectedResultName}' return, however it did not. Actual result type: {response.GetType()}.");
        }

        [Theory]
        [InlineData(FIELD_NAME, nameof(OkObjectResult))]
        [InlineData("", nameof(NotFoundResult))]
        public async Task TestDelete(string id, string expectedResultName)
        {
            //dbContext will be created
            using var dbContext = DBContextMocker.GetContext($"{nameof(TestUpdate)}_{id}", TOTAL_RECORDS);

            // Arrange
            var record = new FieldNaming
            {
                ModelFieldName = FIELD_NAME,
                PdfFieldName = PDF_NAME,
                Page = 1
            };
            dbContext.FieldNaming.Add(record);
            dbContext.SaveChanges();

            var controller = new FieldNamingsController(dbContext);

            // Act
            var response = await controller.DeleteFieldNaming(id);

            // Assert
            Assert.True(response.Result.GetType().Name == expectedResultName, $"It was expected that this test case would have a '{expectedResultName}' return, however it did not. Actual result type: {response.GetType()}.");
        }
    }
}
