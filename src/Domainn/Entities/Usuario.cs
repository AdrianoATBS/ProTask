using Core.Exceptions;
using Core.Validations;
using Core.Validations.Validators;

namespace Entities;

public class Usuario
{

    public Guid Hash { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Cargo { get; set; }
    public bool StatusDeAceitacao { get; set; }
    public DateTime DataDeCriacao{ get; set; }
    public DateTime UltimoLogin { get; set; }

    public Usuario(Guid hash, string nome, string email, string cargo, bool statusDeAceitacao, DateTime dataDeCriacao, DateTime ultimoLogin)
    {
        //Validação do noome
        var resultadoNome = Validacao.ValidarNome(nome);
        if(!resultadoNome.IsValid)
            throw new ValidacaoException(resultadoNome.ErrorMessage,101);
        
        //Validação do e-mail
        var resultadoEmail = Validacao.validarEmail(email);
        if(!resultadoEmail.IsValid)
            throw new ValidacaoException(resultadoEmail.ErrorMessage, 102);
        
        //Validação do cargo
        var resultadoCargo = UsuarioValidator.ValidarCargo(cargo);
        if (!resultadoCargo.IsValid)
            throw new ValidacaoException(resultadoCargo.ErrorMessage, 103);
        
        //Validação do status de aceitação
        var resultadoStatus = Validacao.ValidarStatusAceitacao(statusDeAceitacao);
        if(!resultadoStatus.IsValid)
            throw new ValidacaoException(resultadoStatus.ErrorMessage, 104);
        
        //Validação da data de criação
        var resultadoData = Validacao.ValidarDataCriacao(dataDeCriacao);
        if(!resultadoData.IsValid)
            throw new ValidacaoException(resultadoData.ErrorMessage, 105);


        Hash = hash;
        Nome = nome;
        Email = email;
        Cargo = cargo;
        StatusDeAceitacao = statusDeAceitacao;
        DataDeCriacao = dataDeCriacao;
        UltimoLogin = ultimoLogin;
    }

}
