using System;
using System.Threading.Tasks;
using AkkaWorkerHost.Domain;

namespace AkkaWorkerHost
{
    public class UploadActor : WorkerActor
    {
        public UploadActor()
        {
            Receive<ShareContext>(_ =>
            {
                UpdateWorkflowStatus(WorkflowStatus.Sharing, "Beginning upload...");

                Console.WriteLine("Uploading {0} to {1}", _.ShareReferenceNo, _.DestinatonPath);

                Task.Delay(5000).Wait();

                Sender.Tell(new UploadCompletedMessage {Context = _}, Self);
            });
        }
    }
}