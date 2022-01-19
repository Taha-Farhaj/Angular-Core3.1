using System;
using System.Collections.Generic;

namespace CRM.Models.Entities
{
    public partial class CustomerProductInfo
    {
        public CustomerProductInfo()
        {
            Estimation = new HashSet<Estimation>();
            InternalJob = new HashSet<InternalJob>();
        }

        public long Id { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? ProductId { get; set; }
        public string CustomProductName { get; set; }
        public string AnyOtherDetail { get; set; }
        public string CsrComments { get; set; }
        public string SpecSheetComments { get; set; }
        public string AdditionalComments { get; set; }
        public int? Quantity { get; set; }
        public string ProductProperties { get; set; }
        public long? LeadId { get; set; }
        public string Size { get; set; }
        public string Stock { get; set; }
        public string Lamination { get; set; }
        public string Color { get; set; }
        public string Pockets { get; set; }
        public string VerticalPocket { get; set; }
        public string PocketSize { get; set; }
        public string BusinessCardSlit { get; set; }
        public string Cdslit { get; set; }
        public string FoldingType { get; set; }
        public string PrintType { get; set; }
        public string PrintingOnPeelOfSide { get; set; }
        public string RaisedLink { get; set; }
        public string ProductionSpeed { get; set; }
        public string CustomProductionSpeed { get; set; }
        public string Perforation { get; set; }
        public string SerialNumStart { get; set; }
        public string SerialNumEnd { get; set; }
        public string SerialNumColor { get; set; }
        public string Binding { get; set; }
        public string BindingNumOfBooks { get; set; }
        public string BindingNumOfFormsperBook { get; set; }
        public string BindingSide { get; set; }
        public string CuttingType { get; set; }
        public string AdhesiveStaticSide { get; set; }
        public string ProductSizeFolded { get; set; }
        public string Finishing { get; set; }
        public string Grommets { get; set; }
        public string NumOfGrommets { get; set; }
        public string Hemming { get; set; }
        public string Tassel { get; set; }
        public string Embossing { get; set; }
        public string Foiling { get; set; }
        public string FoilingColor { get; set; }
        public string Uvcoating { get; set; }
        public string Panels { get; set; }
        public string Parts { get; set; }
        public string Pasting { get; set; }
        public string SelfAdhesiveTape { get; set; }
        public string DieCutHoleSize { get; set; }
        public string Window { get; set; }
        public string WindowSize { get; set; }
        public string PlasticSheetOnWindow { get; set; }
        public string DieCutWindow { get; set; }
        public string OpenSizeHeight { get; set; }
        public string OpenSizeWidth { get; set; }
        public string OpenSizeLength { get; set; }
        public string FinishedSizeHeight { get; set; }
        public string FinishedSizeWidth { get; set; }
        public string FinishedSizeLength { get; set; }
        public string FinishedSizeUnit { get; set; }
        public string TasselColor { get; set; }
        public int? NoOfPages { get; set; }
        public string WrapAroundCover { get; set; }
        public string TagString { get; set; }
        public string TagStringType { get; set; }
        public string TagStringSize { get; set; }
        public string PunchHoleSize { get; set; }
        public string PlasticSheetRequired { get; set; }
        public string CorrugationSheetColor { get; set; }
        public string Coating { get; set; }
        public string OtherColor { get; set; }
        public string PunchHoleSizeValue { get; set; }
        public string Inserts { get; set; }
        public string InsertCardGsm { get; set; }
        public string InsertFoam { get; set; }
        public string InsertFoamColor { get; set; }
        public string InsertCorrugation { get; set; }
        public string IsNoOfPages { get; set; }
        public string IsPockets { get; set; }
        public string IsRaisedLink { get; set; }
        public string IsCdSlit { get; set; }
        public string IsBusinessCardSlit { get; set; }
        public string IsAdhesive { get; set; }
        public string IsInsert { get; set; }
        public string IsCorrugation { get; set; }
        public string CuttingTypeNote { get; set; }

        public virtual Employee CreatedByNavigation { get; set; }
        public virtual Leads Lead { get; set; }
        public virtual Employee ModifiedByNavigation { get; set; }
        public virtual ICollection<Estimation> Estimation { get; set; }
        public virtual ICollection<InternalJob> InternalJob { get; set; }
    }
}
