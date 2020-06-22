using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    [Table(Name = "Комната")]
    public class Room
    {
        [Column(Name = "ID комнаты", IsDbGenerated = true, IsPrimaryKey = true)]
        public int ID { get; set; }

        [Column(Name = "Номер комнаты")]
        public int numRoom { get; set; }

        [Column(Name = "Количество мест")]
        public int places { get; set; }

        [Column(Name = "Стоимость сутки")]
        public float price { get; set; }

    }
}
