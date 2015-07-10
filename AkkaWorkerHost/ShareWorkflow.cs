using System;
using Akka.Actor;
using AkkaWorkerHost.Domain;

namespace AkkaWorkerHost
{
    public class ShareWorkflow : WorkerActor
    {
        public ShareWorkflow()
        {
            // initial state
            Become(Uploading);
        }

        
        private void Uploading()
        {
            Receive<UploadStartMessage>(_ =>
            {
                var uploadActor = Context.ActorOf(Props.Create(typeof(UploadActor)));

                uploadActor.Tell(_.Context, Self);

                // listen for WaitingForUpload
                Become(WaitingForUpload);
            });
        }

        private void WaitingForUpload()
        {
            Receive<UploadCompletedMessage>(_ =>
            {
                Console.WriteLine("Upload of {0} complete", _.Context.ShareReferenceNo);
                UpdateWorkflowStatus(WorkflowStatus.Shared, "Complete");
            });
        }
    }
}