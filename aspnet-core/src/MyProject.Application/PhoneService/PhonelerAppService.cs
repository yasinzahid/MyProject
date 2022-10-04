using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using MyProject.Phoneler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.PhoneService
{
    public class PhonelerAppService : IPhoneAppService
    {
        private readonly IRepository<Phone> _repository;

        public PhonelerAppService(IRepository<Phone> repository)
        {
            _repository = repository;
        }   
        public async Task<List<PhonelerDto>> Get()
        {
        var entitylist = await _repository.GetAllListAsync();
            return entitylist.Select (e => new PhonelerDto
            {
                Id=e.Id,
                Marka=e.Marka,
                Model=e.Model,
                Hafiza=e.Hafiza,
                RAM=e.RAM,                                     
                Renk=e.Renk,
                EkranBouyutu=e.EkranBoyutu,
                Garanti=e.Garanti,
                SatildiMi=e.SatildiMi,
                StokAdedi=e.StokAdedi,
                 
            }).ToList();
        }
        public async Task Create(PhonelerDto input)
        {
            var entity = new Phone
            {
                Id = input.Id,
                Marka = input.Marka,
                Model = input.Model,
                Hafiza = input.Hafiza,
                RAM = input.RAM,
                Renk = input.Renk,
                EkranBoyutu = input.EkranBouyutu,
                Garanti = input.Garanti,
                SatildiMi = input.SatildiMi,
                StokAdedi = input.StokAdedi,
            };
            await _repository.InsertAsync(entity);  
        }
        public async Task PhoneGuncelle(PhonelerDto input, int id)
        {
            var entity = await _repository.GetAsync(id);
            if (entity==null)
            {
                throw new UserFriendlyException("bu id de teelefon yok");
            }
            entity.Id = id;
            entity.Marka = input.Marka; 
            entity.Model = input.Model;
            entity.Hafiza = input.Hafiza;
            entity.RAM = input.RAM; 
            entity.Renk = input.Renk;
            entity.EkranBoyutu = input.EkranBouyutu;
            entity.Garanti = input.Garanti;
            entity.SatildiMi = input.SatildiMi;
            entity.StokAdedi = input.StokAdedi;
            await _repository.InsertOrUpdateAsync(entity);
        }

        public async Task<List<PhonelerDto>> SatilanlariListele()
        {
            var entityList =await _repository.GetAll().Where(q => q.SatildiMi == true).ToListAsync();
            return entityList.Select(e => new PhonelerDto
            {
                Id = e.Id,
                Marka = e.Marka,
                Model = e.Model,
                Hafiza = e.Hafiza,
                RAM = e.RAM,
                Renk = e.Renk,
                EkranBouyutu = e.EkranBoyutu,
                Garanti = e.Garanti,
                SatildiMi = e.SatildiMi,
                StokAdedi = e.StokAdedi,

            }).ToList();
        }

        public async Task<List<PhonelerDto>> SatilmayanlariListele()
        {
            var entityList = await _repository.GetAll().Where(q => q.SatildiMi == false).ToListAsync();
            return entityList.Select(e => new PhonelerDto
            {
                Id = e.Id,
                Marka = e.Marka,
                Model = e.Model,
                Hafiza = e.Hafiza,
                RAM = e.RAM,
                Renk = e.Renk,
                EkranBouyutu = e.EkranBoyutu,
                Garanti = e.Garanti,
                SatildiMi = e.SatildiMi,
                StokAdedi = e.StokAdedi,

            }).ToList();
        }
        public async Task<int> StokAdedi()
        {
            var entityList = await _repository.GetAll().Where(q => q.SatildiMi == false).ToListAsync();
            return entityList.Count();
        }

        public async Task Sat(int id)
        {
            var entity = await _repository.GetAsync(id);
            if (entity.SatildiMi) 
            {
                throw new UserFriendlyException("Bu Ürün Zaten Satıldı");
            }
            entity.SatildiMi=true;
            await _repository.InsertOrUpdateAsync(entity);

        }


        public async Task<List<PhonelerDto>> GarantileriListele()
        {
            var entityList = await _repository.GetAll().Where(q => q.Garanti>0).ToListAsync();
            return entityList.Select(e => new PhonelerDto
            {
                Id = e.Id,
                Marka = e.Marka,
                Model = e.Model,
                Hafiza = e.Hafiza,
                RAM = e.RAM,
                Renk = e.Renk,
                EkranBouyutu = e.EkranBoyutu,
                Garanti = e.Garanti,
                SatildiMi = e.SatildiMi,
                StokAdedi = e.StokAdedi,

            }).ToList();
        }


        public async Task Delete(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
