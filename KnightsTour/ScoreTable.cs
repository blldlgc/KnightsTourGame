using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace KnightsTour
{
    [Table("Scores")]
    class ScoreTable
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }

        [Column("score")]
        public int Score { get; set; }

        [Column("date")]
        public DateTime DateTime { get; set; }
       
    }
}
