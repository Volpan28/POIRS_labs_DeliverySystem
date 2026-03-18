using Delivery.Domain.Enums;

namespace Delivery.Domain.Entities;

public class Order
{
    public Guid Id { get; private set; }
    public string Description { get; private set; }
    public double Weight { get; private set; }
    public decimal Price { get; private set; }
    public DeliveryStatus Status { get; private set; }
    
    public Guid ClientId { get; private set; }
    public Guid? CourierId { get; private set; }

    public Order(string description, double weight, decimal price, Guid  clientId)
    {
        Id = Guid.NewGuid();
        Description = description;
        Weight = weight;
        Price = price;
        ClientId = clientId;
        Status = DeliveryStatus.Created;
    }

    public void AssignCourier(Guid courierId)
    {
        CourierId = courierId;
        Status = DeliveryStatus.Assigned;
    }
    
    public void SetInTransit()
    {
        Status = DeliveryStatus.InTransit;
    }

    public void CompleteDelivery()
    {
        Status = DeliveryStatus.Delivered;
    }

    public void CancelOrder()
    {
        Status = DeliveryStatus.Cancelled;
    }
}