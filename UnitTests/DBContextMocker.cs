using PDFFormFiller.Data;
using PDFFormFiller.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace UnitTests
{
    public static class DBContextMocker
    {
        public static DBContext GetContext(string dbName, int recordCount)
        {
            // Create options for DbContext instance
            var options = new DbContextOptionsBuilder<DBContext>()
                              .UseInMemoryDatabase(databaseName: dbName)
                              .Options;

            // Create instance of DbContext
            var dbContext = new DBContext(options);

            // Add entities in memory
            return dbContext.Seed(recordCount);
        }

        //This is necessary in order to test validations in Unit Tests. Integrations tests however do this automatically with Http Requests
        public static bool Validate(this ControllerBase controller, FieldNaming model)
        {
            var validationContext = new ValidationContext(model, null, null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(model, validationContext, validationResults, true);
            foreach (var validationResult in validationResults)
                controller.ModelState.AddModelError(validationResult.MemberNames.First(), validationResult.ErrorMessage);

            return controller.ModelState.IsValid;
        }
    }
}
