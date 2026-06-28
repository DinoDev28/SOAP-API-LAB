using CoreWCF;
using CoreWCF.Configuration;
using MiniPaymentGatewayServer.Services;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5133); // Replace with your desired fixed port
});
builder.Services.AddServiceModelServices();

// -------------- MAIN APP BUILDING -------------------------- //
var app = builder.Build();

app.UseServiceModel(serviceBuilder =>
{
    serviceBuilder.AddService<PaymentService>();

    serviceBuilder.AddServiceEndpoint<PaymentService,
                                      IPaymentService>(
        new BasicHttpBinding(),
        "/PaymentService.svc");
});
// -------------------------------------------------------------------------------------------------------- //

// ---------- Port forwarding to replace localhost for a public address using ngrok ------------------ //
/*
 This code block assumes the machine that is running the server has already authenticated an ngrok valid token before attempting to run this application
 */
PortForwarder pf = new PortForwarder(); 

Process ngrokProcess = pf.NgrokForward(5133, NgrokMode.Visible);

// ----------------------------------------------------------//
// attach the ngrok process to the main application lifetime
// if app is closed, then close any ngrok process as well.
app.Lifetime.ApplicationStopping.Register(() => 
{
    try
    {
        Console.WriteLine("Stopping ngrok...");
        if (ngrokProcess != null && !ngrokProcess.HasExited)
            ngrokProcess.Kill(true); // kill entire process tree
            Console.WriteLine("Ngrok killed.");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
    }
});

// ----------------------------------------------------------------------------------------------------------------------------------//

app.Run();