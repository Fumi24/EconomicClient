using System;
using System.Collections.Generic;

namespace Fumi24.EconomicClient.ReadModels
{
    public class SelfReadModel
    {
        public long AgreementNumber { get; set; }
        public AgreementType AgreementType { get; set; }
        public string UserName { get; set; }
        public DateTimeOffset SignupDate { get; set; }
        public User User { get; set; }
        public Company Company { get; set; }
        public BankInformation BankInformation { get; set; }
        public Application Application { get; set; }
        public Settings Settings { get; set; }
        public string CompanyAffiliation { get; set; }
        public bool CanSendElectronicInvoice { get; set; }
        public List<Module> Modules { get; set; }
        public Uri Self { get; set; }
    }

    public class AgreementType
    {
        public long AgreementTypeNumber { get; set; }
        public string Name { get; set; }
    }

    public class Application
    {
        public long AppNumber { get; set; }
        public string Name { get; set; }
        public string AppPublicToken { get; set; }
        public DateTimeOffset Created { get; set; }
        public List<RequiredRole> RequiredRoles { get; set; }
        public Uri Self { get; set; }
    }

    public class RequiredRole
    {
        public long RoleNumber { get; set; }
        public string Name { get; set; }
        public List<RequiredModule> RequiredModules { get; set; }
    }

    public class RequiredModule
    {
        public long ModuleNumber { get; set; }
        public Uri Self { get; set; }
    }

    public class BankInformation
    {
        public long PbsCustomerGroupNumber { get; set; }
    }

    public class Company
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }

    public class Module
    {
        public long ModuleNumber { get; set; }
        public string Name { get; set; }
        public Uri Self { get; set; }
    }

    public class Settings
    {
        public string BaseCurrency { get; set; }
    }

    public class User
    {
        public string LoginId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public Language Language { get; set; }
        public long AgreementNumber { get; set; }
    }

    public class Language
    {
        public long LanguageNumber { get; set; }
        public string Name { get; set; }
        public string Culture { get; set; }
        public Uri Self { get; set; }
    }

}