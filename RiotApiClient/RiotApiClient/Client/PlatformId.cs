namespace RiotApiClient
{
    public class PlatformId
    {
        public string Value { get; private set; }

        private PlatformId(string value)
        {
            Value = value;
        }
        
        public static PlatformId EuropeNordic => new PlatformId("eun1");
        public static PlatformId EuropeWest => new PlatformId("euw1");
        public static PlatformId Brazil => new PlatformId("br1");
        public static PlatformId LatinAmericaNorth => new PlatformId("la1");
        public static PlatformId LatinAmericaSouth => new PlatformId("la2");
        public static PlatformId NorthAmerica => new PlatformId("na1");
        public static PlatformId Oceania => new PlatformId("oc1");
        public static PlatformId Russia => new PlatformId("ru1");
        public static PlatformId Turkey => new PlatformId("tr1");
        public static PlatformId Japan => new PlatformId("jp1");
        public static PlatformId Korea => new PlatformId("kr");
    }
}