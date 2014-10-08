namespace Json.Contracts
{
    public interface IArticle
    {
        string Title { get; set; }

        string Link { get; set; }

        string Category { get; set; }
    }
}