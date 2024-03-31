using AutoMapper;
using CasasBahia.Api.DTOs;
using CasasBahia.Api.Model;
using CasasBahia.Api.Repository.Interface;
using CasasBahia.Api.Service.Interface;
using Newtonsoft.Json;

namespace CasasBahia.Api.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IKafkaProducerService _kafkaProducerService;
        private readonly IMapper _mapper;
        private readonly string _topic = "Estoque";

        public ProdutoService(IProdutoRepository produtoRepository,
                              IMapper mapper,
                              IKafkaProducerService kafkaProducerService)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
            _kafkaProducerService = kafkaProducerService;
        }

        public async Task<IEnumerable<Produto>> GetProducts()
        {
            var productsEntity = await _produtoRepository.GetAll();
            return _mapper.Map<IEnumerable<Produto>>(productsEntity);
        }

        public async Task<Produto> GetProductById(int id)
        {
            var productEntity = await _produtoRepository.GetProdutoById(id);
            return _mapper.Map<Produto>(productEntity);
        }
        
        public async Task<Produto> AddProduct(ProdutoDTO  produtoDTO)
        {
            var productEntity = _mapper.Map<Produto>(produtoDTO);
            var produto = await _produtoRepository.Create(productEntity);
            await SendProductToKafka(produto);
            return produto;
        }

        public async Task DeleteProduct(int id)
        {
            var productEntity = await _produtoRepository.GetProdutoById(id);
            if (productEntity != null)
            {
                await _produtoRepository.Delete(productEntity.IdProduto);
            }
        }

        public async Task UpdateProduct(ProdutoDTO produtoDTO)
        {
            var productEntity = _mapper.Map<Produto>(produtoDTO);
            await _produtoRepository.Update(productEntity);
        }

        private async Task SendProductToKafka(Produto produto)
        {
            string productJson = JsonConvert.SerializeObject(produto);
            await _kafkaProducerService.ProduceAsync(_topic, productJson);
        }
    }
}