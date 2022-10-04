using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Components.Forms;
using MyProject.Masalar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.MasaService
{
    public class MasalarAppService : IMasalarAppService
    {
        private readonly IRepository<Masa> _repository;
        public MasalarAppService(IRepository<Masa> repository)
        {
            _repository = repository;
        }

        public async Task<List<MasaDto>> Get()
        {
            var entitylist = await _repository.GetAllListAsync();
            return entitylist.Select(e => new MasaDto
            {
                Id = e.Id,
                Malzemesi = e.Malzemesi,
                Marka = e.Marka,
                AyakSayisi = e.AyakSayisi,
                Islevi = e.Islevi,
                Boyu = e.Boyu,
                Eni = e.Eni,
            }).ToList();
        }
        public async Task Create(MasaDto input)
        {
            var entity = new Masa
            {
                Malzemesi = input.Malzemesi,
                Islevi = input.Islevi,
                Marka = input.Marka,
                Eni = input.Eni,
                AyakSayisi = input.AyakSayisi,
                Boyu = input.Boyu,
            };
            await _repository.InsertAsync(entity);
        }

        public async Task MasaGuncelle(MasaDto input, int id)
        {
            var entity = await _repository.GetAsync(id);
            entity.Malzemesi = input.Malzemesi;
            entity.Islevi = input.Islevi;
            entity.Marka = input.Marka;
            entity.AyakSayisi = input.AyakSayisi;
            entity.Boyu = input.Boyu;
            entity.Eni = input.Eni;
            await _repository.UpdateAsync(entity);
        }

        public async Task Delete(int id)
        {
            await _repository.DeleteAsync(id);
        }

    }
}
