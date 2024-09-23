using LISTA06Q03.Models;
using LISTA06Q03.Uteis;

namespace LISTA06Q03.Repository
{
    public class PessoaRepository : IPessoaRepository
    {

        private static List<Pessoa> listaPessoa = new List<Pessoa>();

        public void CadastrarPessoa(Pessoa pessoa)
        {
            listaPessoa.Add(pessoa);
        }

        
        public Pessoa AtualizarCadastro(string cpf, Pessoa novosDados)
        {
            Pessoa? pessoaAtualizar = listaPessoa.Where(p => p.CPF == cpf).FirstOrDefault();

            if (pessoaAtualizar is null)
            {
                throw new Exception($"{cpf} não encontrado.");
            }

            pessoaAtualizar.Nome = novosDados.Nome;
            pessoaAtualizar.Altura = novosDados.Altura;
            pessoaAtualizar.Peso = novosDados.Peso;
            pessoaAtualizar.CPF = novosDados.CPF;

            return pessoaAtualizar;
        }


        public List<Pessoa> GetIMCBom()
        {
            double imcMin = 18.0;
            double imcMax = 24.0;

            List<Pessoa> pessoasComBomIMC = listaPessoa
                .Where(p =>
                {
                    double imc = IMC.CalcularIMC(p.Peso, p.Altura);
                    return imc >= imcMin && imc <= imcMax;
                }).ToList();

            return pessoasComBomIMC;
        }

        public List<Pessoa> GetPessoa()
        {
            return listaPessoa;
        }

        public Pessoa GetPessoaByCpf(string cpf)
        {
            Pessoa? pessoaBusca = listaPessoa.Where(p => p.CPF == cpf).FirstOrDefault();

            if (pessoaBusca is null)
            {
                throw new Exception($"{cpf} não encontrado.");
            }

            return pessoaBusca;
        }

        public List<Pessoa> GetPessoaByName(string nome)
        {
            List<Pessoa> pessoaBusca = listaPessoa.Where(p => p.Nome == nome).ToList();

            if (pessoaBusca is null)
            {
                throw new Exception($"{nome} não encontrado.");
            }

            return pessoaBusca;
        }

        public void RemoverCadastro(string cpf)
        {
            Pessoa? pessoaRemover = listaPessoa.Where(p => p.CPF == cpf).FirstOrDefault();

            if (pessoaRemover is null)
            {
                throw new Exception($"{cpf} não encontrado.");
            }

            listaPessoa.Remove(pessoaRemover);
        }
    }
}
