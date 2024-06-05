using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Fina.Core.Responses
{
    public class Response<TData>
    {
        private int _code = Configuration.DefaultStatusCode;

        [JsonConstructor]
        public Response()
        {
            _code = Configuration.DefaultStatusCode;
        }
        public Response(TData data, int code = Configuration.DefaultStatusCode, string? message = null )
        {
            Data = data;
            _code = code;
            Message = message;
        }
        [JsonIgnore]//para não aparecer na resposta  
        public bool IsSucess => _code is >= 200 and <= 299; //IsSucess será 200 se for maior ou igual a 200 , ou menor ou igual a 299
        public TData? Data { get; set; }
        public string? Message { get; set; }
    }
}
