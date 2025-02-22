﻿using Models;
using Services.InMemory;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;
using Warehouse.Properties;
using Newtonsoft.Json;
using System.Xml;
using Services.Interfaces;

namespace Warehouse
{
    internal abstract class GenericProgram<T> where T : Entity
    {

        IEntityService<T> _service;

        public GenericProgram(IEntityService<T> service)
        {
            _service = service;
        }

        public void Run()
        {
            
            bool exit = false;
            do
            {
                Console.Clear();
                Show();
                Console.WriteLine($"{Resources.Commands}: {Resources.Create}, {Resources.Update}, {Resources.Delete}, {Resources.Json}, {Resources.XML}, {Resources.Exit}");


                string input = Console.ReadLine();

                if(input == Resources.Exit)
                {
                    exit = true;
                }
                else if(input == Resources.Create)
                {
                    Create();
                }
                else if (input == Resources.Update)
                {
                    Update();
                }
                else if (input == Resources.Delete)
                {
                    Delete();
                }
                else if (input == Resources.Json)
                {
                    ToJson();
                }
                else if (input == Resources.XML)
                {
                    ToXml();
                }
                else
                {
                    Console.WriteLine("command not found...");
                    Console.ReadLine();
                }

                /*switch (input)
                {
                    case "exit":
                        exit = true;
                        break;
                    case "create":
                        Create();
                        break;
                    case "update":
                        Update();
                        break;
                    case "delete":
                        Delete();
                        break;
                    default:
                        Console.WriteLine("command not found...");
                        Console.ReadLine();
                        break;
                }*/


            } while (!exit);
        }
        void ToXml()
        {
            /*int id = GetInt("Id");
            T item = _service.Read(id);
            if (item == null)
                return;

            //serializacja do XML wykorzystując biblioteki standardowe
            //wymagana jest osobna konfiguracja serializacji dla XML i JSON
            XmlSerializer xmlSerializer = new XmlSerializer(item.GetType());
            using MemoryStream stream = new MemoryStream(); //wykorzystuje klasy strumieniowe
            xmlSerializer.Serialize(stream, item);

            string xml = Encoding.Default.GetString(stream.ToArray());*/

            //funkcja ToJson zwraca nam jsona z którego zostanie utworzony XML
            string json = ToJson();

            //Serializacja do XML z wykorzystaniem Newtonsoft.Json opiera się o wytworzonego wcześniej Jsona
            //pozwala to posiadać jedną konfigurację serializacj do obu formatów
            XmlDocument xml = JsonConvert.DeserializeXmlNode(json, typeof(T).Name); //drugi parametr określa nazwę głównego obiektu, typeof() - pobiera dane o typie


            Console.WriteLine(xml.InnerXml);
            Console.ReadLine();
        }

        string? ToJson()
        {
            int id = GetInt("Id");
            T item = _service.Read(id);
            if (item == null)
                return null;


            //opcje serializacji do json z bibliotek standardowych
            /*JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions();
            jsonSerializerOptions.WriteIndented = true;
            jsonSerializerOptions.IgnoreReadOnlyProperties = true;
            jsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;

            //serializacja za pomocą bibliotek standardowych
            string json = JsonSerializer.Serialize(item, jsonSerializerOptions);*/

            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            jsonSerializerSettings.DefaultValueHandling = DefaultValueHandling.Ignore;
            jsonSerializerSettings.DateFormatString = "yyyy MMM d";

            //serializacja do json z wykorzystaniem Newtonsoft.Json
            string json = JsonConvert.SerializeObject(item, jsonSerializerSettings);

            Console.WriteLine( json );
            Console.ReadLine();
            return json;
        }

        void Update()
        {
            int id = GetInt("Id");
            T old = _service.Read(id);
            if (old == null)
                return;

            T product = CreateUpdate(old);

            _service.Update(id, product);
        }
        //nie wiemy jak stworzyć element typu T, więc tworzymy metodę abstrakcyjną, której ciało będzie musiało być zapewnione w klasacho pochodnych
        protected abstract T CreateUpdate(T old);

        void Delete()
        {
            int id = GetInt("Id");

            _service.Delete(id);
        }

        void Show()
        {
            foreach (T p in _service.Read())
            {
                Console.WriteLine(p.ToString()); //wykorzystujemy nadpisaną metodę ToString() w celu zaprezentowania obiektu w formie ciągu znaków
            }
        }

        void Create()
        {
            T entity = CreateNew();

            _service.Create(entity);
        }

        protected abstract T CreateNew();

        public static string GetString(string label)
        {
            Console.WriteLine($"{label}:");
            string data = Console.ReadLine();
            return data;
        }



        public static float GetFloat(string label)
        {
            string data = GetString(label);

            //try-catch - służy do obsługi wyjątków.
            //W bloku try umieszczamy kod w którym może potencjalnie wystąpić wyjątek
            //Blok catch zawiera kod, który ma być wykonany jeśli wyjątek wystąpi
            try
            {
                return float.Parse(data);
            }
            //catch - bez parametru - przechwytuje wszystkie wyjątki i nie daje wglądu w obiekt wyjątku
            //catch() - z parametrem - przechwytuje wyjątki zgodne z klasą parametru, dając wgląd w obiekt
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return GetFloat(label);
            }
        }

        public static int GetInt(string label)
        {
            string data = GetString(label);
            try
            {
                //throw new ArgumentException();
                return int.Parse(data);
            }
            //możemy mieć wiele bloków catch w kolejność od szczegółu do ogółu (najbardziej ogólny wyjątek na końcu)
            //dzięki temu możemy wykonywać różne akcje w zależności od klasy wyjątku
            catch (IndexOutOfRangeException) //nazwa parametru jest opcjonalna - jeśli nie potrzebujemy odczytywać właściwości z obiektu wyjątku nie musimy deklarować nazwy 
            {
                return -1;
            }
            catch (FormatException e) //korzystamy z właściwości wyjątku, więc nazywamy jego obiekt jako "e", żeby mieć do niego dostęp
            {
                Console.WriteLine(e.Message);
                return GetInt(label);
            }
            catch (Exception)
            {
                return -2;
            }
        }

        public static DateTime GetDateTime(string label)
        {
            DateTime date;
            bool success;
            do
            {
                string data = GetString(label);
                //metoda TryParse zamiast rzucać wyjątek przy niepowodzeniu, zwraca informację w postaci bool (true/false) czy parsowanie się powiodło
                //rezultat parzowania możemy użyskać z drugiego parametru
                //parametry, który zwracają dodatkowe informacje z funkcji nazywane są parametrami wyjściowymi i muszą być poprzedzone słowem kluczowym "out" zarówno w definicji funkcji jak i podczas jej wywoływania
                success = DateTime.TryParse(data, out date);
            } while (!success);

            return date;
        }

    }
}
