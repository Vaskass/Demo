using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{       
    [Table(Name = "Клиент")]
   public class Client
    {
        [Column (Name ="ID клиента", IsDbGenerated =true, IsPrimaryKey =true)]
        public int ID { get; set; }

        [Column(Name = "Фамилия")]
        public string fam { get; set; }

        [Column(Name = "Имя")]
        public string name { get; set; }

        [Column(Name = "Отчество")]
        public string otch { get; set; }

        [Column(Name = "Номер паспорта")]
        public int numPas { get; set; }

        [Column(Name = "Серия паспорта")]
        public int serPas { get; set; }

        [Column(Name = "Дата рождения")]
        public DateTime birth { get; set; }

        [Column(Name = "Пол")]
        public string pol { get; set; }
    }
}
