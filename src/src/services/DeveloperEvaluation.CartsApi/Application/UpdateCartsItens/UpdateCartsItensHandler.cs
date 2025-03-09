using AutoMapper;
using DeveloperEvaluation.CartsApi.Models;
using DeveloperEvaluation.Core.Data;
using MediatR;

namespace DeveloperEvaluation.CartsApi.Application.UpdateCartsItens
{
    public class UpdateProductsHandler : IRequestHandler<UpdateCartsItensUnitPriceCommand, UpdateCartsItensUnitPriceResult>
    {
        readonly IBaseRepository<Products> _productsRepository;
        readonly IBaseRepository<CartsItens>  _carItensRepository;
        readonly IMapper _mapper;
        readonly IMediator _mediator;

        public UpdateProductsHandler(IBaseRepository<Products> productsRepository,
                    IBaseRepository<CartsItens> carItensRepository,
                    IMapper mapper,
                    IMediator mediator)
        {
            _productsRepository = productsRepository;
            _carItensRepository = carItensRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<UpdateCartsItensUnitPriceResult> Handle(UpdateCartsItensUnitPriceCommand request, CancellationToken cancellationToken)
        {
            var product = (await _productsRepository.RepositoryConsult.SearchAsync(x => x.Id == request.ProductId)).FirstOrDefault();

            var result = new UpdateCartsItensUnitPriceResult();
            var caritens =  await _carItensRepository.RepositoryConsult.SearchAsync(x => x.ProductId == request.ProductId, cancellationToken);
             foreach (var item in caritens)
            {
                item.UnitPrices = item.UnitPrices;
            }
            await _productsRepository.UnitOfWork.CommitAsync();
            return result;
        }
    }
}
