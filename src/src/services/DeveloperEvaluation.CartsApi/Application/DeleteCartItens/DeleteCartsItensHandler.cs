using AutoMapper;
using DeveloperEvaluation.CartsApi.Models;
using DeveloperEvaluation.Core.Data;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeveloperEvaluation.CartsApi.Application.DeleteCartItens
{
    public class DeleteCartsItensHandler : IRequestHandler<DeleteCartsItensCommand, DeleteCartsItensResult>
    {
        readonly IBaseRepository<Carts> _cartsRepository; 
        readonly IBaseRepository<CartsItens>  _cartsItensRepository;
        readonly IBaseRepository<Products> _productsRepository;
        readonly IMapper _mapper;

        public DeleteCartsItensHandler(IBaseRepository<Products> productsRepository,
            IBaseRepository<Carts> cartsRepository,
            IBaseRepository<CartsItens> cartsItensRepository,
            IMapper mapper)
        {
            _cartsRepository = cartsRepository;
            _mapper = mapper;
            _productsRepository = productsRepository;
            _cartsItensRepository = cartsItensRepository;
        }

        public async Task<DeleteCartsItensResult> Handle(DeleteCartsItensCommand command, CancellationToken cancellationToken)
        {
            var validator = new DeleteCartsItensValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            var cartsItens = await _cartsItensRepository.RepositoryConsult.SearchAsync(x => command.CartItensId.Contains(x.Id));

             _cartsItensRepository.RemoveRange(cartsItens);
            await _cartsItensRepository.UnitOfWork.CommitAsync();
            return new DeleteCartsItensResult();
        }

    }
}
