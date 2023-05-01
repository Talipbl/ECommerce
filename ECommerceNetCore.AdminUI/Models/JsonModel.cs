namespace ECommerceNetCore.AdminUI.Models
{
    public class JsonModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public JsonModel()
        {

        }
        public JsonModel(bool success)
        {
            this.Success = success;
        }
        public JsonModel(bool success, string message) : this(success)
        {
            this.Message = message;
        }
    }
}
