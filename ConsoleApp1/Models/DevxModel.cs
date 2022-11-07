namespace Localization.Models
{


    public class DevxRequestModel
    {
        public float version { get; set; }
        public string culture { get; set; }
        public int index { get; set; }
        public int count { get; set; }
        public string platform { get; set; }
        public string product { get; set; }
        public string translateByType { get; set; }
        public string searchString { get; set; }
        public bool showCalculatedFields { get; set; }
        public bool bingSettingChanged { get; set; }
        public object[] changedResources { get; set; }
    }



    public class DevxModel
    {
        public Item[] Items { get; set; }
        public int TotalCount { get; set; }
        public string Version { get; set; }
        public string Culture { get; set; }
        public bool UseBingTranslations { get; set; }
    }

    public class Item
    {
        public string EnglishTranslation { get; set; }
        public int TranslatedBy { get; set; }
        public Suggestedtranslation SuggestedTranslation { get; set; }
        public string Value { get; set; }
        public string Resource { get; set; }
        public string Name { get; set; }
        public string Product { get; set; }
        public int Platform { get; set; }
    }

    public class Suggestedtranslation
    {
        public string Value { get; set; }
        public int ProvideBy { get; set; }
    }

}
