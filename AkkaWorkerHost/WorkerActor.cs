using Akka.Actor;
using AkkaWorkerHost.Domain;

namespace AkkaWorkerHost
{
    public abstract class WorkerActor : ReceiveActor
    {
        protected virtual void  UpdateWorkflowStatus(WorkflowStatus status, string message)
        {
            var statusActor = Context.ActorOf(Props.Create(typeof(WorkflowStatusActor)));

            statusActor.Tell(new UpdateStatusMesssage { Status = status, Message = message }, Self);
        }
    }
}