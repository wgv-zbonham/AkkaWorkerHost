using System;
using Akka.Actor;
using AkkaWorkerHost.Domain;


namespace AkkaWorkerHost
{
    public class ShareMessage
    {
        public ShareContext Context { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("workerhost");
            var export = system.ActorOf<ShareWorkflow>("share");

            var context = new ShareContext()
            {
                OrganizationdId = Guid.NewGuid(),
                SasKey = "a;lkjas;ldfjasdf==",
                ShareReferenceNo = "100-123XYX",
                SourcePath = @"c:\source",
                DestinatonPath = @"c:\destination"
            };

            var message = new UploadStartMessage
            {
                Context = context
            };

            export.Tell( message );

            Console.ReadLine();
        }
    }
}
