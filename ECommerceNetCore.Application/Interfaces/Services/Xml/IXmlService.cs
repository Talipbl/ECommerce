using ECommerce.Application.Utilities.Results.Abstracts;
using ECommerce.Domain.Common.Enumarations;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Interfaces.Services.Xml
{
    public interface IXmlService
    {
        #region Xml
        IDataResult<GnlProductXml> AddXml(GnlProductXml xml);
        IResult UpdateXml(GnlProductXml xml);
        IResult DeleteXml(int id);
        IListResult<GnlProductXml> GetAllXml();
        IListResult<GnlProductXml> GetXmls(string xmlLink = "", int statusId = (int)StatusTypes.All);
        IListResult<GnlProductXml> GetXml(int xmlId);
        #endregion

        #region Xml Scheduler
        IDataResult<GnlXmlScheduler> AddScheduler(GnlXmlScheduler scheduler);
        IResult UpdateScheduler(GnlXmlScheduler scheduler);
        IResult DeleteScheduler(int id);
        IListResult<GnlXmlScheduler> GetAllScheduler();
        IListResult<GnlXmlScheduler> GetSchedulers(int xmlId, int statusId = (int)StatusTypes.Active);
        IListResult<GnlXmlScheduler> GetScheduler(int schedulerId);
        #endregion

        #region Xml Scheduler Log
        IDataResult<GnlXmlSchedulerLog> AddSchedulerLog(GnlXmlSchedulerLog schedulerLog);
        IResult UpdateSchedulerLog(GnlXmlSchedulerLog schedulerLog);
        IResult DeleteSchedulerLog(int id);
        IListResult<GnlXmlSchedulerLog> GetAllSchedulerLogs();
        IListResult<GnlXmlSchedulerLog> GetSchedulerLogs(int xmlId, bool onlySuccess = false);
        #endregion
    }
}
