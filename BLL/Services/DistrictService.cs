using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Contracts.Models.DistrictModels;
using AutoMapper;
using BLL.Infrastructure;
using BLL.Interfaces;
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

        public async Task<OperationDetails> CreateAsync(DistrictModel model)
        {
            if (model == null)
            {
                //throw new ArgumentNullException(nameof(model));
            }
            
            // TODO: rename
            var foo = (await _uow.DistrictRepository.FindAsync(opt => opt.Name == model.Name)).FirstOrDefault();

            if (foo != null)
            {
                return new OperationDetails(false, "District already exists", string.Empty);
            }

            await _uow.DistrictRepository.CreateAsync(new DistrictEntity { Name = model.Name });
            await _uow.SaveAsync();
            return new OperationDetails(true, "ok", string.Empty);
        }

        public async Task<OperationDetails> UpdateAsync(DistrictDashboardModel model)
        {
            if (model?.Id == null)
            {
                return new OperationDetails(false, "District  was not found", string.Empty);
            }
            

            var result = _mapper.Map<DistrictEntity>(model);
            _uow.DistrictRepository.Update(result);
            await _uow.SaveAsync();

            return new OperationDetails(true, "District was updated", string.Empty);
        }

        public async Task<OperationDetails> RemoveAsync(string id)
        {
            if (id == null)
            {
                return new OperationDetails(true, "District id was not found", string.Empty);
            }
            var district = await _uow.DistrictRepository.GetAsync(id);
            _uow.DistrictRepository.Remove(district);
            await _uow.SaveAsync();

            return new OperationDetails(true, "District was deleted", string.Empty);
        }

        public async Task<List<DistrictDashboardModel>> GetAsync()
        {
            var districtEntity =await _uow.DistrictRepository.GetAllAsQueryable().ToListAsync();
            var result = _mapper.Map<List<DistrictDashboardModel>>(districtEntity);
            return result;
        }



    }
}
