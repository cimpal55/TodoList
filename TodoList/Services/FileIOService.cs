using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TodoList.MVVM.Models;

namespace TodoList.Services
{
    class FileIOService
    {
        private readonly string PATH;

        public FileIOService(string path)
        {
            PATH = path;
        }
        public BindingList<ToDoModel> LoadData()
        {
            var fileExists = File.Exists(PATH);
            if (!fileExists)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<ToDoModel>();
            }

            using var reader = File.OpenText(PATH);
            var fileText = reader.ReadToEnd();

            // From file to memory
            return JsonConvert.DeserializeObject<BindingList<ToDoModel>>(fileText);

        }

        public void SaveData(object toDoData)
        {
            // Save data to file
            using var writer = File.CreateText(PATH);

            string output = JsonConvert.SerializeObject(toDoData);
            writer.Write(output);
        }
    }
}
