global using System;

//namespace - przestrzeń nazw, czyli adres pod którym "mieszka" klasa
//namespace zaciągamy używając "using"
namespace ConsoleApp.Models
{
    //public - modyfikator dostępu - oznacza, że z klasy można korzystać wszędzie
    //internal - modyfikator dostępu - oznacza, że z klasy można korzystać w obrębie projektu
    //class - szablon opisujący zachowania i cechy obiektów (instancji klas), które są wytwarzane na jej podstawie
    //pełna nazwa klasy to <namespace>+<nazwa>
    internal class Product
    {
        //metoda konstrukcyjna  (konstruktor) - bezparametrowy
        //brak określenia typu zwracanego i nazwa taka sama jak nazwa klasy
        //jeśli klasa nie ma żadnego zdefiniowanego konstruktora, to konstruktor bezparametrowy jest generowany automatycznie
        //metody konstrukcyjne są potrzebne, aby wstępnie skonfugorować produkt
        public Product()
        {
            ExpirationDate = DateTime.Now;
        }
        //przeciążenie metody konstrukcyjnej = wiele metod o tej samej nazwie, ale przyjmujące inne parametry
        public Product(string name) : this()
        {
            SetName(name);
        }
        //konstruktor parametrowy - służy do zapewnienia klasie wartości początkowych przekazanych jako parametry
        //jeśli w klasie występuje jakiś konstuktor parametrowy, to konstuktor bezparametrowy nie zostanie automatycznie wygenerowany
        //chcąc posiadać jednocześnie konstruktor parametrowy i bezparametrowy musimy go jawnie utworzyć
        //: this(..) - odwołanie się do innego konstruktora. W ten sposób tworzy się konstruktory teleskopowe (rozszeżają swoje możliwości niwelując powtarzający się kod)
        public Product(string name, int price) : this(name)
        {
            Price = price;
        }


        //pole klasy (field)
        //private - oznacza dostęp tylko dla elementów danej klasy
        //brak modyfikatora dostępu == private
        //pola zazwyczaj są prywatne ze względu na hermetyzację, a dostęp realizowany jest przez metody dostępowe (getter i setter)
        private string _name;

        //setter - do ustawiania wartości - metoda przyjmuje parametr, który zostaje wpisany w odpowiednie pole (można dodać kod "obróbki danych")
        //void metoda nic nie zwaraca
        public void SetName(string value)
        {
            _name = value.ToUpper();
        }

        //getter dobrania wartości pola - metoda zwraca typ zgodny z typem pola
        public string GetName()
        {
            //instukcja zwracająca wynik działania metody - obowiązkowy gdy zadeklarowaliśmy, że klasa coś zwraca (jest inna niż void)
            return _name;
        }


        //Property - właściwość

        //auto-property
        //właściwość integruje w sobie pole i metody dostępowe (getter i setter)
        //jest możliwość zmiany modyfikatora dostępu dla getter lub setter (osobno)
        public float Price { get; /*private*/ set; }

        //backfield do full-property - pozwala na dodatkowy kod w setterze i getterze
        private DateTime _expirationDate;
        //full-property
        public DateTime ExpirationDate
        {            
            //getter dla property
            get
            {
                return _expirationDate;
            }
            //setter dla property - posiada niejawny parametr o nazwie value
            set
            {
                if (value < DateTime.Now)
                {
                    _expirationDate = DateTime.Now;
                }
                else
                {
                    _expirationDate = value;
                }
            }
        }



        public string CreateDescription()
        {
            //łączenie stringów za pomocą operatora +
            string description = GetName() + " (" + ExpirationDate + "): " + Price + "zł";

            string format = "{0} ({1}): {2}zł"; //wartości w nawiasach oznaczają indeks parametru, który ma być wstawiony w to miejsce
            //łączenie stringów za pomocą funkcji Format
            description = string.Format(format, GetName(), ExpirationDate, Price);

            //łączenie stringów wykorzystując interpolację (string interpolowany)
            description = $"{GetName()} ({ExpirationDate}): {Price}zł";

            return description;
        }
    }
}
