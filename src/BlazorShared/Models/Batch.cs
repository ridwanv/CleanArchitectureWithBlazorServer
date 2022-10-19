using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShared.Models;
public class Batch
{
    public Guid BatchId { get; set; }
    public string FileName { get; set; }
    public int ItemCount { get; set; }
    public BatchStatus BatchStatus { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime CompletionDate { get; set; }

    public List<PersonIdentificationRequest> PersonIdentificationRequests { get; set; } = new List<PersonIdentificationRequest>();
    public List<PersonIdentification> PersonIdentifications { get; set; } = new List<PersonIdentification>();

    public string JobNumber { get; set; }
}

public enum BatchStatus
{
    New,
    InProgress,
    Complete
}

public class BatchSearchModel
{
    public Guid BatchId { get; set; }
}


