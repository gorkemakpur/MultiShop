using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommand;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class RemoveOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public RemoveOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveOrderDetailCommand query)
        {
            var value = await _repository.GetByIdAsync(query.OrderDetailId);
            await _repository.DeleteAsync(value);
        }
    }
}

