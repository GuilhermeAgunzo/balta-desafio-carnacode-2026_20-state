using State.Abstractions;

namespace State.Orders.States;

public class ShippedState : OrderState
{
    public override void Cancel()
        => Console.WriteLine("Pedido já enviado. Use processo de devolução.");

    public override void Deliver()
    {
        _context.DeliveredDate = DateTime.Now;
        Console.WriteLine($"Pedido entregue! Data: {_context.DeliveredDate:dd/MM/yyyy HH:mm}");
        _context.TransitionTo(new DeliveredState());
    }

    public override void ProcessPayment()
        => Console.WriteLine("Pedido já foi pago!");

    public override void RequestReturn()
        => Console.WriteLine("Aguarde a entrega para solicitar devolução.");

    public override void Ship(string trackingCode)
        => Console.WriteLine($"Pedido já foi enviado em {_context.ShippedDate:dd/MM/yyyy}!");
}
