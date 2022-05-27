using System;

namespace addressbook
{
    class Program
    {
        static bool Sprawdzenie(out int liczba)
        {
            Console.WriteLine("Wprowadź wartość do sprawdzenia");
            string userInput = Console.ReadLine();
            if (Int32.TryParse(userInput, out int result))
            {
                Console.WriteLine($"Wprowadzona wartość {userInput} JEST prawidłową wartością.");
                liczba = result;
                if (result < 0)
                {
                    Console.WriteLine($"W dodatku jest liczbą ujemną : {liczba}");
                }
                    return true;
            }
            else
            {
                liczba = result;
                Console.WriteLine($"Wprowadzona wartość {userInput} NIE jest prawidłową wartością.");
                return false;
            }


        }
        static void Main(string[] args)
        {
            Console.WriteLine("Witaj w applikacji książka adresowa");

            

            var ksiazkaAdresowa = new KsiazkaAdresowa();

            while (true) {
                Console.WriteLine("1. Dodaj kontakt");
                Console.WriteLine("2. Wyświetl kontakt po numerze");
                Console.WriteLine("3. Wyświetl wszystkie kontakty");
                Console.WriteLine("4. Wyszukaj kontakty");
                Console.WriteLine("5. Usuń kontakt po numerze");
                Console.WriteLine("6. Uruchopm metodę która dla podanej wartości typu string sprawdzi czy jest ona poprawną liczbą ujemną - czyli zwróci wartość true lub false i dodatkowo jeśli dana wartość jest ujemna to zwróci tą ujemną liczbę jako wartość typu int");
                Console.WriteLine("X. Wyjdz z aplikacji");

                var userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        
                        var numer = "";
                        var nazwa = "";
                        while (true)
                        {
                            Console.WriteLine("Wprowadź numer:");
                            numer = Console.ReadLine();
                            if (numer.Length >= 9)
                            {
                                break;
                            }
                            Console.WriteLine("Numer musi zawierać przynajmniej 9 cyfr");
                        }
                        while (true)
                        {
                            Console.WriteLine("Wprowadź nazwę:");
                            nazwa = Console.ReadLine();
                            if (nazwa.Length >= 3)
                            {
                                break;
                            }
                            Console.WriteLine("Numer musi zawierać przynajmniej 3 znaki");
                        }
                        var nowyKontakt = new Kontakt(nazwa, numer);
                        ksiazkaAdresowa.DodajKontakt(nowyKontakt);
                        Console.WriteLine($"Dodano nowy kontakt: {nazwa} {numer}");
                        break;
                    case "2":
                        Console.WriteLine("Wprowadź numer:");
                        var numerDoWyszukania = Console.ReadLine();
                        ksiazkaAdresowa.WyswietlKontakt(numerDoWyszukania);
                        break;
                    case "3":
                        ksiazkaAdresowa.WyswietlWszystkieKontakty();
                        break;
                    case "4":
                        Console.WriteLine("Wprowadź szukaną frazę:");
                        var szukanaFraza = Console.ReadLine();

                        ksiazkaAdresowa.WyswietlPasujaceKontaktu(szukanaFraza);
                        break;
                    case "5":
                        Console.WriteLine("Wprowadź numer do usunięcia:");
                        var numerDoUsuniecia = Console.ReadLine();
                        if (ksiazkaAdresowa.WyswietlKontakt(numerDoUsuniecia))
                        {
                            Console.WriteLine($"Wpisz t jeśli chcesz usunąć wybrany kontakt:");
                            string zatwierdzenie = Console.ReadLine();

                            if (zatwierdzenie == "t")
                            {
                                ksiazkaAdresowa.UsunKontakt(numerDoUsuniecia);
                                Console.WriteLine("Kontakt usunięto!");
                            }
                            else
                            {
                                Console.WriteLine("Pominięto usunięcie. Brak zatwierdzenia.");
                            }
                        }
                        break;
                    case "6":
                        Sprawdzenie(out int liczba);
                        break;
                    case "x":
                        return; //wyjdzie z metody Main
                    default:
                        Console.WriteLine("Niedozwolona operacja!");
                        break;
                }
                Console.WriteLine("Naciśnij dowolny klawisz.");
                Console.ReadKey();
                Console.Clear();
                
            }

            
        }
    }
}
