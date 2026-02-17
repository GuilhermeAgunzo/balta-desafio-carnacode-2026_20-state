using State.Models;

namespace State.Abstractions;

public abstract class OrderState
{
    protected Order _context;

    public void SetContext(Order context)
    {
        _context = context;
    }

    public abstract void ProcessPayment();
    public abstract void Ship(string trackingCode);
    public abstract void Deliver();
    public abstract void Cancel();
    public abstract void RequestReturn();
}
