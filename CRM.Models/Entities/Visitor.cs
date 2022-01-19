using System;
using System.Collections.Generic;

namespace CRM.Models.Entities
{
    public partial class Visitor
    {
        public Visitor()
        {
            Leads = new HashSet<Leads>();
        }

        public long Id { get; set; }
        public long SiteId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string IpAddress { get; set; }
        public string Fingerprint { get; set; }
        public string GetBrowser { get; set; }
        public string GetBrowserVersion { get; set; }
        public string GetBrowserMajorVersion { get; set; }
        public bool IsIe { get; set; }
        public bool IsChrome { get; set; }
        public bool IsFirefox { get; set; }
        public bool IsSafari { get; set; }
        public bool IsOpera { get; set; }
        public string GetEngine { get; set; }
        public string GetEngineVersion { get; set; }
        public string GetOs { get; set; }
        public string GetOsversion { get; set; }
        public bool IsWindows { get; set; }
        public bool IsMac { get; set; }
        public bool IsLinux { get; set; }
        public bool IsUbuntu { get; set; }
        public bool IsSolaris { get; set; }
        public string GetCpu { get; set; }
        public bool IsMobile { get; set; }
        public bool IsMobileMajor { get; set; }
        public bool IsMobileAndroid { get; set; }
        public bool IsMobileOpera { get; set; }
        public bool IsMobileWindows { get; set; }
        public bool IsMobileIos { get; set; }
        public bool IsIphone { get; set; }
        public bool IsIpad { get; set; }
        public bool IsIpod { get; set; }
        public string GetScreenPrint { get; set; }
        public string GetColorDepth { get; set; }
        public string GetCurrentResolution { get; set; }
        public string GetAvailableResolution { get; set; }
        public string GetPlugins { get; set; }
        public bool IsJava { get; set; }
        public string GetJavaVersion { get; set; }
        public bool IsFlash { get; set; }
        public string GetFlashVersion { get; set; }
        public bool IsSilverlight { get; set; }
        public string GetSilverlightVersion { get; set; }
        public string GetMimeTypes { get; set; }
        public bool IsMimeTypes { get; set; }
        public bool IsFont { get; set; }
        public bool IsLocalStorage { get; set; }
        public bool IsSessionStorage { get; set; }
        public bool IsCookie { get; set; }
        public string RefferUrl { get; set; }
        public string GetTimeZone { get; set; }
        public string GetLanguage { get; set; }
        public bool IsCanvas { get; set; }
        public string GetCanvasPrint { get; set; }

        public virtual ICollection<Leads> Leads { get; set; }
    }
}
