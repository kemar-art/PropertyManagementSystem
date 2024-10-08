﻿namespace PMS.UI.Services.Base
{
    public class Response<T>
    {
        public string Message { get; set; } = string.Empty;
        public string ValidationErrors { get; set; } = string.Empty;
        public bool Success { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
        public T Data { get; set; }
    }
}
