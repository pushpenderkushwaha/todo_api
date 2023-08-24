namespace todo_api.Model
{
    public class Todo
    {
        public int ID { get; set; }
        public string TodoTitle { get; set; } = null!;
        public string TodoDescription { get; set;} = null!;
        public DateTime? CreatedAt { get; set;}
        public DateTime? UpdatedAt { get; set; }
      
    }
}
