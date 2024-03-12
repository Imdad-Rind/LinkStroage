using LinkStorage.Models;

namespace LinkStorage.Services;

public interface ILinkService
{
    Task CreateNewLink(Links l);
    Task<Links> GetLinkById(Guid? id);
    Task<IEnumerable<Links>> GetAllTheLinks();

    Task<string> GetHtmlIfExist(string url);
    Task<IEnumerable<Links>> GetPublicLinks();
    
    Task<Links> UpdateTheLinkBuyId(Guid id,Links link);
    Task RemoveLinkFormDbById(Guid id);

}