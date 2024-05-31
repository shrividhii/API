using AutoMapper;
using Common.EntityClass;
using Common.UserModel;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public BrandService(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BrandModel>> GetAllBrands()
        {
            var brands = await _brandRepository.GetAllBrands();
            return _mapper.Map<IEnumerable<BrandModel>>(brands);
        }

        public async Task<BrandModel> GetBrandById(int id)
        {
            var brand = await _brandRepository.GetBrandById(id);
            return _mapper.Map<BrandModel>(brand);
        }

        public async Task AddBrand(BrandModel brandModel)
        {
            var brand = _mapper.Map<Brand>(brandModel);
            await _brandRepository.AddBrand(brand);
        }

        public async Task UpdateBrand(BrandModel brandModel)
        {
            var brand = _mapper.Map<Brand>(brandModel);
            await _brandRepository.UpdateBrand(brand);
        }

        public async Task DeleteBrand(int id)
        {
            await _brandRepository.DeleteBrand(id);
        }
    }
}
