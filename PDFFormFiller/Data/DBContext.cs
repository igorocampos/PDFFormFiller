using Microsoft.EntityFrameworkCore;

namespace PDFFormFiller.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        public DbSet<FieldNaming> FieldNaming { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FieldNaming>().HasData(
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page1[0].Yes_business[0]",
                    ModelFieldName = "EnlistedOccupationYes",
                    Page = 1
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page1[0].No_business[0]",
                    ModelFieldName = "EnlistedOccupationNo",
                    Page = 1
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page1[0].Yes_inn[0]",
                    ModelFieldName = "InnovativeEmployerYes",
                    Page = 1
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page1[0].No_inn[0]",
                    ModelFieldName = "InnovativeEmployerNo",
                    Page = 1
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page1[0].txtF_des_part[0]",
                    ModelFieldName = "ReferralOrganizationName",
                    Page = 1
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page1[0].txtF_first_name[0]",
                    ModelFieldName = "ReferralPrincipalFirstName",
                    Page = 1
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page1[0].txtF_mid_name[0]",
                    ModelFieldName = "ReferralPrincipalMiddleName",
                    Page = 1
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page1[0].txtF_last_name[0]",
                    ModelFieldName = "ReferralPrincipalLastName",
                    Page = 1
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page1[0].txtF_phone_number[0]",
                    ModelFieldName = "ReferralPrincipalPhoneNumber",
                    Page = 1
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page1[0].txtF_alternate_phone[0]",
                    ModelFieldName = "ReferralPrincipalAlternatePhoneNumber",
                    Page = 1
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page1[0].txtF_fax_number[0]",
                    ModelFieldName = "ReferralPrincipalFaxNumber",
                    Page = 1
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page1[0].txtF_Email[0]",
                    ModelFieldName = "ReferralPrincipalEmail",
                    Page = 1
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page1[0].rb_language_oral[0]",
                    ModelFieldName = "ReferralPrincipalOralLanguage",
                    Page = 1
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page1[0].rb_language_written[0]",
                    ModelFieldName = "ReferralPrincipalWrittenLanguage",
                    Page = 1
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page1[0].txtF_first_name2[0]",
                    ModelFieldName = "ReferralAlternateFirstName",
                    Page = 1
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page1[0].txtF_mid_name2[0]",
                    ModelFieldName = "ReferralAlternateMiddleName",
                    Page = 1
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page1[0].txtF_last_name2[0]",
                    ModelFieldName = "ReferralAlternateLastName",
                    Page = 1
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page1[0].txtF_phone_number2[0]",
                    ModelFieldName = "ReferralAlternatePhoneNumber",
                    Page = 1
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page1[0].txtF_alternate_phone2[0]",
                    ModelFieldName = "ReferralAlternateAlternatePhoneNumber",
                    Page = 1
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page1[0].txtF_fax_number2[0]",
                    ModelFieldName = "ReferralAlternateFaxNumber",
                    Page = 1
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page1[0].txtF_Email2[0]",
                    ModelFieldName = "ReferralAlternateEmail",
                    Page = 1
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page1[0].rb_language_oral2[0]",
                    ModelFieldName = "ReferralAlternateOralLanguage",
                    Page = 1
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page1[0].rb_language_written2[0]",
                    ModelFieldName = "ReferralAlternateWrittenLanguage",
                    Page = 1
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].num_Company_Code[0]",
                    ModelFieldName = "EmployerRevenueDeductionsAccountNumber1",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].num_Company_Code[1]",
                    ModelFieldName = "EmployerRevenueDeductionsAccountNumber2",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].txtF_Emp_Legal[0]",
                    ModelFieldName = "EmployerBusinessLegalName",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].txtF_Mail_Adress1[0]",
                    ModelFieldName = "EmployerBusinessAddress1",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].txtF_Mail_Adress2[0]",
                    ModelFieldName = "EmployerBusinessAddress2",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].txtF_City[0]",
                    ModelFieldName = "EmployerBusinessCity",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].txtF_Province[0]",
                    ModelFieldName = "EmployerBusinessProvince",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].txtF_Country[0]",
                    ModelFieldName = "EmployerBusinessCountry",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].txtF_Postal_Code[0]",
                    ModelFieldName = "EmployerBusinessPostalCode",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].txtF_Mail_Adress2-1[0]",
                    ModelFieldName = "EmployerMailingAddress1",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].txtF_Mail_Adress2-2[0]",
                    ModelFieldName = "EmployerMailingAddress2",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].txtF_City2[0]",
                    ModelFieldName = "EmployerMailingCity",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].txtF_Province2[0]",
                    ModelFieldName = "EmployerMailingProvince",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].txtF_Country2[0]",
                    ModelFieldName = "EmployerMailingCountry",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].txtF_Postal_Code2[0]",
                    ModelFieldName = "EmployerMailingPostalCode",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].txtF_Employer_Web_Address[0]",
                    ModelFieldName = "EmployerWebsite",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].txtF_Employer_Date_Business[0]",
                    ModelFieldName = "EmployerBusinessStartDate",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].cb_sole_propietor[0]",
                    ModelFieldName = "EmployerIsSoleProprietorship",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].cb_partnership[0]",
                    ModelFieldName = "EmployerIsPartnership",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].cb_individual[0]",
                    ModelFieldName = "EmployerIsCorporation",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].cb_society[0]",
                    ModelFieldName = "EmployerIsCoOperative",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].cb_not_profit[0]",
                    ModelFieldName = "EmployerIsNonProfit",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].cb_registred[0]",
                    ModelFieldName = "EmployerIsRegisteredCharity",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].txtF_amout_employees[0]",
                    ModelFieldName = "EmployerNumberOfEmployees",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].txtF_business_revenu[0]",
                    ModelFieldName = "EmployerAnnualGrossRevenue",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].rb_receive_prog[0]",
                    ModelFieldName = "ReceiveSupportThroughProgram",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].txtF_If_Yes2[0]",
                    ModelFieldName = "SupportDetails",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].txtF_position_title[0]",
                    ModelFieldName = "EmployerPrincipalJobTitle",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].txtF_first_name2[0]",
                    ModelFieldName = "EmployerPrincipalFirstName",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].txtF_mid_name2[0]",
                    ModelFieldName = "EmployerPrincipalMiddleName",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].txtF_last_name2[0]",
                    ModelFieldName = "EmployerPrincipalLastName",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].txtF_phone_number2[0]",
                    ModelFieldName = "EmployerPrincipalPhoneNumber",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].txtF_alternate_phone2[0]",
                    ModelFieldName = "EmployerPrincipalAlternatePhoneNumber",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].txtF_fax_number2[0]",
                    ModelFieldName = "EmployerPrincipalFaxNumber",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].txtF_Email2[0]",
                    ModelFieldName = "EmployerPrincipalEmail",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].rb_language_oral2[0]",
                    ModelFieldName = "EmployerPrincipalOralLanguage",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].rb_language_written2[0]",
                    ModelFieldName = "EmployerPrincipalWrittenLanguage",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].txtF_other_position_title[0]",
                    ModelFieldName = "EmployerAlternateJobTitle",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].txtF_other_first_name2[0]",
                    ModelFieldName = "EmployerAlternateFirstName",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].txtF_other_mid_name2[0]",
                    ModelFieldName = "EmployerAlternateMiddleName",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].txtF_other_last_name2[0]",
                    ModelFieldName = "EmployerAlternateLastName",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].txtF_other_phone_number2[0]",
                    ModelFieldName = "EmployerAlternatePhoneNumber",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].txtF_other_alternate_phone2[0]",
                    ModelFieldName = "EmployerAlternateAlternatePhoneNumber",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].txtF_other_fax_number2[0]",
                    ModelFieldName = "EmployerAlternateFaxNumber",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].txtF_other_Email2[0]",
                    ModelFieldName = "EmployerAlternateEmail",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].rb_other_language_oral2[0]",
                    ModelFieldName = "EmployerAlternateOralLanguage",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].rb_other_anguage_written2[0]",
                    ModelFieldName = "EmployerAlternateWrittenLanguage",
                    Page = 2
                },
                new FieldNaming
                {
                    PdfFieldName = "EMP5624_E[0].Page2[0].rb_tiers[0]",
                    ModelFieldName = "AppointingThirdParty",
                    Page = 2
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
