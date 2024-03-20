using LinkStorage.Models;
using LinkStorage.Repository;

namespace LinkStorage.Services.ServicesImpl;

public class  LinkServiceImpl : ILinkService
{
    
    /*  service class for links system
 */    
    private readonly ILinkRepository _repo;

    public LinkServiceImpl(ILinkRepository repo)
    {
       this._repo = repo;
    }

    public async Task CreateNewLink(Links l)
    {
      await _repo.CreateLink(l);
    }

    public async Task<Links> GetLinkById(Guid? id)
    {
        return await _repo.GetLinkById(id);
    }

    public async Task<IEnumerable<Links>> GetAllTheLinks()
    {
        return await _repo.GetAllLinks();
    }

    public async Task<string> GetHtmlIfExist(string url)
    {
        return await _repo.GetHtmlByUrl(url);
    }

    public Task<IEnumerable<Links>> GetPublicLinks()
    {
        return _repo.GetAllPublicLinksAndTheirUsername();
    }

    public async Task<IEnumerable<Links>> GetAllPublicLinksById(Guid? id)
    {
        return await _repo.GetAllPublicLinksAndTheirUsernameById(id);
    }

    public async Task<IEnumerable<Links>> AllTheLinksByUserId(Guid id)
    {
        return await _repo.GetAllTheLinksByUserId(id);
    }

    public async Task<Links> UpdateTheLinkBuyId(Guid id,Links link)
    {
        var existingLink = await _repo.GetLinkById(id);

        existingLink.Link = link.Link;
        existingLink.Site = link.Site;
        existingLink.IsPublic = link.IsPublic;

        await _repo.UpdateLink(existingLink);
        return existingLink;
    }

    public async Task RemoveLinkFormDbById(Guid id)
    {
        await _repo.DeleteLinkById(id);
    }
}