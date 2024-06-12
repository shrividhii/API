using AutoMapper;
using Common.DBEntityClass;
using Common.UpdationModel;
using Common.UserModel;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Classes
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

        public async Task<IEnumerable<BrandUpdationModel>> GetAllBrands()
        {
            var brands = await _brandRepository.GetAllBrands();
            return _mapper.Map<IEnumerable<BrandUpdationModel>>(brands);
        }

        public async Task<BrandUpdationModel> GetBrandById(int id)
        {
            var brand = await _brandRepository.GetBrandById(id);
            return _mapper.Map<BrandUpdationModel>(brand);
        }

        public async Task AddBrand(BrandModel brandModel)
        { 
            if (await _brandRepository.BrandNameExists(brandModel.BrandName))
            {
                
                throw new Exception("Brand name already exists");
              
            }
            var brand = _mapper.Map<Brand>(brandModel);
            await _brandRepository.AddBrand(brand);
        }

        public async Task UpdateBrand(BrandUpdationModel brandModel)
        {
            var existingBrand = await _brandRepository.GetBrandById(brandModel.BrandId);
            if (existingBrand == null)
            {
                throw new KeyNotFoundException("Brand not found.");
            }

            existingBrand.BrandName = brandModel.BrandName;

            try
            {
                await _brandRepository.UpdateBrand(existingBrand);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new DbUpdateConcurrencyException("The brand was modified or deleted since it was loaded.");
            }
        }

        public void DeleteBrand(int id)
        {
            _brandRepository.DeleteBrand(id);
        }
    }
}
