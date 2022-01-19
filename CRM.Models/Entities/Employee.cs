using System;
using System.Collections.Generic;

namespace CRM.Models.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            AddressCreatedByNavigation = new HashSet<Address>();
            AddressModifiedByNavigation = new HashSet<Address>();
            ContactsCreatedByNavigation = new HashSet<Contacts>();
            ContactsModifiedByNavigation = new HashSet<Contacts>();
            CourierPhoneNosCreatedByNavigation = new HashSet<CourierPhoneNos>();
            CourierPhoneNosModifiedByNavigation = new HashSet<CourierPhoneNos>();
            CustomerProductInfoCreatedByNavigation = new HashSet<CustomerProductInfo>();
            CustomerProductInfoModifiedByNavigation = new HashSet<CustomerProductInfo>();
            EmployeeRolesCreatedByNavigation = new HashSet<EmployeeRoles>();
            EmployeeRoles = new HashSet<EmployeeRoles>();
            EmployeeRolesModifiedByNavigation = new HashSet<EmployeeRoles>();
            EmplyeeAppAccessCreatedByNavigation = new HashSet<EmplyeeAppAccess>();
            EmplyeeAppAccess = new HashSet<EmplyeeAppAccess>();
            EmplyeeAppAccessModifiedByNavigation = new HashSet<EmplyeeAppAccess>();
            EstShippingRatesCreatedByNavigation = new HashSet<EstShippingRates>();
            EstShippingRatesModifiedByNavigation = new HashSet<EstShippingRates>();
            EstimationCreatedByNavigation = new HashSet<Estimation>();
            EstimationModifiedByNavigation = new HashSet<Estimation>();
            FbvideoLinksCreatedByNavigation = new HashSet<FbvideoLinks>();
            FbvideoLinksModifiedByNavigation = new HashSet<FbvideoLinks>();
            InternalJobCreatedByNavigation = new HashSet<InternalJob>();
            InternalJobModifiedByNavigation = new HashSet<InternalJob>();
            LeadProcessCreatedByNavigation = new HashSet<LeadProcess>();
            LeadProcessModifiedByNavigation = new HashSet<LeadProcess>();
            LeadsCreatedByNavigation = new HashSet<Leads>();
            LeadsModifiedByNavigation = new HashSet<Leads>();
            OrderTransactionsCreatedByNavigation = new HashSet<OrderTransactions>();
            OrderTransactionsModifiedByNavigation = new HashSet<OrderTransactions>();
            PromotionEmailCreatedByNavigation = new HashSet<PromotionEmail>();
            PromotionEmailModifiedByNavigation = new HashSet<PromotionEmail>();
            QuoteSentCreatedByNavigation = new HashSet<QuoteSent>();
            QuoteSentModifiedByNavigation = new HashSet<QuoteSent>();
            RefundOrderCreatedByNavigation = new HashSet<RefundOrder>();
            RefundOrderModifiedByNavigation = new HashSet<RefundOrder>();
            RoleCreatedByNavigation = new HashSet<Role>();
            RoleModifiedByNavigation = new HashSet<Role>();
            SettingCreatedByNavigation = new HashSet<Setting>();
            SettingModifiedByNavigation = new HashSet<Setting>();
            SiteSettingsCreatedByNavigation = new HashSet<SiteSettings>();
            SiteSettingsModifiedByNavigation = new HashSet<SiteSettings>();
            SpecSheetAddressCreatedByNavigation = new HashSet<SpecSheetAddress>();
            SpecSheetAddressModifiedByNavigation = new HashSet<SpecSheetAddress>();
        }

        public long Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Photo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string MobilePhone { get; set; }
        public string City { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string ExtensionNumber { get; set; }
        public string District { get; set; }
        public DateTime? HiringDate { get; set; }
        public string SkypeName { get; set; }
        public string Signature { get; set; }
        public string SecondaryEmail { get; set; }

        public virtual ICollection<Address> AddressCreatedByNavigation { get; set; }
        public virtual ICollection<Address> AddressModifiedByNavigation { get; set; }
        public virtual ICollection<Contacts> ContactsCreatedByNavigation { get; set; }
        public virtual ICollection<Contacts> ContactsModifiedByNavigation { get; set; }
        public virtual ICollection<CourierPhoneNos> CourierPhoneNosCreatedByNavigation { get; set; }
        public virtual ICollection<CourierPhoneNos> CourierPhoneNosModifiedByNavigation { get; set; }
        public virtual ICollection<CustomerProductInfo> CustomerProductInfoCreatedByNavigation { get; set; }
        public virtual ICollection<CustomerProductInfo> CustomerProductInfoModifiedByNavigation { get; set; }
        public virtual ICollection<EmployeeRoles> EmployeeRolesCreatedByNavigation { get; set; }
        public virtual ICollection<EmployeeRoles> EmployeeRoles { get; set; }
        public virtual ICollection<EmployeeRoles> EmployeeRolesModifiedByNavigation { get; set; }
        public virtual ICollection<EmplyeeAppAccess> EmplyeeAppAccessCreatedByNavigation { get; set; }
        public virtual ICollection<EmplyeeAppAccess> EmplyeeAppAccess { get; set; }
        public virtual ICollection<EmplyeeAppAccess> EmplyeeAppAccessModifiedByNavigation { get; set; }
        public virtual ICollection<EstShippingRates> EstShippingRatesCreatedByNavigation { get; set; }
        public virtual ICollection<EstShippingRates> EstShippingRatesModifiedByNavigation { get; set; }
        public virtual ICollection<Estimation> EstimationCreatedByNavigation { get; set; }
        public virtual ICollection<Estimation> EstimationModifiedByNavigation { get; set; }
        public virtual ICollection<FbvideoLinks> FbvideoLinksCreatedByNavigation { get; set; }
        public virtual ICollection<FbvideoLinks> FbvideoLinksModifiedByNavigation { get; set; }
        public virtual ICollection<InternalJob> InternalJobCreatedByNavigation { get; set; }
        public virtual ICollection<InternalJob> InternalJobModifiedByNavigation { get; set; }
        public virtual ICollection<LeadProcess> LeadProcessCreatedByNavigation { get; set; }
        public virtual ICollection<LeadProcess> LeadProcessModifiedByNavigation { get; set; }
        public virtual ICollection<Leads> LeadsCreatedByNavigation { get; set; }
        public virtual ICollection<Leads> LeadsModifiedByNavigation { get; set; }
        public virtual ICollection<OrderTransactions> OrderTransactionsCreatedByNavigation { get; set; }
        public virtual ICollection<OrderTransactions> OrderTransactionsModifiedByNavigation { get; set; }
        public virtual ICollection<PromotionEmail> PromotionEmailCreatedByNavigation { get; set; }
        public virtual ICollection<PromotionEmail> PromotionEmailModifiedByNavigation { get; set; }
        public virtual ICollection<QuoteSent> QuoteSentCreatedByNavigation { get; set; }
        public virtual ICollection<QuoteSent> QuoteSentModifiedByNavigation { get; set; }
        public virtual ICollection<RefundOrder> RefundOrderCreatedByNavigation { get; set; }
        public virtual ICollection<RefundOrder> RefundOrderModifiedByNavigation { get; set; }
        public virtual ICollection<Role> RoleCreatedByNavigation { get; set; }
        public virtual ICollection<Role> RoleModifiedByNavigation { get; set; }
        public virtual ICollection<Setting> SettingCreatedByNavigation { get; set; }
        public virtual ICollection<Setting> SettingModifiedByNavigation { get; set; }
        public virtual ICollection<SiteSettings> SiteSettingsCreatedByNavigation { get; set; }
        public virtual ICollection<SiteSettings> SiteSettingsModifiedByNavigation { get; set; }
        public virtual ICollection<SpecSheetAddress> SpecSheetAddressCreatedByNavigation { get; set; }
        public virtual ICollection<SpecSheetAddress> SpecSheetAddressModifiedByNavigation { get; set; }
    }
}
