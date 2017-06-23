using SQLite;
using SQLite.Extensions;

namespace conceito01.Model
{
    [Table("oficinatable")]
   public class oficinatable
    {
        [PrimaryKey,AutoIncrement]
        public int id { get; set; }


        public string positiona { get; set; }


        public string positionb { get; set; }


        public string label { get; set; }


        public string address { get; set; }

        public string rating { get; set; }

        
    }
    [Table("Opinion")]
    public class Opinion
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        public int oficinaid { get; set; }

        public string feedback { get; set; }
    }
}
