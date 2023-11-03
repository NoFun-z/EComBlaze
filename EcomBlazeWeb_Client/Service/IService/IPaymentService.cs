using EcomBlaze_Models;

namespace EcomBlazeWeb_Client.Service.IService
{
    public interface IPaymentService
    {
        public Task<SuccessModelDTO> Checkout(StripePaymentDTO model);

    }
}
