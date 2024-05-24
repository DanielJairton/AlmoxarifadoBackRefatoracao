using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoInfrastructure.Data.Enum;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Repositories
{
    public class EstoqueRepository : IEstoqueRepository
    {
        private readonly ContextSQL _context;
        private readonly ProdutoRepository _produtoRepository;

        public EstoqueRepository(ContextSQL context)
        {
            _context = context;
            _produtoRepository = new ProdutoRepository(context);
        }

        public Estoque AumentarEstoque(int id_Sec, int id_Pro,  decimal? qtdPro)
        {
            if (qtdPro.HasValue && qtdPro > 0)
            {
                Estoque estoque = _context.Estoque.Find(id_Sec, id_Pro) 
                    ?? throw new KeyNotFoundException($"Estoque não encontraddo com ID_SEC:{id_Sec} ID_PRO:{id_Pro}");

                estoque.QTD_PRO += qtdPro.Value;
                _context.Estoque.Update(estoque);

                _context.SaveChanges();

                return estoque;
            }
            else
            {
                throw new Exception("Quantidade de produto adicionado inválida para aumento de estoque");
            }
        }

        public Estoque DiminuirEstoque(int id_Sec, int id_Pro, decimal? qtdPro, int id_Req, EnumTipoTransacao tipoTransacao)
        {
            if (qtdPro.HasValue && qtdPro >= 0)
            {
                Estoque estoque = _context.Estoque.Find(id_Sec, id_Pro)
                    ?? throw new KeyNotFoundException($"Estoque não encontraddo com ID_SEC:{id_Sec} ID_PRO:{id_Pro}");

                if (qtdPro == 0)
                {
                    return estoque;
                }

                if (estoque.QTD_PRO >= qtdPro)
                {
                    Produto produto = _produtoRepository.ObterProduto(id_Pro);
                    if (produto.ESTOQUE_MIN != null && produto.ESTOQUE_MIN > (estoque.QTD_PRO - qtdPro) && produto.ESTOQUE_MIN < estoque.QTD_PRO)
                    {
                        decimal? estoqueAtualQtd = estoque.QTD_PRO - qtdPro;
                        GerarLog(id_Pro, id_Sec, id_Req, estoqueAtualQtd, tipoTransacao);
                    }

                    estoque.QTD_PRO -= qtdPro.Value;
                    _context.Estoque.Update(estoque);

                    _context.SaveChanges();

                    return estoque;
                }
                else
                {
                    throw new Exception("Tentativa de tirar mais produtos do que existem no estoque");
                }
            }
            else
            {
                throw new Exception("Quantidade de produto retirada inválida para diminuição de estoque");
            }
        }

        public void GerarLog(int id_Pro, int id_Sec, int id_Transacao, decimal? qtdAtual, EnumTipoTransacao tipoTransacao)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory.Replace("AlmoxarifadoAPI\\bin\\Debug\\net6.0\\", "");
            string logPath = Path.Combine(baseDirectory, "AlmoxarifadoInfrastructure", "LOGS");

            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }

            DateTime dataAtual = DateTime.Now;
            string arquivoNome = $"produtosAbaixoMinimoEm{dataAtual:yyyyMMdd_HHmmss}_{id_Transacao}.csv";
            string arquivoPath = Path.Combine(logPath, arquivoNome);

            string cabecalho = $"Codigo Produto;Codigo Secretaria;Codigo {tipoTransacao};Quantidade Atual;Data do Registro";
            string linha = $"{id_Pro};{id_Sec};{id_Transacao};{qtdAtual};{dataAtual:yyyy-MM-dd HH:mm:ss}";
            string conteudo = $"{cabecalho}\n{linha}";

            File.WriteAllText(arquivoPath, conteudo);
        }
    }
}
