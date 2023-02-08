using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Blazor.Infrastructure.Identity;

namespace BlazorShared.Models;

public class Test
{
    public Test()
    {
        var workflow = Workflow.Create("Claims Management");
    }
}
public class Workflow
{
    public string Name { get; set; }
    public Dictionary<int, WorkflowStep> WorkflowSteps { get; set; }

    public static Workflow Create(string workflowType)
    {
        return new Workflow() { WorkflowSteps = new Dictionary<int, WorkflowStep>() { } };
    }
}


public class WorkflowStep
{
    public StepType StepType { get; set; }

    public ApplicationUser AssignedTo { get; set; }
}


public class ApprovalWorkflowStep: WorkflowStep
{


}

public class InformationWorkflowStep : WorkflowStep
{
    public QuestionaireDto Questionaire { get; set; }
}

public enum StepType
{
 Approval,
 RequestForInformation,



}