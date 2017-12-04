using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Models
{

    public class SelectableItem<T>
    {
        public T Data { get; set; }
        public bool Selected { get; set; }
    }
}
