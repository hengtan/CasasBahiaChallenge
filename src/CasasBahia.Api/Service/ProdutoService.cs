using AutoMapper;
using CasasBahia.Api.DTOs;
using CasasBahia.Api.Model;
using CasasBahia.Api.Repository.Interface;
using CasasBahia.Api.Service.Interface;
using Confluent.Kafka;
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

        public async Task AddProduct(ProdutoDTO produtoDTO)
        {
            var productEntity = _mapper.Map<Produto>(produtoDTO);
            await _produtoRepository.Create(productEntity);
            produtoDTO.IdProduto = productEntity.IdProduto;
            
            string productJson = JsonConvert.SerializeObject(produtoDTO);
            await _kafkaProducerService.ProduceAsync(_topic, 
                productJson);
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

        public async Task<IEnumerable<ProdutoDTO>> GetProducts()
        {
            var productsEntity = await _produtoRepository.GetAll();
            return _mapper.Map<IEnumerable<ProdutoDTO>>(productsEntity);
        }

        public async Task<ProdutoDTO> GetProductById(int id)
        {
            var productEntity = await _produtoRepository.GetProdutoById(id);
            return _mapper.Map<ProdutoDTO>(productEntity);
        }
    }
}