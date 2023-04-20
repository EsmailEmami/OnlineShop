namespace OnlineShop.Domain.Core
{
    public interface IEntity<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
        DateTime CreateDate { get; }
        bool Deleted { get; set; }
    }
}