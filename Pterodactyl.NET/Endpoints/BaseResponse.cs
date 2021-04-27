namespace Pterodactyl.NET.Endpoints
{
    public class BaseResponse<T>
    {

        public string Object { get; set; }

        public T Attributes { get; set; }

    }
}
