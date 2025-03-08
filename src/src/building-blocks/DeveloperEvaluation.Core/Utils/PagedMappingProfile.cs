

using AutoMapper;
using DeveloperEvaluation.Core.Data;
using DeveloperEvaluation.Core.Domain;
namespace DeveloperEvaluation.Core.Utils;
using AutoMapper;

public class PagedMappingProfile : Profile
{
    public PagedMappingProfile()
    {
        CreateMap(typeof(PagedDataResponse<>), typeof(PaginatedList<>))
            .ConvertUsing(typeof(PagedDataResponseConverter<,>));
    }
}

public class PagedDataResponseConverter<TSource, TDestination> :
    ITypeConverter<PagedDataResponse<TSource>, PaginatedList<TSource>>
{
    public PaginatedList<TSource> Convert(PagedDataResponse<TSource> source,
                                          PaginatedList<TSource> destination,
                                          ResolutionContext context)
    {
        return new PaginatedList<TSource>(
            source.Items,
            (int)source.TotalItens,
            source.Page,
            source.PageSize
        );
    }
}
