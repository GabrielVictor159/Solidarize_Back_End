using System.Linq;
using AutoMapper;
using Azure;
using Microsoft.EntityFrameworkCore;

namespace Solidarize.Infraestructure.Database.Repositories;

public abstract class CRUDRepositoryPattern<Domain, Entity> where Entity : class
{
    private readonly IMapper mapper;

    protected CRUDRepositoryPattern( IMapper mapper)
    {
        this.mapper = mapper;
    }

    public int Add(Domain domain)
    {
        using(var context = new Context())
        { 
        var entity = mapper.Map<Entity>(domain);
        context.Set<Entity>().Add(entity);
        return context.SaveChanges();
        }
    }

    public int AddRange(List<Domain> domains)
    {
        using(var context = new Context())
        { 
        var entities = mapper.Map<List<Entity>>(domains);
        context.Set<Entity>().AddRange(entities);
        return context.SaveChanges();
        }
    }

    public Domain? GetOne(Guid id)
    {
        using(var context = new Context())
        { 
        var entity = context.Set<Entity>().Find(id);
        return mapper.Map<Domain>(entity);
        }
    }

    public List<Domain> GetByFilter(Func<Domain, bool> predicate)
    {
        using(var context = new Context())
        { 
        var entities = context.Set<Entity>().ToList();
        var filteredEntities = entities.Where(entity => predicate(mapper.Map<Domain>(entity))).ToList();
        return filteredEntities.Select(entity => mapper.Map<Domain>(entity)).ToList();
        }
    }


    public int Update(Domain domain)
    {
        using(var context = new Context())
        { 
        var entity = mapper.Map<Entity>(domain);
        var existingEntity = context.Set<Entity>().Find(entity.GetType().GetProperty("Id")!.GetValue(entity));
        if (existingEntity != null)
        {
            context.Entry(existingEntity).CurrentValues.SetValues(entity);
            return context.SaveChanges();
        }
        return 0;
        }
    }

    public (int numberLinesModify, List<Domain> EntitiesNotFound) UpdateRange(List<Domain> domains)
    {
        using(var context = new Context())
        { 
        var entities = mapper.Map<List<Entity>>(domains);
        int result = 0;
        List<Entity> entitiesNotFound = new List<Entity>();
        foreach (var entity in entities)
        {
            var existingEntity = context.Set<Entity>().Find(entity.GetType().GetProperty("Id")!.GetValue(entity));
            if (existingEntity != null)
            {
                context.Entry(existingEntity).CurrentValues.SetValues(entity);
                result += context.SaveChanges();
            }
            else
            {
                entitiesNotFound.Add(entity);
            }
        }
        return (result, mapper.Map<List<Domain>>(entitiesNotFound));
        }
    }

    public int Delete(Domain domain)
    {
        using(var context = new Context())
        { 
        var entity = context.Set<Entity>().Find(domain!.GetType().GetProperty("Id")!.GetValue(domain));
        if (entity != null)
        {
            context.Set<Entity>().Remove(entity);
            return context.SaveChanges();
        }
        return 0;
        }
    }

    public (int numberLinesModify, List<Domain> EntitiesNotFound) DeleteRange(List<Domain> domains)
    {
        using(var context = new Context())
        { 
        var entities = mapper.Map<List<Entity>>(domains);
        int result = 0;
        List<Entity> entitiesNotFound = new List<Entity>();
        foreach (var entity in entities)
        {
            var entitySearch = context.Set<Entity>().Find(entity.GetType().GetProperty("Id")!.GetValue(entity));
            if (entitySearch != null)
            {
                context.Set<Entity>().Remove(entitySearch);
                result += context.SaveChanges();
            }
            else
            {
                entitiesNotFound.Add(entity);
            }
        }
        return (result, mapper.Map<List<Domain>>(entitiesNotFound));
        }
    }
}
