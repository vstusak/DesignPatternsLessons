namespace DesignPatterns
{
    public interface IDressStrategy
    {
        string GetCoat();
        string GetHeadcover();
        string GetTroussers();
        string GetShoes();
    }

    public class RainyDressStrategy : IDressStrategy
    {
        public string GetCoat() => "Rain coat";
        public string GetHeadcover() => "Rain hat";
        public string GetShoes()    => "Rain boots";
        public string GetTroussers() =>  "Swimsuit";
    }

    public class SunnyDressStrategy : IDressStrategy
    {
        public string GetCoat() => "Naked";
        public string GetHeadcover() => "Kshilt";
        public string GetShoes() => "Bare foot";
        public string GetTroussers() => "Shorts";
    }
}
