using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    [Table(Name = "Учёт")]
    public class Uchet
    {
        [Column(Name = "ID записи", IsDbGenerated = true, IsPrimaryKey = true)]
        public int ID { get; set; }

        [Column(Name = "ID клиента")]
        public int IDclient { get; set; }

        [Column(Name = "ID комнаты")]
        public int IDroom { get; set; }

        [Column(Name = "Дата заезда")]
        public DateTime dateIn { get; set; }


        [Column(Name = "Дата выезда")]
        public DateTime dateOut { get; set; }


        [Column(Name = "Сумма")]
        public float summ { get; set; }
    }


    public class UchetView
    {
        [Column(Name = "ID записи", IsDbGenerated = true, IsPrimaryKey = true)]
        public int ID { get; set; }

        [Column(Name = "ID клиента")]
        public int IDclient { get; set; }

        [Column(Name = "ФИО клиента")]
        public string FIO { get; set; }

        [Column(Name = "ID комнаты")]
        public int IDroom { get; set; }

        [Column(Name = "Номер комнаты")]
        public int numRoom { get; set; }

        [Column(Name = "Дата заезда")]
        public DateTime dateIn { get; set; }


        [Column(Name = "Дата выезда")]
        public DateTime dateOut { get; set; }


        [Column(Name = "Сумма")]
        public float summ { get; set; }
    }
}
