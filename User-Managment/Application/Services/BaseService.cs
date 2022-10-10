using AutoMapper;
using Domain.Entities;
using Application.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace Application.Services
{
    public class BaseService<T, TSearch, TDb, TInsert, TUpdate> : IBaseService<T, TSearch, TInsert, TUpdate> where T : class where TSearch : class where TInsert : class where TUpdate : class where TDb : BaseEntity<int> 
    {
        protected readonly IApplicationDBContext _context;
        protected readonly IMapper _mapper;
        public BaseService(IApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public virtual async Task<IEnumerable<T>> GetAsync(TSearch search = null)
        {
            var entity = _context.Set<TDb>();
            return _mapper.Map<List<T>>(await entity.ToListAsync());
        }

        public virtual async Task<T> DeleteAsync(int id)
        {
            var set = _context.Set<TDb>();
            var entity = await set.FindAsync(id);
            set.Remove(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<T>(entity);
        }
        public virtual async Task<T> GetByIdAsync(int id)
        {
            var set = _context.Set<TDb>();
            var entity = await set.FindAsync(id);
            return _mapper.Map<T>(entity);
        }
        public virtual async Task<T> InsertAsync(TInsert request)
        {
            var set = _context.Set<TDb>();
            TDb entity = _mapper.Map<TDb>(request);
            entity.DateCreated = DateTime.Now;
            set.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<T>(entity);
        }
        public virtual async Task<T> UpdateAsync(int id, TUpdate request)
        {
            var set = _context.Set<TDb>();
            var entity = await set.FindAsync(id);
            _mapper.Map(request, entity);
            entity.DateModified = DateTime.Now;
            await _context.SaveChangesAsync();
            return _mapper.Map<T>(entity);
        }
    }
}
