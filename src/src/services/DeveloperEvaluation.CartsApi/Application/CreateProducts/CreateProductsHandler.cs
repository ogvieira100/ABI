using AutoMapper;
using DeveloperEvaluation.CartsApi.Models;
using DeveloperEvaluation.Core.Data;
using FluentValidation;
using MediatR;

namespace DeveloperEvaluation.CartsApi.Application.CreateProducts
{
    public class CreateProductsHandler : IRequestHandler<CreateProductsCommand, CreateProductsResult>
    {
        readonly IBaseRepository<Products> _productsRepository;
        readonly IMapper _mapper;
        public CreateProductsHandler(IBaseRepository<Products> productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
        }
        public async Task<CreateProductsResult> Handle(CreateProductsCommand command,
                                                        CancellationToken cancellationToken)
        {
            var validator = new CreateProductsValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var productTitle = await _productsRepository.RepositoryConsult.SearchAsync(x => x.Title == command.Title, cancellationToken);
            if (productTitle != null && productTitle.Any())
                throw new InvalidOperationException($"Produto com o titulo {command.Title} já existe");


            var productAdd = _mapper.Map<Products>(command);
            await _productsRepository.AddAsync(productAdd);
            await _productsRepository.UnitOfWork.CommitAsync();

            var result = _mapper.Map<CreateProductsResult>(productAdd);
            return result;
        }
    }
}
