namespace MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommand
{
    public class RemoveOrderDetailCommand
    {
        public int OrderDetailId { get; set; }

        public RemoveOrderDetailCommand(int orderDetailId)
        {
            OrderDetailId = orderDetailId;
        }
    }
}
