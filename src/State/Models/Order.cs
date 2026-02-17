using State.Abstractions;
using State.Orders.States;

namespace State.Models;

public class Order
{
    private OrderState _state;

    public string OrderId { get; set; }
    public decimal TotalAmount { get; set; }
    public string? TrackingCode { get; set; }
    public DateTime? ShippedDate { get; set; }
    public DateTime? DeliveredDate { get; set; }

    public Order(string orderId, decimal totalAmount)
    {
        OrderId = orderId;
        TotalAmount = totalAmount;

        _state = new PendingState();
        _state.SetContext(this);
    }

    public void ProcessPayment() => _state.ProcessPayment();
    public void Ship(string trackingCode) => _state.Ship(trackingCode);
    public void Deliver() => _state.Deliver();
    public void Cancel() => _state.Cancel();
    public void RequestReturn() => _state.RequestReturn();

    public void TransitionTo(OrderState state)
    {
        _state = state;
        _state.SetContext(this);
    }
}

