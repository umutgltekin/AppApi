namespace App.Base
{
    public class BaseModel
    {
        public int Id { get; set; }
        public int InsertUserId { get; set; }
        public DateTime InsertDate { get; set; }
        public int UpdateUserId { get; set; }
        public  DateTime? UpdateDate { get; set; }
        public bool IsActive { get; set; }
    }
}
