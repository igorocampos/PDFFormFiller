using Microsoft.EntityFrameworkCore.Migrations;

namespace PDFFormFiller.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FieldNaming",
                columns: table => new
                {
                    ModelFieldName = table.Column<string>(nullable: false),
                    PdfFieldName = table.Column<string>(nullable: false),
                    Page = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldNaming", x => x.ModelFieldName);
                });

            migrationBuilder.InsertData(
                table: "FieldNaming",
                columns: new[] { "ModelFieldName", "Page", "PdfFieldName" },
                values: new object[,]
                {
                    { "EnlistedOccupationYes", 1, "EMP5624_E[0].Page1[0].Yes_business[0]" },
                    { "EmployerPrincipalJobTitle", 2, "EMP5624_E[0].Page2[0].txtF_position_title[0]" },
                    { "SupportDetails", 2, "EMP5624_E[0].Page2[0].txtF_If_Yes2[0]" },
                    { "ReceiveSupportThroughProgram", 2, "EMP5624_E[0].Page2[0].rb_receive_prog[0]" },
                    { "EmployerAnnualGrossRevenue", 2, "EMP5624_E[0].Page2[0].txtF_business_revenu[0]" },
                    { "EmployerNumberOfEmployees", 2, "EMP5624_E[0].Page2[0].txtF_amout_employees[0]" },
                    { "EmployerIsRegisteredCharity", 2, "EMP5624_E[0].Page2[0].cb_registred[0]" },
                    { "EmployerPrincipalFirstName", 2, "EMP5624_E[0].Page2[0].txtF_first_name2[0]" },
                    { "EmployerIsNonProfit", 2, "EMP5624_E[0].Page2[0].cb_not_profit[0]" },
                    { "EmployerIsCorporation", 2, "EMP5624_E[0].Page2[0].cb_individual[0]" },
                    { "EmployerIsPartnership", 2, "EMP5624_E[0].Page2[0].cb_partnership[0]" },
                    { "EmployerIsSoleProprietorship", 2, "EMP5624_E[0].Page2[0].cb_sole_propietor[0]" },
                    { "EmployerBusinessStartDate", 2, "EMP5624_E[0].Page2[0].txtF_Employer_Date_Business[0]" },
                    { "EmployerWebsite", 2, "EMP5624_E[0].Page2[0].txtF_Employer_Web_Address[0]" },
                    { "EmployerMailingPostalCode", 2, "EMP5624_E[0].Page2[0].txtF_Postal_Code2[0]" },
                    { "EmployerIsCoOperative", 2, "EMP5624_E[0].Page2[0].cb_society[0]" },
                    { "EmployerMailingCountry", 2, "EMP5624_E[0].Page2[0].txtF_Country2[0]" },
                    { "EmployerPrincipalMiddleName", 2, "EMP5624_E[0].Page2[0].txtF_mid_name2[0]" },
                    { "EmployerPrincipalPhoneNumber", 2, "EMP5624_E[0].Page2[0].txtF_phone_number2[0]" },
                    { "EmployerAlternateOralLanguage", 2, "EMP5624_E[0].Page2[0].rb_other_language_oral2[0]" },
                    { "EmployerAlternateEmail", 2, "EMP5624_E[0].Page2[0].txtF_other_Email2[0]" },
                    { "EmployerAlternateFaxNumber", 2, "EMP5624_E[0].Page2[0].txtF_other_fax_number2[0]" },
                    { "EmployerAlternateAlternatePhoneNumber", 2, "EMP5624_E[0].Page2[0].txtF_other_alternate_phone2[0]" },
                    { "EmployerAlternatePhoneNumber", 2, "EMP5624_E[0].Page2[0].txtF_other_phone_number2[0]" },
                    { "EmployerAlternateLastName", 2, "EMP5624_E[0].Page2[0].txtF_other_last_name2[0]" },
                    { "EmployerPrincipalLastName", 2, "EMP5624_E[0].Page2[0].txtF_last_name2[0]" },
                    { "EmployerAlternateMiddleName", 2, "EMP5624_E[0].Page2[0].txtF_other_mid_name2[0]" },
                    { "EmployerAlternateJobTitle", 2, "EMP5624_E[0].Page2[0].txtF_other_position_title[0]" },
                    { "EmployerPrincipalWrittenLanguage", 2, "EMP5624_E[0].Page2[0].rb_language_written2[0]" },
                    { "EmployerPrincipalOralLanguage", 2, "EMP5624_E[0].Page2[0].rb_language_oral2[0]" },
                    { "EmployerPrincipalEmail", 2, "EMP5624_E[0].Page2[0].txtF_Email2[0]" },
                    { "EmployerPrincipalFaxNumber", 2, "EMP5624_E[0].Page2[0].txtF_fax_number2[0]" },
                    { "EmployerPrincipalAlternatePhoneNumber", 2, "EMP5624_E[0].Page2[0].txtF_alternate_phone2[0]" },
                    { "EmployerAlternateFirstName", 2, "EMP5624_E[0].Page2[0].txtF_other_first_name2[0]" },
                    { "EmployerAlternateWrittenLanguage", 2, "EMP5624_E[0].Page2[0].rb_other_anguage_written2[0]" },
                    { "EmployerMailingProvince", 2, "EMP5624_E[0].Page2[0].txtF_Province2[0]" },
                    { "EmployerMailingAddress2", 2, "EMP5624_E[0].Page2[0].txtF_Mail_Adress2-2[0]" },
                    { "ReferralAlternateFirstName", 1, "EMP5624_E[0].Page1[0].txtF_first_name2[0]" },
                    { "ReferralPrincipalWrittenLanguage", 1, "EMP5624_E[0].Page1[0].rb_language_written[0]" },
                    { "ReferralPrincipalOralLanguage", 1, "EMP5624_E[0].Page1[0].rb_language_oral[0]" },
                    { "ReferralPrincipalEmail", 1, "EMP5624_E[0].Page1[0].txtF_Email[0]" },
                    { "ReferralPrincipalFaxNumber", 1, "EMP5624_E[0].Page1[0].txtF_fax_number[0]" },
                    { "ReferralPrincipalAlternatePhoneNumber", 1, "EMP5624_E[0].Page1[0].txtF_alternate_phone[0]" },
                    { "ReferralAlternateMiddleName", 1, "EMP5624_E[0].Page1[0].txtF_mid_name2[0]" },
                    { "ReferralPrincipalPhoneNumber", 1, "EMP5624_E[0].Page1[0].txtF_phone_number[0]" },
                    { "ReferralPrincipalMiddleName", 1, "EMP5624_E[0].Page1[0].txtF_mid_name[0]" },
                    { "ReferralPrincipalFirstName", 1, "EMP5624_E[0].Page1[0].txtF_first_name[0]" },
                    { "ReferralOrganizationName", 1, "EMP5624_E[0].Page1[0].txtF_des_part[0]" },
                    { "InnovativeEmployerNo", 1, "EMP5624_E[0].Page1[0].No_inn[0]" },
                    { "InnovativeEmployerYes", 1, "EMP5624_E[0].Page1[0].Yes_inn[0]" },
                    { "EnlistedOccupationNo", 1, "EMP5624_E[0].Page1[0].No_business[0]" },
                    { "ReferralPrincipalLastName", 1, "EMP5624_E[0].Page1[0].txtF_last_name[0]" },
                    { "EmployerMailingCity", 2, "EMP5624_E[0].Page2[0].txtF_City2[0]" },
                    { "ReferralAlternateLastName", 1, "EMP5624_E[0].Page1[0].txtF_last_name2[0]" },
                    { "ReferralAlternateAlternatePhoneNumber", 1, "EMP5624_E[0].Page1[0].txtF_alternate_phone2[0]" },
                    { "EmployerMailingAddress1", 2, "EMP5624_E[0].Page2[0].txtF_Mail_Adress2-1[0]" },
                    { "EmployerBusinessPostalCode", 2, "EMP5624_E[0].Page2[0].txtF_Postal_Code[0]" },
                    { "EmployerBusinessCountry", 2, "EMP5624_E[0].Page2[0].txtF_Country[0]" },
                    { "EmployerBusinessProvince", 2, "EMP5624_E[0].Page2[0].txtF_Province[0]" },
                    { "EmployerBusinessCity", 2, "EMP5624_E[0].Page2[0].txtF_City[0]" },
                    { "EmployerBusinessAddress2", 2, "EMP5624_E[0].Page2[0].txtF_Mail_Adress2[0]" },
                    { "ReferralAlternatePhoneNumber", 1, "EMP5624_E[0].Page1[0].txtF_phone_number2[0]" },
                    { "EmployerBusinessAddress1", 2, "EMP5624_E[0].Page2[0].txtF_Mail_Adress1[0]" },
                    { "EmployerRevenueDeductionsAccountNumber2", 2, "EMP5624_E[0].Page2[0].num_Company_Code[1]" },
                    { "EmployerRevenueDeductionsAccountNumber1", 2, "EMP5624_E[0].Page2[0].num_Company_Code[0]" },
                    { "ReferralAlternateWrittenLanguage", 1, "EMP5624_E[0].Page1[0].rb_language_written2[0]" },
                    { "ReferralAlternateOralLanguage", 1, "EMP5624_E[0].Page1[0].rb_language_oral2[0]" },
                    { "ReferralAlternateEmail", 1, "EMP5624_E[0].Page1[0].txtF_Email2[0]" },
                    { "ReferralAlternateFaxNumber", 1, "EMP5624_E[0].Page1[0].txtF_fax_number2[0]" },
                    { "EmployerBusinessLegalName", 2, "EMP5624_E[0].Page2[0].txtF_Emp_Legal[0]" },
                    { "AppointingThirdParty", 2, "EMP5624_E[0].Page2[0].rb_tiers[0]" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FieldNaming");
        }
    }
}
