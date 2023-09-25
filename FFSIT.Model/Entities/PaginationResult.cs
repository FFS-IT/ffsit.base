namespace FFSIT.Model.Entities
{
    public class PaginationResult<T> where T : BaseEntity
    {
        public int Page { get; private set; }

        public int QuantityPerPage { get; private set; }

        public int TotalPages { get; private set; }

        public int TotalQuantity { get; private set; }

        public IEnumerable<T> Data { get; private set; }

        public PaginationResult(IEnumerable<T> data, int page, int quantityPerPage, int totalQuantity)
        {
            Page = page;
            QuantityPerPage = quantityPerPage;
            TotalPages = (int)Math.Ceiling((double)totalQuantity / quantityPerPage);
            TotalQuantity = totalQuantity;
            Data = data;
        }
    }
}
