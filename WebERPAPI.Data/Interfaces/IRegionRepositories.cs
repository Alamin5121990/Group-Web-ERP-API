using System.Collections.Generic;
using WebERPAPI.Data.Models.MIS;

namespace WebERPAPI.Data.Repository
{
    public interface IRegionRepositories
    {
        List<RegionMaster> getAllRegionList();

        List<RegionMaster> getRegionList(string ZoneId);
    }
}