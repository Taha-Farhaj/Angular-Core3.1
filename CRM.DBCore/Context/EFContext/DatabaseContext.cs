using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CRM.Models.Entities;
using CRM.Models;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.DBCore.Context.EFContext
{
    public partial class DatabaseContext : IdentityDbContext<ApplicationUser>, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }



        #region Table Models
        //public DbSet<TestTable> TestTables { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<CatalogsSubmitted> CatalogsSubmitted { get; set; }
        public virtual DbSet<Companies> Companies { get; set; }
        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<CourierPhoneNos> CourierPhoneNos { get; set; }
        public virtual DbSet<CustomerProductInfo> CustomerProductInfo { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Eforms> Eforms { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeRoles> EmployeeRoles { get; set; }
        public virtual DbSet<EmplyeeAppAccess> EmplyeeAppAccess { get; set; }
        public virtual DbSet<EstShippingRates> EstShippingRates { get; set; }
        public virtual DbSet<Estimation> Estimation { get; set; }
        public virtual DbSet<FbvideoLinks> FbvideoLinks { get; set; }
        public virtual DbSet<InternalJob> InternalJob { get; set; }
        public virtual DbSet<InternalJobStatus> InternalJobStatus { get; set; }
        public virtual DbSet<InternalJobStatusValues> InternalJobStatusValues { get; set; }
        public virtual DbSet<LeadProcess> LeadProcess { get; set; }
        public virtual DbSet<Leads> Leads { get; set; }
        public virtual DbSet<OrderTransactions> OrderTransactions { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<PromotionEmail> PromotionEmail { get; set; }
        public virtual DbSet<QuoteSent> QuoteSent { get; set; }
        public virtual DbSet<RefundOrder> RefundOrder { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Setting> Setting { get; set; }
        public virtual DbSet<Site> Site { get; set; }
        public virtual DbSet<SiteSettings> SiteSettings { get; set; }
        public virtual DbSet<SpecSheetAddress> SpecSheetAddress { get; set; }
        public virtual DbSet<TrackingIntimation> TrackingIntimation { get; set; }
        public virtual DbSet<Visitor> Visitor { get; set; }
        #endregion Table Models






        #region Sp Models
        //public DbSet<DriverListDto> driverList { get; set; }
        //public DbSet<PetDto> petList { get; set; }

        #endregion Sp Models

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.AddressLine2).HasMaxLength(300);

                entity.Property(e => e.Ccemail)
                    .HasColumnName("CCEmail")
                    .HasMaxLength(200);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CompanyName).HasMaxLength(100);

                entity.Property(e => e.Country).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PhoneNo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.AddressNavigation)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK_Address_Contacts");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.AddressCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_Address_Employee_Creator");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.AddressModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_Address_Employee_Modified");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_Address_Orders");
            });

            modelBuilder.Entity<CatalogsSubmitted>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CatalogType)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ClientEmail)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.SiteId).HasColumnName("SiteID");
            });

            modelBuilder.Entity<Companies>(entity =>
            {
                entity.Property(e => e.Fax).HasMaxLength(300);

                entity.HasOne(d => d.Site)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.SiteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Companies_Site");
            });

            modelBuilder.Entity<Contacts>(entity =>
            {
                entity.Property(e => e.Utmcampaign).HasColumnName("UTMCampaign");

                entity.Property(e => e.Utmcontent).HasColumnName("UTMContent");

                entity.Property(e => e.Utmmedium).HasColumnName("UTMMedium");

                entity.Property(e => e.Utmsource).HasColumnName("UTMSource");

                entity.Property(e => e.Utmterm).HasColumnName("UTMTerm");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_contacts_Companies");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ContactsCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_contacts_employee_create");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.ContactsModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_contacts_employee_modify");
            });

            modelBuilder.Entity<CourierPhoneNos>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CourierName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PhoneNo)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.CourierPhoneNosCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_CourierPhoneNos_Employee_Creator");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.CourierPhoneNosModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_CourierPhoneNos_Employee_Modified");

                entity.HasOne(d => d.Site)
                    .WithMany(p => p.CourierPhoneNos)
                    .HasForeignKey(d => d.SiteId)
                    .HasConstraintName("FK_CourierPhoneNos_Site");
            });

            modelBuilder.Entity<CustomerProductInfo>(entity =>
            {
                entity.Property(e => e.AdditionalComments).HasMaxLength(1000);

                entity.Property(e => e.AdhesiveStaticSide).HasMaxLength(300);

                entity.Property(e => e.Binding).HasMaxLength(300);

                entity.Property(e => e.BindingNumOfBooks).HasMaxLength(300);

                entity.Property(e => e.BindingNumOfFormsperBook).HasMaxLength(300);

                entity.Property(e => e.BindingSide).HasMaxLength(300);

                entity.Property(e => e.BusinessCardSlit).HasMaxLength(300);

                entity.Property(e => e.Cdslit)
                    .HasColumnName("CDSlit")
                    .HasMaxLength(300);

                entity.Property(e => e.Coating).HasMaxLength(200);

                entity.Property(e => e.Color).HasMaxLength(300);

                entity.Property(e => e.CorrugationSheetColor).HasMaxLength(50);

                entity.Property(e => e.CustomProductName).HasMaxLength(300);

                entity.Property(e => e.CustomProductionSpeed).HasMaxLength(300);

                entity.Property(e => e.CuttingType).HasMaxLength(300);

                entity.Property(e => e.CuttingTypeNote).HasMaxLength(300);

                entity.Property(e => e.DieCutHoleSize).HasMaxLength(300);

                entity.Property(e => e.DieCutWindow).HasMaxLength(300);

                entity.Property(e => e.Embossing).HasMaxLength(300);

                entity.Property(e => e.FinishedSizeHeight).HasMaxLength(300);

                entity.Property(e => e.FinishedSizeLength).HasMaxLength(300);

                entity.Property(e => e.FinishedSizeUnit).HasMaxLength(50);

                entity.Property(e => e.FinishedSizeWidth).HasMaxLength(300);

                entity.Property(e => e.Finishing).HasMaxLength(300);

                entity.Property(e => e.Foiling).HasMaxLength(300);

                entity.Property(e => e.FoilingColor).HasMaxLength(300);

                entity.Property(e => e.FoldingType).HasMaxLength(300);

                entity.Property(e => e.Grommets).HasMaxLength(300);

                entity.Property(e => e.Hemming).HasMaxLength(300);

                entity.Property(e => e.InsertCardGsm).HasMaxLength(300);

                entity.Property(e => e.InsertCorrugation).HasMaxLength(300);

                entity.Property(e => e.InsertFoam).HasMaxLength(300);

                entity.Property(e => e.InsertFoamColor).HasMaxLength(300);

                entity.Property(e => e.Inserts).HasMaxLength(300);

                entity.Property(e => e.IsAdhesive).HasMaxLength(300);

                entity.Property(e => e.IsBusinessCardSlit).HasMaxLength(300);

                entity.Property(e => e.IsCdSlit).HasMaxLength(300);

                entity.Property(e => e.IsCorrugation).HasMaxLength(300);

                entity.Property(e => e.IsInsert).HasMaxLength(300);

                entity.Property(e => e.IsNoOfPages).HasMaxLength(300);

                entity.Property(e => e.IsPockets).HasMaxLength(300);

                entity.Property(e => e.IsRaisedLink).HasMaxLength(300);

                entity.Property(e => e.Lamination).HasMaxLength(300);

                entity.Property(e => e.NumOfGrommets).HasMaxLength(300);

                entity.Property(e => e.OpenSizeHeight).HasMaxLength(300);

                entity.Property(e => e.OpenSizeLength).HasMaxLength(300);

                entity.Property(e => e.OpenSizeWidth).HasMaxLength(300);

                entity.Property(e => e.OtherColor).HasMaxLength(500);

                entity.Property(e => e.Panels).HasMaxLength(300);

                entity.Property(e => e.Parts).HasMaxLength(300);

                entity.Property(e => e.Pasting).HasMaxLength(300);

                entity.Property(e => e.Perforation).HasMaxLength(300);

                entity.Property(e => e.PlasticSheetOnWindow).HasMaxLength(300);

                entity.Property(e => e.PlasticSheetRequired).HasMaxLength(300);

                entity.Property(e => e.PocketSize).HasMaxLength(300);

                entity.Property(e => e.Pockets).HasMaxLength(300);

                entity.Property(e => e.PrintType).HasMaxLength(300);

                entity.Property(e => e.PrintingOnPeelOfSide).HasMaxLength(300);

                entity.Property(e => e.ProductSizeFolded).HasMaxLength(300);

                entity.Property(e => e.ProductionSpeed).HasMaxLength(300);

                entity.Property(e => e.PunchHoleSize).HasMaxLength(50);

                entity.Property(e => e.PunchHoleSizeValue).HasMaxLength(300);

                entity.Property(e => e.RaisedLink).HasMaxLength(300);

                entity.Property(e => e.SelfAdhesiveTape).HasMaxLength(300);

                entity.Property(e => e.SerialNumColor).HasMaxLength(300);

                entity.Property(e => e.SerialNumEnd).HasMaxLength(300);

                entity.Property(e => e.SerialNumStart).HasMaxLength(300);

                entity.Property(e => e.Size).HasMaxLength(300);

                entity.Property(e => e.SpecSheetComments).HasMaxLength(1000);

                entity.Property(e => e.Stock).HasMaxLength(300);

                entity.Property(e => e.TagString).HasMaxLength(50);

                entity.Property(e => e.TagStringSize).HasMaxLength(300);

                entity.Property(e => e.TagStringType).HasMaxLength(300);

                entity.Property(e => e.Tassel).HasMaxLength(300);

                entity.Property(e => e.TasselColor).HasMaxLength(50);

                entity.Property(e => e.Uvcoating)
                    .HasColumnName("UVCoating")
                    .HasMaxLength(300);

                entity.Property(e => e.VerticalPocket).HasMaxLength(300);

                entity.Property(e => e.Window).HasMaxLength(300);

                entity.Property(e => e.WindowSize).HasMaxLength(300);

                entity.Property(e => e.WrapAroundCover).HasMaxLength(300);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.CustomerProductInfoCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_CustomerProductInfo_employee_create");

                entity.HasOne(d => d.Lead)
                    .WithMany(p => p.CustomerProductInfo)
                    .HasForeignKey(d => d.LeadId)
                    .HasConstraintName("FK_CustomerProductInfo_Leads");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.CustomerProductInfoModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_CustomerProductInfo_employee_update");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.Property(e => e.LastLoggedIn).HasColumnType("datetime");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK_Customers_contacts");

                entity.HasOne(d => d.Site)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.SiteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customers_Site");
            });

            modelBuilder.Entity<Eforms>(entity =>
            {
                entity.ToTable("EForms");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdvancePayment).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.AdvancePaymentDate).HasColumnType("datetime");

                entity.Property(e => e.EformNo)
                    .HasColumnName("EFormNO")
                    .HasMaxLength(300);

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.FileName).HasMaxLength(300);

                entity.Property(e => e.IssuanceDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Username).HasMaxLength(300);
            });

            modelBuilder.Entity<EmployeeRoles>(entity =>
            {
                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.EmployeeRolesCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_EmployeeRoles_Employee_Creator");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeRoles)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeRoles_Employee");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.EmployeeRolesModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_EmployeeRoles_Employee_Modified");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.EmployeeRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeRoles_EmployeeRoles");
            });

            modelBuilder.Entity<EmplyeeAppAccess>(entity =>
            {
                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.EmplyeeAppAccessCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_EmplyeeAppAccess_Employee1");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmplyeeAppAccess)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmplyeeAppAccess_Employee_Creator");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.EmplyeeAppAccessModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_EmplyeeAppAccess_Employee_Modified");

                entity.HasOne(d => d.Site)
                    .WithMany(p => p.EmplyeeAppAccess)
                    .HasForeignKey(d => d.SiteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmplyeeAppAccess_Site");
            });

            modelBuilder.Entity<EstShippingRates>(entity =>
            {
                entity.Property(e => e.PriceForCsr)
                    .HasColumnName("PriceForCSR")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PriceForRpt).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Weight).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.EstShippingRatesCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_EstShippingRates_Employee_Creator");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.EstShippingRatesModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_EstShippingRates_Employee_Modified");

                entity.HasOne(d => d.Site)
                    .WithMany(p => p.EstShippingRates)
                    .HasForeignKey(d => d.SiteId)
                    .HasConstraintName("FK_EstShippingRates_Site");
            });

            modelBuilder.Entity<Estimation>(entity =>
            {
                entity.Property(e => e.CostTotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Profit).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ShippingCost).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.VendorProfit).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Weight).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.EstimationCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_Estimation_CustomerProductInfo_Creator");

                entity.HasOne(d => d.CustomerProductInfo)
                    .WithMany(p => p.Estimation)
                    .HasForeignKey(d => d.CustomerProductInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Estimation_CustomerProductInfo");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.EstimationModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_Estimation_employee_modified");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Estimation)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_Estimation_Orders");

                entity.HasOne(d => d.Quote)
                    .WithMany(p => p.Estimation)
                    .HasForeignKey(d => d.QuoteId)
                    .HasConstraintName("FK_Estimation_QuoteSent");

                entity.HasOne(d => d.Site)
                    .WithMany(p => p.Estimation)
                    .HasForeignKey(d => d.SiteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Estimation_Site");
            });

            modelBuilder.Entity<FbvideoLinks>(entity =>
            {
                entity.ToTable("FBVideoLinks");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.VideoImageLink)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.VideoLink)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.VideoLinkName)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.VideoimageName)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.FbvideoLinksCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_FBVideoLinks_Employee_Creator");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.FbvideoLinksModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_FBVideoLinks_Employee_Modified");
            });

            modelBuilder.Entity<InternalJob>(entity =>
            {
                entity.Property(e => e.ApprovalDate).HasColumnType("datetime");

                entity.Property(e => e.PartialQty).HasMaxLength(50);

                entity.Property(e => e.PressFwdDate).HasColumnType("datetime");

                entity.Property(e => e.PrintingMachine).HasMaxLength(50);

                entity.Property(e => e.ProductionCompleteDate).HasColumnType("datetime");

                entity.Property(e => e.Ptd)
                    .HasColumnName("PTD")
                    .HasColumnType("datetime");

                entity.Property(e => e.ShipppingCompleteDate).HasColumnType("datetime");

                entity.Property(e => e.ShipppingStartDate).HasColumnType("datetime");

                entity.Property(e => e.TargetDeliveryDate).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.InternalJobCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_InternalJob_Employee_Creator");

                entity.HasOne(d => d.CustomerProductInfo)
                    .WithMany(p => p.InternalJob)
                    .HasForeignKey(d => d.CustomerProductInfoId)
                    .HasConstraintName("FK_InternalJob_CustomerProductInfo");

                entity.HasOne(d => d.InternalJobStatusNavigation)
                    .WithMany(p => p.InternalJobInternalJobStatusNavigation)
                    .HasForeignKey(d => d.InternalJobStatus);

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.InternalJobModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_InternalJob_Employee_Modified");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.InternalJob)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_InternalJob_InternalJobStatus");

                entity.HasOne(d => d.StatusProcess)
                    .WithMany(p => p.InternalJobStatusProcess)
                    .HasForeignKey(d => d.StatusProcessId)
                    .HasConstraintName("FK_InternalJob_InternalJobStatusValues");
            });

            modelBuilder.Entity<InternalJobStatus>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<InternalJobStatusValues>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.InternalJobStatus)
                    .WithMany(p => p.InternalJobStatusValues)
                    .HasForeignKey(d => d.InternalJobStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InternalJobStatusValues_InternalJobStatus");
            });

            modelBuilder.Entity<LeadProcess>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Comments).IsRequired();

                entity.Property(e => e.LinkId).ValueGeneratedOnAdd();

                entity.Property(e => e.Status).HasMaxLength(300);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.LeadProcessCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_LeadProcess_Employee_Creator");

                entity.HasOne(d => d.Lead)
                    .WithMany(p => p.LeadProcess)
                    .HasForeignKey(d => d.LeadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LeadProcess_Leads");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.LeadProcessModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_LeadProcess_Employee_Updator");
            });

            modelBuilder.Entity<Leads>(entity =>
            {
                entity.Property(e => e.DiscountPercentage).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PartialPaymentPercentage).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Leads)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_Leads_companies");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.LeadsCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_Leads_employee_Created");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Leads)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Leads_Customer");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.LeadsModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_Leads_employee_modified");

                entity.HasOne(d => d.Site)
                    .WithMany(p => p.Leads)
                    .HasForeignKey(d => d.SiteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Leads_Site");

                entity.HasOne(d => d.Visitor)
                    .WithMany(p => p.Leads)
                    .HasForeignKey(d => d.VisitorId)
                    .HasConstraintName("FK_Leads_Visitor");
            });

            modelBuilder.Entity<OrderTransactions>(entity =>
            {
                entity.Property(e => e.AdditionalNotes).HasMaxLength(1000);

                entity.Property(e => e.ConversionRate).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreditCardType).HasMaxLength(50);

                entity.Property(e => e.FollowUpDate).HasColumnType("datetime");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.PaidAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PaymentMethod)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ProcessorData).HasMaxLength(1000);

                entity.Property(e => e.RefundAmount).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.OrderTransactionsCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_OrderAccounts_employee_Created");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.OrderTransactionsModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_OrderAccounts_employee_Modified");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderTransactions)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderAccounts_Orders");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FollowUpDate).HasColumnType("datetime");

                entity.HasOne(d => d.Lead)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.LeadId)
                    .HasConstraintName("FK_Orders_Leads");
            });

            modelBuilder.Entity<PromotionEmail>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.TimeFrame)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.PromotionEmail)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PromotionEmail_Contacts");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.PromotionEmailCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_PromotionEmail_Employee_Creator");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.PromotionEmailModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_PromotionEmail_Employee_Modified");
            });

            modelBuilder.Entity<QuoteSent>(entity =>
            {
                entity.Property(e => e.Comments).HasMaxLength(50);

                entity.Property(e => e.PaymentTerms).HasMaxLength(500);

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.QuoteSentCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_QuoteSent_employee_Creator");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.QuoteSentModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_QuoteSent_employee_Modified");
            });

            modelBuilder.Entity<RefundOrder>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.RefundAmount).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.RefundOrderCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_RefundOrder_Employee_Creator");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.RefundOrder)
                    .HasForeignKey<RefundOrder>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RefundOrder_Orders");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.RefundOrderModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_RefundOrder_Employee_Updator");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleName).HasMaxLength(300);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.RoleCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_Role_Employee_Creator");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.RoleModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_Role_Employee_Modified");
            });

            modelBuilder.Entity<Setting>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.SettingCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_Setting_Employee_Creator");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.SettingModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_Setting_Employee_Updator");
            });

            modelBuilder.Entity<Site>(entity =>
            {
                entity.Property(e => e.CultureId).HasColumnName("CultureID");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.SiteName).HasMaxLength(200);

                entity.Property(e => e.SitePath).HasMaxLength(200);
            });

            modelBuilder.Entity<SiteSettings>(entity =>
            {
                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.SiteSettingsCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_SiteSettings_Employee_Creator");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.SiteSettingsModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_SiteSettings_Employee_Updator");

                entity.HasOne(d => d.Setting)
                    .WithMany(p => p.SiteSettings)
                    .HasForeignKey(d => d.SettingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SiteSettings_Setting");

                entity.HasOne(d => d.Site)
                    .WithMany(p => p.SiteSettings)
                    .HasForeignKey(d => d.SiteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SiteSettings_SiteSettings");
            });

            modelBuilder.Entity<SpecSheetAddress>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(300);

                entity.Property(e => e.Ccemail)
                    .HasColumnName("CCEmail")
                    .HasMaxLength(300);

                entity.Property(e => e.City).HasMaxLength(300);

                entity.Property(e => e.CompanyName).HasMaxLength(300);

                entity.Property(e => e.Country).HasMaxLength(300);

                entity.Property(e => e.Email).HasMaxLength(300);

                entity.Property(e => e.FirstName).HasMaxLength(300);

                entity.Property(e => e.LastName).HasMaxLength(300);

                entity.Property(e => e.PhoneNumber).HasMaxLength(300);

                entity.Property(e => e.State).HasMaxLength(300);

                entity.Property(e => e.ZipCode).HasMaxLength(300);

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.SpecSheetAddress)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK_SpecSheetAddress_Contacts");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.SpecSheetAddressCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_SpecSheetAddress_Creator");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.SpecSheetAddressModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_SpecSheetAddress_Modified");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.SpecSheetAddress)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_SpecSheetAddress_Orders");
            });

            modelBuilder.Entity<TrackingIntimation>(entity =>
            {
                entity.Property(e => e.CourierInfo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IntimationType).HasMaxLength(300);

                entity.Property(e => e.Mode).HasMaxLength(300);

                entity.Property(e => e.NoOfCartons).HasMaxLength(300);

                entity.Property(e => e.PieceNo).HasMaxLength(300);

                entity.Property(e => e.Schedule).HasMaxLength(300);

                entity.Property(e => e.TrackingNo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Week).HasMaxLength(300);
            });

            modelBuilder.Entity<Visitor>(entity =>
            {
                entity.Property(e => e.GetAvailableResolution).HasColumnName("getAvailableResolution");

                entity.Property(e => e.GetBrowser).HasColumnName("getBrowser");

                entity.Property(e => e.GetBrowserMajorVersion).HasColumnName("getBrowserMajorVersion");

                entity.Property(e => e.GetBrowserVersion).HasColumnName("getBrowserVersion");

                entity.Property(e => e.GetCanvasPrint).HasColumnName("getCanvasPrint");

                entity.Property(e => e.GetColorDepth).HasColumnName("getColorDepth");

                entity.Property(e => e.GetCpu).HasColumnName("getCPU");

                entity.Property(e => e.GetCurrentResolution).HasColumnName("getCurrentResolution");

                entity.Property(e => e.GetEngine).HasColumnName("getEngine");

                entity.Property(e => e.GetEngineVersion).HasColumnName("getEngineVersion");

                entity.Property(e => e.GetFlashVersion).HasColumnName("getFlashVersion");

                entity.Property(e => e.GetJavaVersion).HasColumnName("getJavaVersion");

                entity.Property(e => e.GetLanguage).HasColumnName("getLanguage");

                entity.Property(e => e.GetMimeTypes).HasColumnName("getMimeTypes");

                entity.Property(e => e.GetOs).HasColumnName("getOS");

                entity.Property(e => e.GetOsversion).HasColumnName("getOSVersion");

                entity.Property(e => e.GetPlugins).HasColumnName("getPlugins");

                entity.Property(e => e.GetScreenPrint).HasColumnName("getScreenPrint");

                entity.Property(e => e.GetSilverlightVersion).HasColumnName("getSilverlightVersion");

                entity.Property(e => e.GetTimeZone).HasColumnName("getTimeZone");

                entity.Property(e => e.IsCanvas).HasColumnName("isCanvas");

                entity.Property(e => e.IsChrome).HasColumnName("isChrome");

                entity.Property(e => e.IsCookie).HasColumnName("isCookie");

                entity.Property(e => e.IsFirefox).HasColumnName("isFirefox");

                entity.Property(e => e.IsFlash).HasColumnName("isFlash");

                entity.Property(e => e.IsFont).HasColumnName("isFont");

                entity.Property(e => e.IsIe).HasColumnName("isIE");

                entity.Property(e => e.IsIpad).HasColumnName("isIpad");

                entity.Property(e => e.IsIphone).HasColumnName("isIphone");

                entity.Property(e => e.IsIpod).HasColumnName("isIpod");

                entity.Property(e => e.IsJava).HasColumnName("isJava");

                entity.Property(e => e.IsLinux).HasColumnName("isLinux");

                entity.Property(e => e.IsLocalStorage).HasColumnName("isLocalStorage");

                entity.Property(e => e.IsMac).HasColumnName("isMac");

                entity.Property(e => e.IsMimeTypes).HasColumnName("isMimeTypes");

                entity.Property(e => e.IsMobile).HasColumnName("isMobile");

                entity.Property(e => e.IsMobileAndroid).HasColumnName("isMobileAndroid");

                entity.Property(e => e.IsMobileIos).HasColumnName("isMobileIOS");

                entity.Property(e => e.IsMobileMajor).HasColumnName("isMobileMajor");

                entity.Property(e => e.IsMobileOpera).HasColumnName("isMobileOpera");

                entity.Property(e => e.IsMobileWindows).HasColumnName("isMobileWindows");

                entity.Property(e => e.IsOpera).HasColumnName("isOpera");

                entity.Property(e => e.IsSafari).HasColumnName("isSafari");

                entity.Property(e => e.IsSessionStorage).HasColumnName("isSessionStorage");

                entity.Property(e => e.IsSilverlight).HasColumnName("isSilverlight");

                entity.Property(e => e.IsSolaris).HasColumnName("isSolaris");

                entity.Property(e => e.IsUbuntu).HasColumnName("isUbuntu");

                entity.Property(e => e.IsWindows).HasColumnName("isWindows");
            });


            base.OnModelCreating(modelBuilder);
        }
    }
}
