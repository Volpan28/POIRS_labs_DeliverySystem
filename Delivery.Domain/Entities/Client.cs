namespace Delivery.Domain.Entities;

public class Client
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Phone { get; private set; }
    public string Email { get; private set; }

    public Client(string name, string phone, string email)
    {
        Id = Guid.NewGuid();
        Name = name;
        Phone = phone;
        Email = email;
    }
}