using MyTasks.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTasks.Services
{
    class FileInputOutputService
    {
        private readonly string PATH;

        public FileInputOutputService(string path)
        {
            PATH = path;
        }

        public BindingList<TaskModel> LoadData()
        {
            var fileExists = File.Exists(PATH);
            if (!fileExists)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<TaskModel>();
            }
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<TaskModel>>(fileText);
            }
        }

        public void SaveData(object taskDataList)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(taskDataList);
                writer.Write(output);
            }
        }
    }
}
