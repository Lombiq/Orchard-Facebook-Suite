using System.ComponentModel.DataAnnotations;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;
using Orchard.Environment.Extensions;

namespace Piedone.Facebook.Suite.Models
{
    [OrchardFeature("Piedone.Facebook.Suite")]
    public class FacebookSuiteSettingsPartRecord : ContentPartRecord
    {
        public virtual string AppId { get; set; }
        public virtual string AppSecret { get; set; }
        public virtual string CancelUrlPath { get; set; }
        public virtual string CanvasPage { get; set; }
        public virtual string CanvasUrl { get; set; }
        public virtual string SecureCanvasUrl { get; set; }
        public virtual string SiteUrl { get; set; }
        public virtual bool UseFacebookBeta { get; set; }
    }

    [OrchardFeature("Piedone.Facebook.Suite")]
    public class FacebookSuiteSettingsPart : ContentPart<FacebookSuiteSettingsPartRecord>
    {
        [Required]
        public string AppId
        {
            get { return Record.AppId; }
            set { Record.AppId = value; }
        }

        [Required]
        public string AppSecret
        {
            get { return Record.AppSecret; }
            set { Record.AppSecret = value; }
        }

        public string CancelUrlPath
        {
            get { return Record.CancelUrlPath; }
            set { Record.CancelUrlPath = value; }
        }

        public string CanvasPage
        {
            get { return Record.CanvasPage; }
            set { Record.CanvasPage = value; }
        }

        public string CanvasUrl
        {
            get { return Record.CanvasUrl; }
            set { Record.CanvasUrl = value; }
        }

        public string SecureCanvasUrl
        {
            get { return Record.SecureCanvasUrl; }
            set { Record.SecureCanvasUrl = value; }
        }

        public string SiteUrl
        {
            get { return Record.SiteUrl; }
            set { Record.SiteUrl = value; }
        }

        public bool UseFacebookBeta
        {
            get { return Record.UseFacebookBeta; }
            set { Record.UseFacebookBeta = value; }
        }
    }

    //public class FacebookAppSettings : IFacebookApplication
    //{
    //    public string AppId
    //    {
    //        get;
    //        set;
    //    }

    //    public string AppSecret
    //    {
    //        get;
    //        set;
    //    }

    //    public string CancelUrlPath
    //    {
    //        get;
    //        set;
    //    }

    //    public string CanvasPage
    //    {
    //        get;
    //        set;
    //    }

    //    public string CanvasUrl
    //    {
    //        get;
    //        set;
    //    }

    //    public string SecureCanvasUrl
    //    {
    //        get;
    //        set;
    //    }

    //    public string SiteUrl
    //    {
    //        get;
    //        set;
    //    }

    //    public bool UseFacebookBeta
    //    {
    //        get;
    //        set;
    //    }
    //}

    //public class FacebookAppSettings : IFacebookApplication
    //{
    //    private string appId;
    //    public string AppId
    //    {
    //        get { return appId; }
    //        set { appId = value; }
    //    }

    //    private string appSecret;
    //    public string AppSecret
    //    {
    //        get { return appSecret; }
    //    }

    //    private string cancelUrlPath;
    //    public string CancelUrlPath
    //    {
    //        get { return cancelUrlPath; }
    //    }

    //    private string canvasPage;
    //    public string CanvasPage
    //    {
    //        get { return canvasPage; }
    //    }

    //    private string canvasUrl;
    //    public string CanvasUrl
    //    {
    //        get { return canvasUrl; }
    //    }

    //    private string secureCanvasUrl;
    //    public string SecureCanvasUrl
    //    {
    //        get { return secureCanvasUrl; }
    //    }

    //    private string siteUrl;
    //    public string SiteUrl
    //    {
    //        get { return siteUrl; }
    //    }

    //    private bool useFacebookBeta;
    //    public bool UseFacebookBeta
    //    {
    //        get { return useFacebookBeta; }
    //    }

    //    public FacebookAppSettings(
    //        string appId,
    //        string appSecret,
    //        string cancelUrlPath = "",
    //        string canvasPage = "",
    //        string canvasUrl = "",
    //        string secureCanvasUrl = "",
    //        string siteUrl = "",
    //        bool useFacebookBeta = false
    //        )
    //    {
    //        this.appId = appId;
    //        this.appSecret = appSecret;
    //        this.cancelUrlPath = cancelUrlPath;
    //        this.canvasPage = canvasPage;
    //        this.canvasUrl = canvasUrl;
    //        this.secureCanvasUrl = secureCanvasUrl;
    //        this.siteUrl = siteUrl;
    //        this.useFacebookBeta = useFacebookBeta;
    //    }
    //}
}