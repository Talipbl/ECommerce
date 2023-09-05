using ECommerce.Core.Application;
using ECommerce.Systems;

namespace ECommerce.Xml
{
    public interface IXmlSchedulerService
    {
        IDataResult<GnlXmlScheduler> AddScheduler(GnlXmlScheduler scheduler);
        IResult UpdateScheduler(GnlXmlScheduler scheduler);
        IResult DeleteScheduler(int id);
        IListResult<GnlXmlScheduler> GetAllScheduler();
        IListResult<GnlXmlScheduler> GetSchedulers(int xmlId, int statusId = (int)StatusTypes.Active);
        IListResult<GnlXmlScheduler> GetScheduler(int schedulerId);

        #region Xml Scheduler Log
        IDataResult<GnlXmlSchedulerLog> AddSchedulerLog(GnlXmlSchedulerLog schedulerLog);
        IResult UpdateSchedulerLog(GnlXmlSchedulerLog schedulerLog);
        IResult DeleteSchedulerLog(int id);
        IListResult<GnlXmlSchedulerLog> GetAllSchedulerLogs();
        IListResult<GnlXmlSchedulerLog> GetSchedulerLogs(int xmlId, bool onlySuccess = false);
        #endregion
    }
}
