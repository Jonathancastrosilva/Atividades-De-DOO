using System;

public abstract class DocumentHandler
{
    protected DocumentHandler next;

    // Define o próximo handler na cadeia
    public DocumentHandler SetNext(DocumentHandler next)
    {
        this.next = next;
        return next;
    }

    // Método de processamento
    public void Handle(string documentType)
    {
        if (CanHandle(documentType))
        {
            Process(documentType);
        }
        else if (next != null)
        {
            next.Handle(documentType);
        }
        else
        {
            Console.WriteLine($"Cannot process {documentType}.");
        }
    }

    // Métodos abstratos para subclasses implementarem
    protected abstract bool CanHandle(string documentType);
    protected abstract void Process(string documentType);
}

public class InvoiceHandler : DocumentHandler
{
    protected override bool CanHandle(string documentType)
    {
        return documentType.Equals("Invoice", StringComparison.OrdinalIgnoreCase);
    }

    protected override void Process(string documentType)
    {
        Console.WriteLine("Processing Invoice...");
    }
}

public class ReceiptHandler : DocumentHandler
{
    protected override bool CanHandle(string documentType)
    {
        return documentType.Equals("Receipt", StringComparison.OrdinalIgnoreCase);
    }

    protected override void Process(string documentType)
    {
        Console.WriteLine("Processing Receipt...");
    }
}

public class BillHandler : DocumentHandler
{
    protected override bool CanHandle(string documentType)
    {
        return documentType.Equals("Bill", StringComparison.OrdinalIgnoreCase);
    }

    protected override void Process(string documentType)
    {
        Console.WriteLine("Processing Bill...");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Criando a cadeia de responsabilidade
        var handler = new InvoiceHandler();
        handler.SetNext(new ReceiptHandler()).SetNext(new BillHandler());

        // Processando diferentes tipos de documentos
        handler.Handle("Invoice");
        handler.Handle("Receipt");
        handler.Handle("Bill");
        handler.Handle("Unknown");
    }
}