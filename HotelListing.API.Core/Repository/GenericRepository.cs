using AutoMapper;
using AutoMapper.QueryableExtensions;
using HotelListing.API.Contracts;
using HotelListing.API.Data;
using HotelListing.API.Exceptions;
using HotelListing.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly HotelListingDbContext _context;
        private readonly IMapper mapper;
        

  

        public GenericRepository(HotelListingDbContext context, IMapper mapper)
        {
            this._context = context;
            this.mapper = mapper;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entitiy = await GetAsync(id);

            if(entitiy  is null)
            {
                throw new NotFoundException(typeof(T).Name, id);
            }

            _context.Set<T>().Remove(entitiy);
            await _context.SaveChangesAsync();

        }

        public async Task<bool> Exists(int id)
        {
            var entitiy = await GetAsync(id);
            return entitiy != null;
        }

        public async Task<List<T>> GetAllsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<PagedResult<TResult>> GetAllAsync<TResult>(QueryParameters queryParameters)
        {
            var totalsize = await _context.Set<T>().CountAsync();
            var items = await _context.Set<T>()
                .Skip(queryParameters.StartIndex)
                .Take(queryParameters.PageSize)
                .ProjectTo<TResult>(mapper.ConfigurationProvider)
                .ToListAsync();

            return new PagedResult<TResult>
            {
                Items = items,
                PageNumber = queryParameters.PageNumber,
                RecordNumber = queryParameters.PageSize,
                TotalCount = totalsize
            };
        }

        public async Task<T> GetAsync(int? id)
        {
            if(id == null)
            {
                return null;
            }

            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<TResult?> GetAsync<TResult>(int? id)
        {
            if (id is null)
            {
                throw new NotFoundException(typeof(T).Name, id);
            }

            var result = await _context.Set<T>().FindAsync(id);
            return mapper.Map<TResult>(result);

        }

        public async Task<List<TResult>> GetAllsync<TResult>()
        {
            return await _context.Set<T>()
                .ProjectTo<TResult>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<TResult> AddAsync<TSource, TResult>(TSource source)
        {
            var entity = mapper.Map<T>(source);

            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return mapper.Map<TResult>(entity);
        }

        public async Task UpdateAsync<TSource>(int id, TSource source)
        {
            var entity = await GetAsync(id);

            if(entity == null)
            {
                throw new NotFoundException(typeof(T).Name, id);
            }

            mapper.Map(source, entity);
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
