namespace Solidarize.Application.Interfaces.Repositories;

public interface ICRUDRepositoryPattern<Domain>
{
    int Add(Domain domain);
    int AddRange(List<Domain> domains);
    Domain? GetOne(Guid id);
    List<Domain> GetByFilter(Func<Domain, bool> predicate);
    int Update(Domain domain);
    (int numberLinesModify, List<Domain> EntitiesNotFound) UpdateRange(List<Domain> domains);
    int Delete(Domain domain);
    (int numberLinesModify, List<Domain> EntitiesNotFound) DeleteRange(List<Domain> domains);
}
