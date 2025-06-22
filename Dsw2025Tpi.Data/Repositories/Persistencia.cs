using Dsw2025Tpi.Domain.Entities;
using Dsw2025Tpi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Dsw2025Tpi.Data.Repositories;

public class Persistencia : IRepository
{
    private List<Product>? _products;
    private readonly DbContext _context;

    public Persistencia()
    {
        LoadProducts();
    }


    private void LoadProducts()
    {
        var json = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Sources\\products.json"));
        _products = JsonSerializer.Deserialize<List<Product>>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        });
    }

    private List<Product>? GetList<Product>() 
    {
        return _products as List<Product>;
    }

    public async Task<T> Add<T>(T entity) where T : EntityBase
    {
        GetList<T>()?.Add(entity);
        return await Task.FromResult(entity);
    }


    public async Task<T> Update<T>(T entity) where T : EntityBase
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
    //esto ultimo a modificar
    public Task<T?> GetById<T>(Guid id, params string[] include) where T : EntityBase
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>?> GetAll<T>(params string[] include) where T : EntityBase
    {
        throw new NotImplementedException();
    }

    public Task<T?> First<T>(Expression<Func<T, bool>> predicate, params string[] include) where T : EntityBase
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>?> GetFiltered<T>(Expression<Func<T, bool>> predicate, params string[] include) where T : EntityBase
    {
        throw new NotImplementedException();
    }

    public Task<T> Delete<T>(T entity) where T : EntityBase
    {
        throw new NotImplementedException();
    }
}
