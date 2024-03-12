using LinkStorage.Models;

namespace LinkStorage.Repository;

public interface ILinkRepository
{
    Task CreateLink(Links links);
    Task<Links> GetLinkById(Guid? id);
    Task<IEnumerable<Links>> GetAllLinks();
    Task<IEnumerable<Links>> GetAllPublicLinksAndTheirUsername();
    Task DeleteLinkById(Guid id);
    Task<Links> UpdateLink(Links link);
    Task<bool> IsLinkPresent(string url);
    Task<string> GetHtmlByUrl(string url);


}