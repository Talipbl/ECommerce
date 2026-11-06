namespace N11.Client
{
    public partial class TaskDetailsRequest
    {
        public int TaskId { get; set; }
        public Pagination Pageable { get; set; }
    }
}
