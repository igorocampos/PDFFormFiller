using System.Text.Json.Serialization;

namespace PDFFormFiller.Models
{
    public class ApplicationForm
    {
        public bool EnlistedOccupationYes { get; set; }
        public bool EnlistedOccupationNo { get; set; }
        public bool InnovativeEmployerYes { get; set; }
        public bool InnovativeEmployerNo { get; set; }
        public string ReferralOrganizationName { get; set; }

        public string ReferralPrincipalFirstName { get; set; }
        public string ReferralPrincipalMiddleName { get; set; }
        public string ReferralPrincipalLastName { get; set; }
        public string ReferralPrincipalPhoneNumber { get; set; }
        public string ReferralPrincipalAlternatePhoneNumber { get; set; }
        public string ReferralPrincipalFaxNumber { get; set; }
        public string ReferralPrincipalEmail { get; set; }

        public Language? ReferralPrincipalOralLanguage { get; set; }
        public Language? ReferralPrincipalWrittenLanguage { get; set; }

        public string ReferralAlternateFirstName { get; set; }
        public string ReferralAlternateMiddleName { get; set; }
        public string ReferralAlternateLastName { get; set; }
        public string ReferralAlternatePhoneNumber { get; set; }
        public string ReferralAlternateAlternatePhoneNumber { get; set; }
        public string ReferralAlternateFaxNumber { get; set; }
        public string ReferralAlternateEmail { get; set; }

        public Language? ReferralAlternateOralLanguage { get; set; }
        public Language? ReferralAlternateWrittenLanguage { get; set; }

        public int? EmployerRevenueDeductionsAccountNumber1 { get; set; }
        public int? EmployerRevenueDeductionsAccountNumber2 { get; set; }

        public string EmployerBusinessLegalName { get; set; }
        public string EmployerBusinessAddress1 { get; set; }
        public string EmployerBusinessAddress2 { get; set; }
        public string EmployerBusinessCity { get; set; }
        public string EmployerBusinessProvince { get; set; }
        public string EmployerBusinessCountry { get; set; }
        public string EmployerBusinessPostalCode { get; set; }

        public string EmployerMailingAddress1 { get; set; }
        public string EmployerMailingAddress2 { get; set; }
        public string EmployerMailingCity { get; set; }
        public string EmployerMailingProvince { get; set; }
        public string EmployerMailingCountry { get; set; }
        public string EmployerMailingPostalCode { get; set; }

        public string EmployerWebsite { get; set; }
        public string EmployerBusinessStartDate { get; set; }

        public bool EmployerIsSoleProprietorship { get; set; }
        public bool EmployerIsPartnership { get; set; }
        public bool EmployerIsCorporation { get; set; }
        public bool EmployerIsCoOperative { get; set; }
        public bool EmployerIsNonProfit { get; set; }
        public bool EmployerIsRegisteredCharity { get; set; }

        public int? EmployerNumberOfEmployees { get; set; }
        public decimal? EmployerAnnualGrossRevenue { get; set; }
        public YesNo? ReceiveSupportThroughProgram { get; set; }
        public string SupportDetails { get; set; }

        public string EmployerPrincipalJobTitle { get; set; }
        public string EmployerPrincipalFirstName { get; set; }
        public string EmployerPrincipalMiddleName { get; set; }
        public string EmployerPrincipalLastName { get; set; }
        public string EmployerPrincipalPhoneNumber { get; set; }
        public string EmployerPrincipalAlternatePhoneNumber { get; set; }
        public string EmployerPrincipalFaxNumber { get; set; }
        public string EmployerPrincipalEmail { get; set; }

        public Language? EmployerPrincipalOralLanguage { get; set; }
        public Language? EmployerPrincipalWrittenLanguage { get; set; }

        public string EmployerAlternateJobTitle { get; set; }
        public string EmployerAlternateFirstName { get; set; }
        public string EmployerAlternateMiddleName { get; set; }
        public string EmployerAlternateLastName { get; set; }
        public string EmployerAlternatePhoneNumber { get; set; }
        public string EmployerAlternateAlternatePhoneNumber { get; set; }
        public string EmployerAlternateFaxNumber { get; set; }
        public string EmployerAlternateEmail { get; set; }

        public Language? EmployerAlternateOralLanguage { get; set; }
        public Language? EmployerAlternateWrittenLanguage { get; set; }

        public YesNo? AppointingThirdParty { get; set; }

    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Language
    {
        English,
        French
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum YesNo
    {
        Yes,
        No
    }
}
