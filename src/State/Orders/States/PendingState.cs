using State.Abstractions;

namespace State.Orders.States;

public class PendingState : OrderState
{
    public override void Cancel()
    {
        _context.TransitionTo(new CancelledState());
        Console.WriteLine("Pedido cancelado. Nenhuma cobrança realizada.");
    }

    public override void Deliver()
         => Console.WriteLine("Pedido ainda não foi enviado!");

    public override void ProcessPayment()
    {
        Console.WriteLine($"\n[{_context.OrderId}] Processando pagamento...");
        _context.TransitionTo(new PaidState());
        Console.WriteLine($"✅ Pagamento confirmado! Total: R$ {_context.TotalAmount:N2}");
    }

    public override void RequestReturn()
        => Console.WriteLine("Pedido ainda não foi entregue. Use cancelamento.");

    public override void Ship(string trackingCode)
        => Console.WriteLine($"Pedido [{_context.OrderId}] ainda não foi pago!");
}
