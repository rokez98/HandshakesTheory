namespace HandshakesTheory.Vk.Interfaces
{
    public interface IUser
    {
        long Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string PhotoUrl { get; set; }
    }
}
