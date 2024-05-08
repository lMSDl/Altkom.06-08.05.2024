using Models;
using Newtonsoft.Json;
using Services.InMemory;
using Services.Interfaces;

namespace Services.InFile
{
    public class FileEntityService<T> : MemoryEntityService<T>, IEntityService<T> where T : Entity
    {
        public string FilePath { get; }

        public FileEntityService(string filePath)
        {
            FilePath = filePath;
            LoadFromFile();
        }


        public override void Create(T entity)
        {
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

            using FileStream fileStream = new FileStream(FilePath, FileMode.Create);

            using StreamWriter streamWriter = new StreamWriter(fileStream);
            streamWriter.Write(json);
            streamWriter.Flush();

            //streamWriter.Dispose();
            //fileStream.Dispose();

        }

        private void LoadFromFile()
        {
            using FileStream fileStream = new FileStream(FilePath, FileMode.OpenOrCreate);
            using StreamReader streamReader = new StreamReader(fileStream);
            string json = streamReader.ReadToEnd();

            List<T> items = JsonConvert.DeserializeObject<List<T>>(json);

            if(items != null)
                Entities.AddRange(items);

        }
    }
}
