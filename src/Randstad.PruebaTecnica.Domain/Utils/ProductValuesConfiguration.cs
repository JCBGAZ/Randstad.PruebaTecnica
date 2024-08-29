namespace Randstad.PruebaTecnica.Domain.Utils
{
    public static class ProductValuesConfiguration
    {
        public static int NameMaximumLength { get; private set; } = 80;
        public static int DescriptionMaximumLength { get; private set; } = 200;
        public static int PriceGreaterThan { get; private set; } = 0;
        public static int StockGreaterThanOrEqualTo { get; private set; } = 0;
        public static int ProductGreaterThan { get; private set; } = 0;
    }
}
