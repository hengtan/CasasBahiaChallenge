using AutoMapper;
using CasasBahia.Api.Model;

namespace CasasBahia.Api.DTOs
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
        }
    }
}
