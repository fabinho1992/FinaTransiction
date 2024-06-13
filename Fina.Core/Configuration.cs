using Fina.Core.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fina.Core
{
    public class Configuration 
    {
        public const int DefaultStatusCode = 200; //número de retorno do status padrão 
        public const int DefaultPageNumber = 1;// número da página
        public const int DefaultPageSize = 25;//quantidade de registros na pagina

        
        public static string BackEndUrl {  get; set; } = string.Empty;
        public static string FrontEndUrl { get; set; } = string.Empty;
    }
}
