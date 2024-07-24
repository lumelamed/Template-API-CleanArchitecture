namespace PlantillaMicroAPI.Domain.Abstractions
{
    public record Error(string code, string description)
    {
        private static Error none = new (string.Empty, string.Empty);

        private static Error valorNulo = new ("Error.ValorNulo", "Un valor nulo fue ingresado");

        public static Error None
        {
            get { return none; }
        }

        public static Error ValorNulo
        {
            get { return valorNulo; }
        }
    }
}
