using NetMQ;
using NetMQ.Sockets;

public class Program
{


    private static void Main(string[] args)
    {
        using(var responseSocket = new ResponseSocket("@tcp://*:5555") )
        {
            var message = responseSocket.ReceiveFrameString();  // J'attend de recevoir tes requettes.
            Console.WriteLine($"Message Received : {message}");
            responseSocket.SendFrame("Hello Back From Server");
            Console.ReadLine();
        }
    }
}