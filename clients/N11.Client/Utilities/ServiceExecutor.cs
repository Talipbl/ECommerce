using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N11.Client.Utilities
{
    public class ServiceExecutor
    {
        public async Task<TResponse> ExecuteAsync<TResponse>(Func<Task<TResponse>> action)
        {
            try
            {
                var result = await action();

                if (result == null)
                    throw new Exception("Service returned a null response.");

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
