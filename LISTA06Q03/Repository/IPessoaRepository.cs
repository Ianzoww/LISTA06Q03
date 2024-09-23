using LISTA06Q03.Models;
namespace LISTA06Q03.Repository
{
    public interface IPessoaRepository
    {
        public void CadastrarPessoa(Pessoa pessoa);

        public Pessoa AtualizarCadastro(string cpf, Pessoa novosDados);

        public void RemoverCadastro(string Nome);

        public List<Pessoa> GetPessoa();

        public Pessoa GetPessoaByCpf(string cpf);

        public List<Pessoa> GetIMCBom();

        public List<Pessoa> GetPessoaByName(string nome);
    }
}
