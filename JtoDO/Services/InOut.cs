using JtoDO.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JtoDO.Services
{
    class InOut
    {
        private readonly string path;

        public InOut(string path)
        {
            this.path = path;
        }
        public BindingList<TodoModel> LoadData()
        {
            var FileExist = File.Exists(path);
            if(!FileExist)
            {
                File.CreateText(path).Dispose();
                return new BindingList<TodoModel>();
            }
            using(var reader = File.OpenText(path))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<TodoModel>>(fileText);
            }
            
        }

        public void SaveData(object todoData)
        {
            using(StreamWriter write = File.CreateText(path))
            {
                string output = JsonConvert.SerializeObject(todoData);
                write.Write(output);
            }
        }
    }
}
