using EcomBlaze_Models;

namespace EcomBlazeWeb_Client.Service.IService
{
    public interface IOrderService
    {
        public Task<IEnumerable<OrderDTO>> GetAll(string? userId);
        public Task<OrderDTO> Get(int orderId);

        //public Task<OrderDTO> Create(StripePaymentDTO paymentDTO);

        public Task<OrderHeaderDTO> MarkPaymentSuccessful(OrderHeaderDTO orderHeader);
    }
}
