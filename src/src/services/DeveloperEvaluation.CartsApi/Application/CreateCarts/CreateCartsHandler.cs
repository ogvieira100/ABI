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
        readonly IBaseRepository<Products> _productsRepository;
        readonly IMapper _mapper;
        const int minDiscountDezPorcent = 4;
        const int maxDiscountDezPorcent = 9;
        const int minDiscountVintePorcent = 10;
        const int maxDiscountVintePorcent = 20;
        const int maxItens = 20;
        public CreateCartsHandler(IBaseRepository<Products> productsRepository, IBaseRepository<Carts> cartsRepository, IMapper mapper)
        {
            _cartsRepository = cartsRepository;
            _mapper = mapper;
            _productsRepository = productsRepository;
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

            var productsId = carAdd.CreateCardItens.Select(x => x.ProductId);

            var products =  await _productsRepository.RepositoryConsult.SearchAsync(x => productsId.Contains(x.Id));
            if(products.Count()!= productsId.Count())
                throw new InvalidOperationException($"Atenção existem códigos de produtos inválidos!!!!");

            if (carAdd.CreateCardItens.Any(x=>x.Quantity > maxItens))
                throw new InvalidOperationException(@$"
                        Atenção quantidade máxima de itens de compra é de {maxItens} produtos {string.Join(",", carAdd.CreateCardItens.Where(x => x.Quantity > maxItens))} excedem o limite de compras ");
            
            /*atualizando os valores unitarios das compras*/
            foreach (var cartitens in carAdd.CreateCardItens)
            {
                var product = products.FirstOrDefault(x => x.Id == cartitens.ProductId);
                if (product != null)
                    cartitens.UnitPrices = product.Price;
            }

            var itensDescont10 = carAdd.CreateCardItens.Where(x => x.Quantity >= minDiscountDezPorcent && x.Quantity <= maxDiscountDezPorcent).ToList();
            var itensDescont20 = carAdd.CreateCardItens.Where(x => x.Quantity >= minDiscountVintePorcent && x.Quantity <= maxDiscountVintePorcent).ToList();
            foreach (var item in itensDescont10)
            {
                item.Discounts = 10m;
                
            }
            foreach (var item in itensDescont20)
            {
                item.Discounts = 20m;
            }

            await _cartsRepository.AddAsync(carAdd, cancellationToken);
            await _cartsRepository.UnitOfWork.CommitAsync();
            return _mapper.Map<CreateCartsResult>(carAdd);
        }
       
    }
}
