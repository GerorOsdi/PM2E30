using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PM2E30.Models
{
    public class Lugares
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public string desc { get; set; }
        public byte[] photo { get; set; }
    }
}
