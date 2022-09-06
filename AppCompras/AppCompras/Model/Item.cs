using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppCompras.Model
{
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Produto { get; set; }
        public double? PrecoUnt { get; set; }
        public double Qtd { get; set; }
        public string Desc { get; set; }
        public double? Total { get => Qtd * PrecoUnt; }
    }
}