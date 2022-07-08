using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TodoList.Core;

namespace TodoList.MVVM.Models
{
    internal class ToDoModel : ObservableObject
    {
        private string _description;

        private bool _isCompleted;

        [JsonProperty(PropertyName = "creationDate ")]
        public DateTime Date { get; set; } = DateTime.Now;

        [JsonProperty(PropertyName = "description ")]
        public string Description
        {
            get => _description;
            set
            {
                if (_description == value)
                    return;
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        [JsonProperty(PropertyName = "isCompleted ")]
        public bool IsCompleted
        {
            get => _isCompleted;
            set
            {
                if (_isCompleted == value)
                    return;
                _isCompleted = value;
                OnPropertyChanged("IsCompleted");
            }
        }
    }
}
 