namespace MetriFit.Response
{
    public class ResponseResult<T>
    {
        public bool Status { get; private set; }
        public  int ErrorNumber { get; private set; }
        public T Response { get; private set; }

        public ResponseResult(T entity)
        {
            Status = true;
            ErrorNumber = 200;
            Response = entity;
        }
    }
    public class ResponseResult
    {
        public bool Status { get; private set; }
        public int ErrorNumber { get; private set; }
        public string Response { get; private set; }
        public ResponseResult(Exception ex)
        {
            Status = false;
            ErrorNumber = 500;
            Response = ex.Message;
        }
        public  ResponseResult(string message)
        {
            Status = false;
            ErrorNumber = 401;
            Response = message;
        }
    }
}
