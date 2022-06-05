using System;
using System.Collections.Generic;
using System.Text;

namespace DB_work_1.Models
{
    public class Position
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Salary { get; set; }

        public int MaxNumber { get; set; }

        public List<User> Users { get; set; }

        public int DeportamentId { get; set; }

        public Deportament Deportament { get; set; }



    }
}
