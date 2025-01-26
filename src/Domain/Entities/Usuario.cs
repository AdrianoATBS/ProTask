using Validations;
using Exceptions;


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
        var erros = new List<string>();
        var nomeValidation = Validacao.ValidarNome(nome);
        if(!nomeValidation.IsValid)
            erros.Add(nomeValidation.ErrorMessage);
        
        var emailValidation = Validacao.ValidarEmail(email);
        if(!emailValidation.IsValid)
            erros.Add(emailValidation.ErrorMessage);

        var cargoValidation = Validacao.ValidarCargo(cargo);
        if(!cargoValidation.IsValid)
            erros.Add(cargoValidation.ErrorMessage);

        var dataDeCriacaoValidation = Validacao.ValidarDataCriacao(dataDeCriacao);
        if(!dataDeCriacaoValidation.IsValid)
            erros.Add(dataDeCriacaoValidation.ErrorMessage);
        
        var statusDeAceitacaoValidation = Validacao.ValidarStatusAceitacao(statusDeAceitacao);
        if(!statusDeAceitacaoValidation.IsValid)
            erros.Add(statusDeAceitacaoValidation.ErrorMessage);

        if(erros.Count > 0)
        {
            throw new ValidacaoException("Falha na validação dos dados do usuário", 101,erros);
        }


        Hash = hash;
        Nome = nome;
        Email = email;
        Cargo = cargo;
        StatusDeAceitacao = statusDeAceitacao;
        DataDeCriacao = dataDeCriacao;
        UltimoLogin = ultimoLogin;
    }

}
