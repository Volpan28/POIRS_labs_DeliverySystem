namespace Delivery.Domain.Entities;

public class Route
{
    public Guid Id { get; private set; }
    public string StartAddress { get; private set; }
    public string EndAddress { get; private set; }
    public double EstimatedDistance { get; private set; }
    
    public Guid OrderId { get; private set; }

    public Route(string startAddress, string endAddress, double estimatedDistance, Guid orderId)
    {
        Id = Guid.NewGuid();
        StartAddress = startAddress;
        EndAddress = endAddress;
        EstimatedDistance = estimatedDistance;
        OrderId = orderId;
    }
}