using _10_BridgePattern;

var kniha = new Kniha();
kniha.Nazev = "Ostrov";
kniha.Nakladatelstvi = "Host";
kniha.Autor = "Bianca Bellová";
kniha.Uryvek = "Pil rum a pomalu si uvědomoval, že dochází. ";

var smallView = new SmallViewKniha(kniha);
smallView.Write();