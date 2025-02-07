public class FailureToSupplyReuqestDto
{
    public List<Line> Lines { get; set; }
    public int ReasonId { get; set; }

    public class Line
    {
        public int LineId { get; set; }
        public int Quantity { get; set; }
    }
}
