using N11.Client.Services.OrderService;
using N11.Client.Utilities;

namespace N11.Client
{
    public class N11OrderClient
    {
        private readonly OrderServicePortClient _client;
        private readonly ServiceExecutor _serviceExecutor;
        private readonly Authentication _auth;

        private readonly Uri URL = new("https://api.n11.com/ws/OrderService.wsdl");

        public N11OrderClient(string appKey, string appSecretKey)
        {
            _auth = new()
            {
                appKey = appKey,
                appSecret = appSecretKey
            };

            _client = new BaseClient<OrderServicePortClient, OrderServicePort>(URL).GetClient();
            _serviceExecutor = new ServiceExecutor();
        }

        public async Task<ClientResponse<OrderData[]>> GetOrderList(OrderDataListRequest search, int currentPage = 0, int pageSize = 100)
        {
            OrderListRequest request = new()
            {
                auth = _auth,
                searchData = search,
                pagingData = new()
                {
                    currentPage = currentPage,
                    pageSize = pageSize
                }
            };

            var response = await _serviceExecutor.ExecuteAsync<OrderData[], OrderListResponse>(async () =>
            {
                var result = await _client.OrderListAsync(request);
                return result.OrderListResponse;
            });

            response.ClientResponse.Data = response.ApiResponse.orderList;
            return response.ClientResponse;
        }

        public async Task<ClientResponse<DetailedOrderData[]>> GetDetailedOrderList(OrderDataListRequest search, int currentPage = 0, int pageSize = 100)
        {
            DetailedOrderListRequest request = new()
            {
                auth = _auth,
                searchData = search,
                pagingData = new()
                {
                    currentPage = currentPage,
                    pageSize = pageSize
                }
            };

            var response = await _serviceExecutor.ExecuteAsync<DetailedOrderData[], DetailedOrderListResponse>(async () =>
            {
                var result = await _client.DetailedOrderListAsync(request);
                return result.DetailedOrderListResponse;
            });

            response.ClientResponse.Data = response.ApiResponse.orderList;
            return response.ClientResponse;
        }

        public async Task<ClientResponse<OrderDetailData>> GetOrderDetail(int orderId)
        {
            OrderDetailRequest request = new()
            {
                auth = _auth,
                orderRequest = new()
                {
                    id = orderId
                }
            };

            var response = await _serviceExecutor.ExecuteAsync<OrderDetailData, OrderDetailResponse>(async () =>
            {
                var result = await _client.OrderDetailAsync(request);
                return result.OrderDetailResponse;
            });

            response.ClientResponse.Data = response.ApiResponse.orderDetail;
            return response.ClientResponse;
        }

        public async Task<ClientResponse<OrderItemData[]>> ApproveOrderItems(long[] orderIds, int numberOfPackage = 1)
        {
            if (orderIds.Length < 1 || orderIds is null)
            {
                return new ClientResponse<OrderItemData[]>()
                {
                    Status = false,
                    ErrorMessage = "orderIds can not be empty!"
                };
            }

            OrderItemDataRequest[] orderItems = new OrderItemDataRequest[orderIds.Length];
            for (int i = 0; i < orderIds.Length; i++)
            {
                OrderItemDataRequest item = new OrderItemDataRequest()
                {
                    id = orderIds[i]
                };
                orderItems[i] = item;
            }

            OrderItemAcceptRequest request = new()
            {
                auth = _auth,
                numberOfPackages = numberOfPackage.ToString(),
                orderItemList = orderItems
            };

            var response = await _serviceExecutor.ExecuteAsync<OrderItemData[], OrderItemAcceptResponse>(async () =>
            {
                var result = await _client.OrderItemAcceptAsync(request);
                return result.OrderItemAcceptResponse;
            });

            response.ClientResponse.Data = response.ApiResponse.orderItemList;
            return response.ClientResponse;
        }

        public async Task<ClientResponse<OrderItemData[]>> RejectOrderItems(long[] orderIds, string reason, string rejectType)
        {
            if (orderIds.Length < 1 || orderIds is null)
            {
                return new ClientResponse<OrderItemData[]>()
                {
                    Status = false,
                    ErrorMessage = "orderIds can not be empty!"
                };
            }

            OrderItemDataRequest[] orderItems = new OrderItemDataRequest[orderIds.Length];
            for (int i = 0; i < orderIds.Length; i++)
            {
                OrderItemDataRequest item = new OrderItemDataRequest()
                {
                    id = orderIds[i]
                };
                orderItems[i] = item;
            }

            OrderItemRejectRequest request = new()
            {
                auth = _auth,
                orderItemList = orderItems,
                rejectReason = reason,
                rejectReasonType = rejectType
            };

            var response = await _serviceExecutor.ExecuteAsync<OrderItemData[], OrderItemRejectResponse>(async () =>
            {
                var result = await _client.OrderItemRejectAsync(request);
                return result.OrderItemRejectResponse;
            });

            response.ClientResponse.Data = response.ApiResponse.orderItemList;
            return response.ClientResponse;
        }

        public async Task<ClientResponse<OrderItemData[]>> MakeOrderItemShipment(OrderItemShipmentRequest[] orderItems)
        {
            MakeOrderItemShipmentRequest request = new()
            {
                auth = _auth,
                orderItemList = orderItems
            };

            var response = await _serviceExecutor.ExecuteAsync<OrderItemData[], MakeOrderItemShipmentResponse>(async () =>
            {
                var result = await _client.MakeOrderItemShipmentAsync(request);
                return result.MakeOrderItemShipmentResponse;
            });

            response.ClientResponse.Data = response.ApiResponse.orderItemList;
            return response.ClientResponse;
        }

        public async Task<BaseClientResponse> CombineOrderItems(long[] orderIds)
        {
            if (orderIds.Length < 1 || orderIds is null)
            {
                return new ClientResponse<OrderItemData[]>()
                {
                    Status = false,
                    ErrorMessage = "orderIds can not be empty!"
                };
            }

            OrderItemDataRequest[] orderItems = new OrderItemDataRequest[orderIds.Length];
            for (int i = 0; i < orderIds.Length; i++)
            {
                OrderItemDataRequest item = new OrderItemDataRequest()
                {
                    id = orderIds[i]
                };
                orderItems[i] = item;
            }

            CombineItemsRequest request = new()
            {
                auth = _auth,
                orderItemList = orderItems
            };

            var response = await _serviceExecutor.ExecuteAsync(async () =>
            {
                var result = await _client.CombineItemsAsync(request);
                return result.CombineItemsResponse;
            });

            return response.ClientResponse;
        }

        public async Task<BaseClientResponse> SeperateCombinedOrderItems(long[] orderIds)
        {
            if (orderIds.Length < 1 || orderIds is null)
            {
                return new ClientResponse<OrderItemData[]>()
                {
                    Status = false,
                    ErrorMessage = "orderIds can not be empty!"
                };
            }

            OrderItemDataRequest[] orderItems = new OrderItemDataRequest[orderIds.Length];
            for (int i = 0; i < orderIds.Length; i++)
            {
                OrderItemDataRequest item = new OrderItemDataRequest()
                {
                    id = orderIds[i]
                };
                orderItems[i] = item;
            }

            SeparateCombinedItemsRequest request = new()
            {
                auth = _auth,
                orderItemList = orderItems
            };

            var response = await _serviceExecutor.ExecuteAsync(async () =>
            {
                var result = await _client.SeparateCombinedItemsAsync(request);
                return result.SeparateCombinedItemsResponse;
            });

            return response.ClientResponse;
        }

        public async Task<BaseClientResponse> DeliverOrderItemShipment(int id, int companyId, string shipmentMethod, DateTime deliveryTime)
        {
            OrderItemDeliveryRequest request = new()
            {
                auth = _auth,
                orderItemList = new OrderItemListRequest() { orderItemId = id },
                shipmentCompanyId = companyId,
                shipmentMethod = shipmentMethod,
                deliveryTime = deliveryTime.ToShortDateString()
            };

            var response = await _serviceExecutor.ExecuteAsync(async () =>
            {
                var result = await _client.OrderItemDeliveryAsync(request);
                return result.OrderItemDeliveryResponse;
            });

            return response.ClientResponse;
        }
    }
}
