using ECommerce.Application.Managers;

namespace ECommerce.Infrastructure.CrossCuttingConcerns
{
    public class DbLogManager : ILogManager // Burası değitirilecek
    {
        //ISystemService _systemSrv;
        //public DbLogManager(ISystemService systemSrv)
        //{
        //    _systemSrv = systemSrv;
        //}
        public void LogError(string methodName, string message)
        {
            //SysErrorLog errorLog = new SysErrorLog();
            //errorLog.MethodName = methodName;
            //errorLog.ErrorMessage = message;
            //errorLog.CreatedDate = DateTime.Now;

            //_systemSrv.LogError(errorLog);
        }
    }
}
