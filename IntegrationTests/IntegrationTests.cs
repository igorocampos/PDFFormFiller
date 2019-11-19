using PDFFormFiller;
using PDFFormFiller.Data;
using PDFFormFiller.Models;
using iText.Forms;
using iText.Kernel.Pdf;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    public class IntegrationTests : IntegrationTestsBase<Startup>
    {
        const string FIELD_NAME = "FieldName";
        const string PDF_NAME = "PDFName";

        [Fact]
        public async Task List_EndpointReturnSuccessAndCorrectContentType()
        {
            // Arrange

            // Act
            var response = await this.Client.GetAsync("api/FieldNamings");

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());

            Assert.Empty(response.ContentAsType<IEnumerable<FieldNaming>>());
        }

        [Fact]
        public async Task Get_EndpointReturnSuccessAndCorrectContentType()
        {
            try
            {
                // Arrange
                this.DBContext.Seed(1);

                string id = this.DBContext.FieldNaming.First().ModelFieldName;

                // Act
                var response = await this.Client.GetAsync($"api/FieldNamings/{id}");

                // Assert
                response.EnsureSuccessStatusCode(); // Status Code 200-299
                Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());

                var result = response.ContentAsType<FieldNaming>();
                Assert.Equal(result.ModelFieldName, id);
            }
            finally
            {
                //Clear Data
                await ClearAll();
            }
        }

        [Fact]
        public async Task Get_EndpointReturnNotFound()
        {
            // Arrange

            // Act
            var response = await this.Client.GetAsync($"api/FieldNamings/{FIELD_NAME}");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Create_EndpointReturnSuccessAndCorrectContentType()
        {
            try
            {
                // Arrange
                var record = new FieldNaming
                {
                    ModelFieldName = FIELD_NAME,
                    PdfFieldName = PDF_NAME,
                    Page = 1
                };

                var response = await this.Client.PostAsync("/api/FieldNamings", record.GetStringContent());

                // Assert
                Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
                var returnedRecord = response.ContentAsType<FieldNaming>();
                Assert.Equal(record.ModelFieldName, returnedRecord.ModelFieldName);
                Assert.Equal(record.PdfFieldName, returnedRecord.PdfFieldName);
                Assert.Equal(record.Page, returnedRecord.Page);
            }
            finally
            {
                //Clear Data
                await ClearAll();
            }
        }

        [Fact]
        public async Task Update_EndpointReturnSucessAndNoContent()
        {
            try
            {
                // Arrange
                this.DBContext.Seed(1);
                var record = this.DBContext.FieldNaming.First();
                var id = record.ModelFieldName;
                record.PdfFieldName = PDF_NAME;

                //Act
                var response = await (this.Client.PutAsync($"api/FieldNamings/{id}", record.GetStringContent()));

                // Assert
                Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
            }
            finally
            {
                //Clear Data
                await ClearAll();
            }
        }

        [Fact]
        public async Task Update_EndpointReturnNotFound()
        {
            // Arrange
            var record = new FieldNaming
            {
                ModelFieldName = FIELD_NAME,
                PdfFieldName = PDF_NAME,
                Page = 1
            };

            //Act
            var response = await (this.Client.PutAsync($"api/FieldNamings/{FIELD_NAME}", record.GetStringContent()));

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Delete_EndpointReturnSuccessAndCorrectContentType()
        {
            try
            {
                // Arrange
                this.DBContext.Seed(1);
                var record = this.DBContext.FieldNaming.First();

                //Act
                var response = await this.Client.DeleteAsync($"api/FieldNamings/{record.ModelFieldName}");

                // Assert
                Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
                var returnedRecord = response.ContentAsType<FieldNaming>();
                Assert.Equal(record.ModelFieldName, returnedRecord.ModelFieldName);
                Assert.Equal(record.PdfFieldName, returnedRecord.PdfFieldName);
                Assert.Equal(record.Page, returnedRecord.Page);
            }
            finally
            {
                await ClearAll();
            }
        }

        [Fact]
        public async Task Delete_EndpointReturnNotFound()
        {
            // Arrange

            //Act
            var response = await this.Client.DeleteAsync($"api/FieldNamings/{FIELD_NAME}");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task GetPDF_EndpointReturnSuccessAndCorrectContentType()
        {
            // Arrange
            var data = new ApplicationForm
            {
                EmployerBusinessLegalName = "AAA"
            };

            // Act
            var response = await this.Client.PostAsync("api/ApplicationForm", data.GetStringContent());

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/pdf", response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async Task GetPDF_EndpointReturnSuccessAndCorrectContent()
        {
            // Arrange
            const string ReferralOrganizationName = "EMP5624_E[0].Page1[0].txtF_des_part[0]";
            const string ReferralPrincipalOralLanguage = "EMP5624_E[0].Page1[0].rb_language_oral[0]";
            const string ReferralPrincipalWrittenLanguage = "EMP5624_E[0].Page1[0].rb_language_written[0]";
            const string AppointingThirdParty = "EMP5624_E[0].Page2[0].rb_tiers[0]";
            const string EmployerIsCoOperative = "EMP5624_E[0].Page2[0].cb_society[0]";
            const string EmployerIsCorporation = "EMP5624_E[0].Page2[0].cb_individual[0]";

            DBContext.FieldNaming.AddRange
            (
                new FieldNaming
                {
                    ModelFieldName = nameof(ReferralOrganizationName),
                    PdfFieldName = ReferralOrganizationName
                },
                new FieldNaming
                {
                    ModelFieldName = nameof(ReferralPrincipalOralLanguage),
                    PdfFieldName = ReferralPrincipalOralLanguage
                },
                new FieldNaming
                {
                    ModelFieldName = nameof(ReferralPrincipalWrittenLanguage),
                    PdfFieldName = ReferralPrincipalWrittenLanguage
                },
                new FieldNaming
                {
                    ModelFieldName = nameof(AppointingThirdParty),
                    PdfFieldName = AppointingThirdParty
                },
                new FieldNaming
                {
                    ModelFieldName = nameof(EmployerIsCoOperative),
                    PdfFieldName = EmployerIsCoOperative
                },
                new FieldNaming
                {
                    ModelFieldName = nameof(EmployerIsCorporation),
                    PdfFieldName = EmployerIsCorporation
                }
            );

            await DBContext.SaveChangesAsync();
            var data = new ApplicationForm
            {
                ReferralOrganizationName = string.Join(' ', DatabaseHelper.RandomStrings(3)),
                ReferralPrincipalOralLanguage = Language.French,
                ReferralPrincipalWrittenLanguage = Language.English,
                AppointingThirdParty = YesNo.No,
                EmployerIsCoOperative = true,
                EmployerIsCorporation = true
            };

            // Act
            var response = await this.Client.PostAsync("api/ApplicationForm", data.GetStringContent());

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299

            using Stream pdf = await response.Content.ReadAsStreamAsync();
            using PdfDocument pdfDoc = new PdfDocument(new PdfReader(pdf));

            PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, false);

            Assert.Equal(data.ReferralOrganizationName, form.GetField(ReferralOrganizationName).GetValueAsString());
            Assert.Equal((int)data.ReferralPrincipalOralLanguage, Convert.ToInt32(form.GetField(ReferralPrincipalOralLanguage).GetValueAsString()));
            Assert.Equal((int)data.ReferralPrincipalWrittenLanguage, Convert.ToInt32(form.GetField(ReferralPrincipalWrittenLanguage).GetValueAsString()));
            Assert.Equal((int)data.AppointingThirdParty, Convert.ToInt32(form.GetField(AppointingThirdParty).GetValueAsString()));

            Assert.Equal(data.EmployerIsCoOperative.ToString(), form.GetField(EmployerIsCoOperative).GetValueAsString(), true);
            Assert.Equal(data.EmployerIsCorporation.ToString(), form.GetField(EmployerIsCorporation).GetValueAsString(), true);
        }

        private async Task ClearAll()
        {
            foreach (var record in this.DBContext.FieldNaming)
                this.DBContext.Remove(record);

            await DBContext.SaveChangesAsync();
        }
    }

    public class IntegrationTestsBase<TStartup> : IDisposable where TStartup : class
    {
        const string DB_NAME = "TestDataBase";

        private readonly TestServer server;

        public IntegrationTestsBase()
        {
            var host = new WebHostBuilder()
                            .UseStartup<TStartup>()
                            .ConfigureServices(ConfigureServices);

            this.server = new TestServer(host);
            this.Client = this.server.CreateClient();
        }

        public HttpClient Client { get; }

        public DBContext DBContext { get; private set; }

        public void Dispose()
        {
            this.Client.Dispose();
            this.server.Dispose();
        }

        protected virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DBContext>(options => options.UseInMemoryDatabase(DB_NAME));

            // Create options for DbContext instance
            var options = new DbContextOptionsBuilder<DBContext>()
                              .UseInMemoryDatabase(DB_NAME)
                              .Options;

            // Create instance of DbContext
            DBContext = new DBContext(options);
        }
    }
}
