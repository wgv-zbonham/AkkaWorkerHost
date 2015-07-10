using System;
using Akka.Actor;
using AkkaWorkerHost.Domain;

namespace AkkaWorkerHost
{
    public class WorkflowStatusActor : ReceiveActor
    {
        public WorkflowStatusActor()
        {
            Receive<UpdateStatusMesssage>(
                _ => { Console.WriteLine("Updating Workflow Status to {0} because {1}", _.Status, _.Message); });
        }
    }
}