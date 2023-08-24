namespace todo_api.DTO.Todo
{
    public class TodoAdd
    {
        public int? ID { get; set; }
        public string TodoTitle { get; set; } = null!;
        public string TodoDescription { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }

    }
}
