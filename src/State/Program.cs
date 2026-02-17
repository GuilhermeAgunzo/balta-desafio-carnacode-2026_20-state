// DESAFIO: Sistema de Pedido de E-commerce com Estados
// PROBLEMA: Um pedido passa por múltiplos estados (Pendente, Pago, Enviado, Entregue, Cancelado)
// e cada estado permite operações diferentes. O código atual usa condicionais gigantes que
// verificam o estado atual antes de cada operação, tornando difícil adicionar novos estados

// Contexto: Sistema de e-commerce onde pedidos passam por ciclo de vida complexo
// Cada estado tem regras específicas sobre quais operações são permitidas

using State.Models;

Console.WriteLine("=== Sistema de Gerenciamento de Pedidos ===");

var order1 = new Order("ORD-001", 250.00m);
Console.WriteLine($"\n=== Pedido {order1.OrderId} criado ===");

// Fluxo normal
order1.ProcessPayment();
order1.Ship("BR123456789");
order1.Deliver();
order1.RequestReturn();

Console.WriteLine("\n" + new string('=', 60));

var order2 = new Order("ORD-002", 150.00m);
Console.WriteLine($"\n=== Pedido {order2.OrderId} criado ===");

// Tentativas inválidas
order2.Ship("BR987654321");  // Não pago ainda
order2.ProcessPayment();
order2.ProcessPayment();     // Já pago
order2.Cancel();             // Cancelar após pagamento