using N11.Client.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N11.Client.Utilities
{
    public class ServiceExecutor
    {
        public async Task<BaseResponse<TResponse, TApiResponse>> ExecuteAsync<TResponse, TApiResponse>(Func<Task<TApiResponse>> action)
        {
            try
            {
                var result = await action();

                if (result == null)
                    throw new Exception("Service returned a null response.");

                var @dynamic = result as dynamic;

                var clientResponse = new BaseClientResponse<TResponse>()
                {
                    Status = @dynamic.result.status == "success",
                    ErrorCode = @dynamic.result.errorCode,
                    ErrorMessage = @dynamic.result.errorMessage
                };

                var resultObj = result as object;
                var paging = resultObj.GetPropertyOrDefault("pagingData");
                if (paging != null)
                {
                    clientResponse.Pagination = new PagingData()
                    {
                        CurrentPage = paging.currentPage,
                        PageCount = paging.pageCount,
                        PageSize = paging.pageSize,
                        TotalCount = paging.totalCount
                    };
                }

                var response =  new BaseResponse<TResponse, TApiResponse>()
                {
                    ApiResponse = result,
                    ClientResponse = clientResponse
                };

                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
