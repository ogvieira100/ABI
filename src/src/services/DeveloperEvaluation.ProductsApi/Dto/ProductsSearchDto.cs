namespace DeveloperEvaluation.ProductsApi.Dto
{
    public class ProductsSearchDto
    {
        public Guid Id { get; set; }
        public string? Titulo { get; set; }

        public decimal? Valor { get; set; }

        public string? Descricao { get; set; }

        public string? Categoria { get; set; }

        public string? Imagem { get; set; }

        public decimal? Rate { get; set; }
        public int? Contador { get; set; }
    }
}

