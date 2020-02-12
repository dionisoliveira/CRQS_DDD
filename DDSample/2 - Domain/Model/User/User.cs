using System;
using System.ComponentModel.DataAnnotations.Schema;
using static Dapper.SqlMapper;

namespace DDDSample.Domain
{

    [Table("User")]
    public class User 
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        

    }
}
