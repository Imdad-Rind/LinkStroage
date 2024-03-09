using LinkStorage.Models;

namespace LinkStorage.Repository;

public interface ILinkRepository
{
    Task CreateLink(Links links);
    Task<Links> GetLinkById(Guid? id);
    Task<IEnumerable<Links>> GetAllLinks();
    Task DeleteLinkById(Guid id);
    Task<Links> UpdateLink(Links link);


}