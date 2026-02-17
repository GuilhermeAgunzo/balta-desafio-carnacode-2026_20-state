using State.Abstractions;

namespace State.Orders.States;

public class CancelledState : OrderState
{
    public override void Cancel()
        => Console.WriteLine($"\n[{_context.OrderId}] Pedido já está cancelado.");

    public override void Deliver()
        => Console.WriteLine($"\n[{_context.OrderId}] Pedido cancelado não pode ser entregue.");


    public override void ProcessPayment()
        => Console.WriteLine($"\n[{_context.OrderId}] Pedido cancelado não pode processar pagamento.");


    public override void RequestReturn()
        => Console.WriteLine($"\n[{_context.OrderId}] Pedido cancelado não pode ser devolvido.");


    public override void Ship(string trackingCode)
        => Console.WriteLine($"\n[{_context.OrderId}] Pedido cancelado não pode ser enviado.");

}
