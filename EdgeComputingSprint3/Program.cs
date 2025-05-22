using System.IO.Ports;

class EdgeComputingSprint3
{
    static void Main()
    {
        string port_n = GetPort();

        using SerialPort port = new(port_n);
        port.BaudRate = 9600;
        port.Parity = Parity.None;
        port.DataBits = 8;
        port.StopBits = StopBits.One;

        try
        {
            port.Open();

            while (true) {
                string command = port.ReadLine();
                switch (command)
                {
                    case "Entry();":
                        Processor.Entry();
                    break;
                    case "Exit();":
                        Processor.Exit();
                    break;
                }
                if (command == "Drop();")
                    break;
                Console.Clear();
            }

            port.Close();
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"Erro ao acessar a porta serial: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro inesperado: {ex.Message}");
        }
    }
    class Processor
    {
        static DateTime[] Entrys = Array.Empty<DateTime>();
        static int atual,entradas,saidas = 0;

        static public void Entry()
        {
            Array.Resize(ref Entrys, Entrys.Length + 1);
            Entrys[Entrys.Length - 1] = DateTime.Now;
            entradas++;
            atual++;
        }

        static public void Exit()
        {
            if (Entrys.Length == 0)
            {
                Console.WriteLine("Não há entradas registradas.");
                return;
            }

            TimeSpan intervalo = DateTime.Now - Entrys[Entrys.Length - 1];
            Console.WriteLine($"Tempo decorrido: {intervalo}");
            saidas++;
            atual--;
        }
    }

    static public string GetPort()
    {
        string port = "";
        while (true)
        {
            Console.Clear();
            Console.Write("Porta do Arduino: ");
            port = Console.ReadLine();
            if (port.Contains("COM") && int.Parse(port.Split("M")[1]) >= 1) return port;
        }
    }
}