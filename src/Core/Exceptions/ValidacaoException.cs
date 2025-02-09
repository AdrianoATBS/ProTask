using System;

namespace Core.Exceptions;

public class ValidacaoException : Exception
{   
    public int CodigoErro{ get; set; }
    public List<string> Erros { get; set; }

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
