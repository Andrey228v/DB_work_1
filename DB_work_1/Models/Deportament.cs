using System;
using System.Collections.Generic;
using System.Text;

namespace DB_work_1.Models
{
    public class Deportament
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public List<Position> Positions { get; set; }
    }
}
