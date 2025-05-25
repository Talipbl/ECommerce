using Ecommerce.Shared.Utilities.Results;

namespace ECommerce.Xml;

public class XmlSchedulerService : IXmlSchedulerService
{
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
}
