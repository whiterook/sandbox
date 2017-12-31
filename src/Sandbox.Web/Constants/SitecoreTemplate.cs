using Sitecore.Data;

namespace Sandbox.Web.Constants
{
    public static class SitecoreTemplate
    {
        public static string MetaTitle => "MetaTitle";
        public static string MetaDescription => "MetaDescription";
        public static string ContentHeading => "ContentHeading";
        public static string StartDate => "Start Date";
        public static string Duration => "Duration";
        public static string ContentBody => "ContentBody";
        public static string EventImage => "Evant Image";
        public static string Highlights => "Highlights";

        public static ID EventSectionTemplateId => ID.Parse("{D8F6BCF4 -0357-4D22-A2D3-6B1CFC1E843E}");
    }
}