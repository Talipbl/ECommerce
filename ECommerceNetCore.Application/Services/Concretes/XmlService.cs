using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Application.Results;
using ECommerceNetCore.Domain.Entities;

namespace ECommerceNetCore.Application.Services
{
    public class XmlService : IXmlService
    {
        #region Xml
        public IDataResult<GnlProductXml> AddXml(GnlProductXml xml)
        {
            throw new NotImplementedException();
        }

        public IResult DeleteXml(int id)
        {
            throw new NotImplementedException();
        }

        public IListResult<GnlProductXml> GetAllXml()
        {
            throw new NotImplementedException();
        }

        public IListResult<GnlProductXml> GetXml(int xmlId)
        {
            throw new NotImplementedException();
        }

        public IListResult<GnlProductXml> GetXmls(string xmlLink = "", int statusId = 0)
        {
            throw new NotImplementedException();
        }

        public IResult UpdateXml(GnlProductXml xml)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Scheduler
        public IDataResult<GnlXmlScheduler> AddScheduler(GnlXmlScheduler scheduler)
        {
            throw new NotImplementedException();
        }

        public IResult DeleteScheduler(int id)
        {
            throw new NotImplementedException();
        }

        public IListResult<GnlXmlScheduler> GetAllScheduler()
        {
            throw new NotImplementedException();
        }

        public IListResult<GnlXmlScheduler> GetScheduler(int schedulerId)
        {
            throw new NotImplementedException();
        }

        public IListResult<GnlXmlScheduler> GetSchedulers(int xmlId, int statusId = 1)
        {
            throw new NotImplementedException();
        }

        public IResult UpdateScheduler(GnlXmlScheduler scheduler)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Log
        public IDataResult<GnlXmlSchedulerLog> AddSchedulerLog(GnlXmlSchedulerLog schedulerLog)
        {
            throw new NotImplementedException();
        }

        public IResult DeleteSchedulerLog(int id)
        {
            throw new NotImplementedException();
        }

        public IListResult<GnlXmlSchedulerLog> GetAllSchedulerLogs()
        {
            throw new NotImplementedException();
        }

        public IListResult<GnlXmlSchedulerLog> GetSchedulerLogs(int xmlId, bool onlySuccess = false)
        {
            throw new NotImplementedException();
        }

        public IResult UpdateSchedulerLog(GnlXmlSchedulerLog schedulerLog)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
