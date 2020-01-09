using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Contracts.Models.DistrictModels;
using AutoMapper;
using BLL.Infrastructure;
using BLL.Interfaces;
using Castle.Core.Internal;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class DistrictService : IDistrictService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public DistrictService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task CreateAsync(DistrictModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var entity = (await _uow.DistrictRepository.FindAsync(opt => opt.Name == model.Name)).FirstOrDefault();

            if (entity != null)
            {
               throw new ArgumentNullException(nameof(entity));
            }

            await _uow.DistrictRepository.CreateAsync(new DistrictEntity { Name = model.Name });
            await _uow.SaveAsync();
        }

        public async Task UpdateAsync(DistrictDashboardModel model)
        {
            if (model == null)
            {
               throw new ArgumentNullException(nameof(model)); 
            }

            if (string.IsNullOrEmpty(model.Id))
            {
                throw new ArgumentNullException(nameof(model.Id));
            }

            var result = _mapper.Map<DistrictEntity>(model);
            _uow.DistrictRepository.Update(result);
            await _uow.SaveAsync();
        }

        public async Task RemoveAsync(string id)
        {
            if (id.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(id));
            }
            var district = await _uow.DistrictRepository.GetAsync(id);
            _uow.DistrictRepository.Remove(district);
            await _uow.SaveAsync();
        }

        public async Task<List<DistrictDashboardModel>> GetAsync()
        {
            var districtEntity =await _uow.DistrictRepository.GetAllAsQueryable().ToListAsync();
            var result = _mapper.Map<List<DistrictDashboardModel>>(districtEntity);
            return result;
        }



    }
}
