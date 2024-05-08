using Models;
using Newtonsoft.Json;
using Services.InMemory;
using Services.Interfaces;

namespace Services.InFile
{
    //dziedziczymy po MemoryEntityService, poniważ chcemy skorzystać z tam zapisanej funkcjonalności a tylko dodać opcje zapisu
    public class FileEntityService<T> : MemoryEntityService<T>, IEntityService<T> where T : Entity
    {
        public string FilePath { get; }

        public FileEntityService(string filePath)
        {
            FilePath = filePath;
            LoadFromFile();
        }

        //override - nadpisujemy implementację funkcji wirtualnej
        public override void Create(T entity)
        {
            //base - wykonujemy wersję metody z klasy bazowej
            base.Create(entity);

            SaveToFile();
        }

        public override bool Update(int id, T entity)
        {
            bool result = base.Update(id, entity);
            if (result == true)
                SaveToFile();
            return result;
        }

        public override bool Delete(int id)
        {
            bool result =  base.Delete(id);
            if (result == true)
                SaveToFile();
            return result;
        }

        private void SaveToFile()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Formatting = Formatting.Indented;

            string json = JsonConvert.SerializeObject(Entities, settings);

            //klasy strumieniowe - klasy opierające swoje działanie na strumieniu byteów
            //wykorzustanie using spowoduje automatyczne wywołanie funkcji Dispose
            //using FileStream fileStream = new FileStream(FilePath, FileMode.Create);
            
            //using StreamWriter streamWriter = new StreamWriter(fileStream); //klasa pomocnicza do zapisu danych do strumienia obsługująca tekst
            //streamWriter.Write(json);
            //metoda flush wymusza wypchnięcie danych do strumienia
            //streamWriter.Flush();

            //streamWriter.Dispose();
            //fileStream.Dispose();

            //File - fasada ułatwiająca pracę z plikami
            File.WriteAllText(FilePath, json);

        }

        private void LoadFromFile()
        {
            //using FileStream fileStream = new FileStream(FilePath, FileMode.OpenOrCreate);
            //using StreamReader streamReader = new StreamReader(fileStream);
            //string json = streamReader.ReadToEnd();

            string json = File.ReadAllText(FilePath);

            List<T> items = JsonConvert.DeserializeObject<List<T>>(json);

            if(items != null)
                Entities.AddRange(items);

        }
    }
}
