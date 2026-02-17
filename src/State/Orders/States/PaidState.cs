using State.Abstractions;

namespace State.Orders.States;

public class PaidState : OrderState
{
    public override void Cancel()
    {
        Console.WriteLine($"Pedido cancelado. Reembolso de R$ {_context.TotalAmount:N2} será processado.");
        _context.TransitionTo(new CancelledState());
    }

    public override void Deliver() => Console.WriteLine("Pedido ainda não foi enviado!");

    public override void ProcessPayment() => Console.WriteLine("Pedido já foi pago!");

    public override void RequestReturn() => Console.WriteLine("Pedido ainda não foi entregue. Use cancelamento.");

    public override void Ship(string trackingCode)
    {
        _context.TrackingCode = trackingCode;
        _context.ShippedDate = DateTime.Now;
        Console.WriteLine($"Pedido enviado! Rastreamento: {trackingCode}");
        _context.TransitionTo(new ShippedState());
    }
}
