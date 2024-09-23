using LISTA06Q03.Repository;
using Microsoft.AspNetCore.Mvc;
using LISTA06Q03.Models;

namespace LISTA06Q03.Controllers
{

    [ApiController]
    [Route("API/PessoaController")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepository _pessoaRepository;
        public PessoaController(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        [HttpPost]
        [Route("CadastrarPessoa")]
        public IActionResult CadastrarPessoa(Pessoa pessoa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _pessoaRepository.CadastrarPessoa(new Pessoa()
            {
                Nome = pessoa.Nome,
                CPF = pessoa.CPF,
                Peso = pessoa.Peso,
                Altura = pessoa.Altura
            });
            return Ok($"{pessoa.Nome} cadastrado(a) com sucesso");
        }

        [HttpPut]
        [Route("AtualizarPessoa")]
        public IActionResult AtualizarDados(string cpf, Pessoa novosDados)
        {
            Pessoa pessoaAtualizar = _pessoaRepository.AtualizarCadastro(cpf, novosDados);

            try
            {
                return Ok(new { mensagem = "Dados de cadastro atualizados!", pessoa = pessoaAtualizar });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        [Route("RemoverPessoa")]
        public IActionResult RemoverCadastro(string cpf)
        {
            try
            {
                _pessoaRepository.RemoverCadastro(cpf);
                return Ok($"{cpf} removido(a)");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            //_pessoaRepository.RemoverCadastro(cpf);
        }

        [HttpGet]
        [Route("BuscarTodos")]
        public IActionResult BuscarTodos()
        {
            return Ok(_pessoaRepository.GetPessoa());
        }


        [HttpGet]
        [Route("BuscarPorCPF")]
        public IActionResult BuscarPorCPF(string cpf)
        {
            try
            {
                return Ok(_pessoaRepository.GetPessoaByCpf(cpf));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("BuscarBomIMC")]
        public IActionResult BuscarBomIMC()
        {
            return Ok(_pessoaRepository.GetIMCBom());
        }

        [HttpGet]
        [Route("BuscarPorNome")]
        public IActionResult BuscarPorNome(string nome)
        {
            try
            {
                return Ok(_pessoaRepository.GetPessoaByName(nome));
            }
            catch (Exception ex)

            {
                return BadRequest(ex.Message);
            }
        }

    }
}
