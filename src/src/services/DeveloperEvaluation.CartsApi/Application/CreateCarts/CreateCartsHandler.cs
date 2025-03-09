using AutoMapper;
using DeveloperEvaluation.CartsApi.Models;
using DeveloperEvaluation.Core.Data;
using FluentValidation;
using MediatR;

namespace DeveloperEvaluation.CartsApi.Application.CreateCarts
{
    public class CreateCartsHandler : IRequestHandler<CreateCartsCommand, CreateCartsResult>
    {
        readonly IBaseRepository<Carts>  _cartsRepository;
        readonly IMapper _mapper;
        public CreateCartsHandler(IBaseRepository<Carts> cartsRepository, IMapper mapper)
        {
            _cartsRepository = cartsRepository;
            _mapper = mapper;
        }

        public async Task<CreateCartsResult> Handle(CreateCartsCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateCartsValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var cartCreated = (await _cartsRepository
                                      .RepositoryConsult
                                      .SearchAsync(x => x.StatusCartsEn == StatusCartsEn.NotCanceled
                                       && x.UserIdInsert == command.UserIdInsert))?.FirstOrDefault();
            if (cartCreated != null)
                throw new InvalidOperationException($"Carrinho já criado só pode ser alterado ");

            var carAdd  =  _mapper.Map<Carts>(command);

            await _cartsRepository.AddAsync(carAdd, cancellationToken);
            await _cartsRepository.UnitOfWork.CommitAsync();
            return _mapper.Map<CreateCartsResult>(carAdd);
        }
       
    }
}
