using LearnTop.Modules.Academy.Domain.Academy.Errors;
using LearnTop.Modules.Academy.Domain.Academy.Events;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Academy.Domain.Academy.Models;

public class Academy : Aggregate
{
    private readonly List<AcademyInfo> _academyInfos = [];
    private readonly List<Banner> _banners = [];
    private readonly List<ContactUs> _contactUses = [];
    public IReadOnlyList<AcademyInfo> AcademyInfos => [.. _academyInfos];
    public IReadOnlyList<Banner> Banners => [.. _banners];
    public IReadOnlyList<ContactUs> ContactUses => [.. _contactUses];

    #region Info
    
    public void AddInfo(AcademyInfo info)
    {
        _academyInfos.Add(info);
        AddDomainEvent(new AcademyInfoCreatedEvent(info));
    }
    
    public Result RemoveInfo(AcademyInfo academyInfo)
    {
        bool isExist = _academyInfos.Exists(a => a.Id == academyInfo.Id);
        if (!isExist)
        {
            return Result.Failure(AcademyInfoErrors.NotFound(academyInfo.Id));
        }
        _academyInfos.Remove(academyInfo);
        return Result.Success();
    }

    #endregion

    #region Banner

    public void AddBanner(Banner banner)
    {
        _banners.Add(banner);
        AddDomainEvent(new BannerCreatedEvent(banner));
    }
    public Result RemoveBanner(Banner banner)
    {
        Banner? bannerEntity = _banners.Find(b => b.Id == banner.Id);
        if (bannerEntity is null)
        {
            return Result.Failure(BannerErrors.NotFound(banner.Id));
        }
        _banners.Remove(banner);
        return Result.Success();
    }

    #endregion
    
    #region ContactUs

    public void AddContactUs(ContactUs contactUs)
    {
        _contactUses.Add(contactUs);
        AddDomainEvent(new ContactUsCreatedEvent(contactUs));
    }
    public Result RemoveContactUs(ContactUs contactUs)
    {
        bool isExist = _contactUses.Exists(c => c.Id == contactUs.Id);
        if (!isExist)
        {
            return Result.Failure(ContactUsErrors.NotFound(contactUs.Id));
        }
        _contactUses.Remove(contactUs);
        return Result.Success();
    }

    #endregion
}
