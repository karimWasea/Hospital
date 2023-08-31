namespace hospitalUtilities
{
    public class PagedREsult<T> where T : class

    {

        public List<T> Data { get; set; }
        public int TotalItens { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }









        public PagedREsult()
        {

        }
    }
}