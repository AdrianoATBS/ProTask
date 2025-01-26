using System;

namespace Exceptions;

public class ValidacaoException : Exception
{
    public int CodigoErro{ get; set; }
    
    public List<string> Erros { get; set; } 

    public ValidacaoException() : base("Erro de validação")
    {

    }
    public ValidacaoException(string mensagem) : base(mensagem)
    {

    }
    public ValidacaoException(string mensagem, Exception innerExcption) : base(mensagem, innerExcption)
    {

    }
     public ValidacaoException(string mensagem, int codigoErro) : base(mensagem)
        {
            CodigoErro = codigoErro;
            Erros = new List<string>();  
        }

        public ValidacaoException(string mensagem, int codigoErro, List<string> erros) : base(mensagem)
        {
            CodigoErro = codigoErro;
            Erros = erros;  
        }
}
