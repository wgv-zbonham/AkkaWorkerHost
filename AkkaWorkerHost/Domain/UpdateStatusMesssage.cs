namespace AkkaWorkerHost.Domain
{
    public class UpdateStatusMesssage
    {
        public WorkflowStatus Status { get; set; }
        public string Message { get; set; }
    }
}