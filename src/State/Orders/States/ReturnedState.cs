using State.Abstractions;

namespace State.Orders.States;

public class ReturnedState : OrderState
{
    public override void Cancel()
        => Console.WriteLine("Pedido devolvido. Operação inválida!");

    public override void Deliver()
        => Console.WriteLine("Pedido devolvido. Operação inválida!");

    public override void ProcessPayment()
        => Console.WriteLine("Pedido devolvido. Operação inválida!");

    public override void RequestReturn()
        => Console.WriteLine("Devolução já processada!");

    public override void Ship(string trackingCode)
        => Console.WriteLine("Pedido devolvido. Operação inválida!");
}
