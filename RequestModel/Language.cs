using System.ComponentModel;

namespace CS2DarkSky
{
    /// <summary>
    /// Return summary properties in the desired language. 
    /// If you require a language not listed here, please consider contributing to https://github.com/darkskyapp/forecast-io-translations
    /// </summary>
    public enum Language
    {
        ///<summary>Arabic language</summary>
        [Description("ar")]
        Arabic,
        ///<summary>Azerbaijani language</summary>
        [Description("az")]
        Azerbaijani,
        ///<summary>Belarusian language</summary>
        [Description("be")]
        Belarusian,
        ///<summary>Bosnian language</summary>
        [Description("bs")]
        Bosnian,
        ///<summary>Czech language</summary>
        [Description("cs")]
        Czech,
        ///<summary>German language</summary>
        [Description("de")]
        German,
        ///<summary>Greek language</summary>
        [Description("el")]
        Greek,
        ///<summary>English (which is the default) language</summary>
        [Description("en")]
        English,
        ///<summary>Spanish language</summary>
        [Description("es")]
        Spanish,
        ///<summary>French language</summary>
        [Description("fr")]
        French,
        ///<summary>Croatian language</summary>
        [Description("hr")]
        Croatian,
        ///<summary>Hungarian language</summary>
        [Description("hu")]
        Hungarian,
        ///<summary>Indonesian language</summary>
        [Description("id")]
        Indonesian,
        ///<summary>Italian language</summary>
        [Description("it")]
        Italian,
        ///<summary>Icelandic language</summary>
        [Description("is")]
        Icelandic,
        ///<summary>Cornish language</summary>
        [Description("kw")]
        Cornish,
        ///<summary>Norwegian Bokmål language</summary>
        [Description("nb")]
        NorwegianBokmål,
        ///<summary>Dutch language</summary>
        [Description("nl")]
        Dutch,
        ///<summary>Polish language</summary>
        [Description("pl")]
        Polish,
        ///<summary>Portuguese language</summary>
        [Description("pt")]
        Portuguese,
        ///<summary>Russian language</summary>
        [Description("ru")]
        Russian,
        ///<summary>Slovak language</summary>
        [Description("sk")]
        Slovak,
        ///<summary>Serbian language</summary>
        [Description("sr")]
        Serbian,
        ///<summary>Swedish language</summary>
        [Description("sv")]
        Swedish,
        ///<summary>Tetum language</summary>
        [Description("tet")]
        Tetum,
        ///<summary>Turkish language</summary>
        [Description("tr")]
        Turkish,
        ///<summary>Ukrainian language</summary>
        [Description("uk")]
        Ukrainian,
        ///<summary>Igpay Atinlay language</summary>
        [Description("x-pig-latin")]
        IgpayAtinlay,
        ///<summary>Simplified Chinese language</summary>
        [Description("zh")]
        ChineseSimplified,
        ///<summary>Traditional Chinese language</summary>
        [Description("zh-tw")]
        ChineseTraditional,

    }
}
