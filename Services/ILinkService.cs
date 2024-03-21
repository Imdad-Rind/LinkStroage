using LinkStorage.Models;

namespace LinkStorage.Services;

public interface ILinkService
{
    Task CreateNewLink(Links l);
    Task<Links> GetLinkById(Guid? id);
    Task<IEnumerable<Links>> GetAllTheLinks();

    Task<string> GetHtmlIfExist(string url);
    Task<IEnumerable<Links>> GetPublicLinks();
    Task<IEnumerable<Links>> GetAllPublicLinksById(Guid? id);
    Task<IEnumerable<Links>> AllTheLinksByUserId(Guid id);
    Task<IEnumerable<Links>> GetAllThePublicLinksOfUserYouFollowingByYourId(Guid? yourUserId);
    Task<Links> UpdateTheLinkBuyId(Guid id,Links link);
    Task RemoveLinkFormDbById(Guid id);

}