namespace VortexdeCodeAPI.Responses
{

    public class FloorResponse
    {
        
        public IEnumerable<floor> Floors { get; set; }
    }


    public class floor
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
