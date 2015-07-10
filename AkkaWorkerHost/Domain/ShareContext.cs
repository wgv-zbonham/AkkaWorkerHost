using System;

namespace AkkaWorkerHost.Domain
{
    public class ShareContext
    {
        public Guid OrganizationdId { get; set; }
        public string ShareReferenceNo { get; set; }
        public string SourcePath { get; set; }
        public string DestinatonPath { get; set; }
        public string SasKey { get; set; }
    }
}