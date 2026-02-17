using State.Abstractions;

namespace State.Orders.States;

public class DeliveredState : OrderState
{
    public override void Cancel()
        => Console.WriteLine("Pedido já entregue. Solicite devolução se necessário.");

    public override void Deliver()
        => Console.WriteLine($"Pedido já foi entregue em {_context.DeliveredDate:dd/MM/yyyy}!");

    public override void ProcessPayment()
        => Console.WriteLine("Pedido já foi pago!");

    public override void RequestReturn()
    {
        var days = (DateTime.Now - _context.DeliveredDate!.Value).Days;

        if (days <= 7)
        {
            Console.WriteLine($"Devolução aprovada! Reembolso: R$ {_context.TotalAmount:N2}");
            _context.TransitionTo(new ReturnedState());
        }
        else
            Console.WriteLine($"Prazo de devolução expirado ({days} dias)!");
    }

    public override void Ship(string trackingCode)
        => Console.WriteLine("Pedido já foi entregue!");
}
