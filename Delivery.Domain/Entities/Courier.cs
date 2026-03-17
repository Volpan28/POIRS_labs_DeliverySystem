using Delivery.Domain.Enums;

namespace Delivery.Domain.Entities;

public class Courier
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public TransportType TransportType { get; private set; }
    public bool IsActive { get; private set; }

    public Courier(string name, TransportType transportType)
    {
        Id = Guid.NewGuid();
        Name = name;
        TransportType = transportType;
        IsActive = false;
    }

    public void SetBusy()
    {
        IsActive = true;
    }

    public void SetAvailable()
    {
        IsActive = false;
    }
}