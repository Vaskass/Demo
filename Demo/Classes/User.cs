using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    [Table(Name = "Пользователи")]

    public class User
    {
        [Column(Name = "ID пользователя", IsDbGenerated = true, IsPrimaryKey = true)]
        public int ID { get; set; }

        [Column(Name = "Фамилия")]
        public string fam { get; set; }

        [Column(Name = "Имя")]
        public string name { get; set; }

        [Column(Name = "Отчество")]
        public string otch { get; set; }

        [Column(Name = "Логин")]
        public string login { get; set; }

        [Column(Name = "Пароль")]
        public string password { get; set; }

        [Column(Name = "Роль")]
        public string role { get; set; }
    }
}
