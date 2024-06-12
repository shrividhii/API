using AutoMapper;
using Common.EntityClass;
using Common.UpdationModel;
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
            CreateMap<Common.DBEntityClass.UserDetail, Common.UserModel.UserDetails>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));

            CreateMap<Common.UserModel.UserDetails, Common.DBEntityClass.UserDetail>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));


            CreateMap<Common.DBEntityClass.Brand, BrandModel>()
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.BrandName));

            CreateMap<BrandModel, Common.DBEntityClass.Brand>()
                .ForMember(dest => dest.BrandId, opt => opt.Ignore());

            CreateMap<Common.DBEntityClass.Brand, BrandUpdationModel>();

            CreateMap<BrandModel, Common.DBEntityClass.Brand>();


            CreateMap<Common.DBEntityClass.Category, CategoryUpdationModel>().ReverseMap();

            CreateMap<Common.DBEntityClass.Category, CategoryModel>().ReverseMap();

            CreateMap<Common.DBEntityClass.Product, ProductUpdationModel>().ReverseMap();

            CreateMap<Common.DBEntityClass.Product, ProductModel>().ReverseMap();

            CreateMap<Common.DBEntityClass.ProductVariation, ProductVariationUpdationModel>().ReverseMap();
            CreateMap<Common.DBEntityClass.ProductVariation, ProductVariationsModel>().ReverseMap();

          

        }
        
    }
}
