using AutoMapper;
using Common.EntityClass;
using Common.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.MapperClass
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<Common.EntityClass.UserDetails, Common.UserModel.UserDetails>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));

            CreateMap<Common.UserModel.UserDetails, Common.EntityClass.UserDetails>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));

            CreateMap<Brand, BrandModel>()
                .ForMember(dest => dest.BrandId, opt => opt.MapFrom(src => src.BrandId))
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.BrandName));

            CreateMap<BrandModel, Brand>()
                .ForMember(dest => dest.BrandId, opt => opt.MapFrom(src => src.BrandId))
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.BrandName));

            CreateMap<Category, CategoryModel>().ReverseMap();
            CreateMap<Product, ProductModel>().ReverseMap();

        }
        
    }
}
