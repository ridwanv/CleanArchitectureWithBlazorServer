using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorShared.Models;

namespace BlazorShared.Services;

[ScopedRegistration]
public class QuestionaireService: IQuestionaireService
{

    public QuestionaireService()
    {

    }

    public async Task<QuestionaireDto> Get(Guid questionaireId)
    {
        return new QuestionaireDto() { Sections = GetSections() };
    }

    private List<SectionDto> GetSections()
    {
        List<SectionDto> sections = new List<SectionDto>();
        sections.Add(new SectionDto() { SectionName = "Functionality", Questions = GetPersonalPreferenceQuestions() });
        sections.Add(new SectionDto() { SectionName = "Data", Questions = GetChoiceQuestions() });
        sections.Add(new SectionDto() { SectionName = "Integration", Questions = GetIntegrationQuestions() });
        sections.Add(new SectionDto() { SectionName = "Access", Questions = GetAccessQuestions() });
        sections.Add(new SectionDto() { SectionName = "Compliance", Questions = GetComplianceQuestions() });
        sections.Add(new SectionDto() { SectionName = "Operations and Support", Questions = GetOperationsQuestions() });
        return sections;
    }

    private List<QuestionDto> GetOperationsQuestions()
    {
        var QuestionAnswers = new List<QuestionDto>();
        QuestionAnswers.Add(new QuestionDto() { QuestionLabel = "Required by Hollard’s Procurement & Legal governance, the appropriate Master Services Agreement (MSA), Service Schedule and Service Level Agreement (SLA) must be in place.Is the SLA is in line with business need? ", AnswerType = new YesNoAnswerDto() { } });

QuestionAnswers.Add(new QuestionDto() { QuestionLabel = "Is there an operationalisation plan approved by IT Operations covering at least Backup, DR, Security, DBA and Support operations?", AnswerType = new YesNoAnswerDto() { } });
QuestionAnswers.Add(new QuestionDto() { QuestionLabel = "Is there a well defined ticket logging procedure including  (SLA, Request Management, Change & Release Management, Incident & Problem Management, Capacity Management, Event Management – Alerting & Monitoring)", AnswerType = new YesNoAnswerDto() { } });

QuestionAnswers.Add(new QuestionDto() { QuestionLabel = "Are there firewall, anti-malware, vulnerability checks, encryption, patch management in place for the solution?", AnswerType = new YesNoAnswerDto() { } });

QuestionAnswers.Add(new QuestionDto() { QuestionLabel = "The data centre hosting the solution must be of a reputable standard, provide physical access security, as well as physical and software based network security.", AnswerType = new YesNoAnswerDto() { } });


        return QuestionAnswers;
    }

    private List<QuestionDto> GetComplianceQuestions()
    {
        var QuestionAnswers = new List<QuestionDto>();
        QuestionAnswers.Add(new QuestionDto() { QuestionLabel = "Any application hosting customer data must reside within the boundaries of the European Union (EU) or South African (ZA) borders. Where is the solution hosted?", AnswerType = new ShortTextDto() { } });

        return QuestionAnswers;
    }

    private List<QuestionDto> GetAccessQuestions()
    {
        var QuestionAnswers = new List<QuestionDto>();
        QuestionAnswers.Add(new QuestionDto() { QuestionLabel = "Where will the issues related to access be raised? Who will act as 1st line of support in case of access issues?", AnswerType = new ShortTextDto() { } });
        QuestionAnswers.Add(new QuestionDto() { QuestionLabel = "Is the solution going to be integrated with Hollard Active Directory? Are you aware if this will lead to multiple sign on issues?", AnswerType = new YesNoAnswerDto() { } });
        QuestionAnswers.Add(new QuestionDto() { QuestionLabel = "Will the solution result in duplicating credentials in different systems?  Is there a mitigation plan  if so?", AnswerType = new YesNoAnswerDto() { } });
        return QuestionAnswers;
    }

    private List<QuestionDto> GetIntegrationQuestions()
    {
        var QuestionAnswers = new List<QuestionDto>();
        QuestionAnswers.Add(new QuestionDto() { QuestionLabel = "This may lead to disjointed process across cloud (and on premises) applications.  Are you aware of the concerns or issues applicable here and an action plan to mitigate same?", AnswerType = new YesNoAnswerDto() { } });
        QuestionAnswers.Add(new QuestionDto() { QuestionLabel = "Is there a manual  process in place to manage the integration? If yes, then is there an action plan to automate any manual processes?", AnswerType = new YesNoAnswerDto() { } });
        QuestionAnswers.Add(new QuestionDto() { QuestionLabel = "Is the business aware of the security concern due to manual process / non-automated processes?", AnswerType = new YesNoAnswerDto() { } });
        QuestionAnswers.Add(new QuestionDto() { QuestionLabel = "Do you have documentation to ensure the usage of integration (API’s)?", AnswerType = new YesNoAnswerDto() { } });
        QuestionAnswers.Add(new QuestionDto() { QuestionLabel = "Is there a need of abstraction of the API’s?", AnswerType = new YesNoAnswerDto() { } });
        QuestionAnswers.Add(new QuestionDto() { QuestionLabel = "What are the standards for the API's supplied? ", AnswerType = new YesNoAnswerDto() { } });
        QuestionAnswers.Add(new QuestionDto() { QuestionLabel = "Is there a testing environment for the API's?", AnswerType = new YesNoAnswerDto() { } });

        return QuestionAnswers;
    }

    public async Task<List<QuestionaireDto>> Search(QuestionaireSearchRequest questionaireSearchRequest)
    {
        return new List<QuestionaireDto>() { await Get(Guid.NewGuid()) };
    }

    private List<QuestionDto> GetPersonalPreferenceQuestions()
    {
        var QuestionAnswers = new List<QuestionDto>();
        QuestionAnswers.Add(new AssessmentQuestionDto() { Priority = Priority.MustHave,  QuestionLabel = "Does the solution support interactive voice response (IVR)?", AnswerType = new Criteria() { } });
        QuestionAnswers.Add(new AssessmentQuestionDto() { Priority = Priority.MustHave, QuestionLabel = "Does the solution support Automated call distributor (ACD), call routing?", AnswerType = new Criteria() { } });
        QuestionAnswers.Add(new AssessmentQuestionDto() { Priority = Priority.SHouldHave, QuestionLabel = "Support for Non-ACD call transfer?", AnswerType = new Criteria() { } });
        QuestionAnswers.Add(new AssessmentQuestionDto() { Priority = Priority.CouldHave, QuestionLabel = "Can the solution support Skills group handling?", AnswerType = new Criteria() { } });
        QuestionAnswers.Add(new AssessmentQuestionDto() { Priority = Priority.MustHave, QuestionLabel = "Does the solution support Call prioritisation?", AnswerType = new Criteria() { } });
        //QuestionAnswers.Add(new Question() { QuestionLabel = "Has the business analysis being done for the requirement?", AnswerType = new YesNoAnswer() { } });
        //QuestionAnswers.Add(new Question() { QuestionLabel = "Has a business case been completed? ", AnswerType = new YesNoAnswer() { } });
        //QuestionAnswers.Add(new Question() { QuestionLabel = "Is the business process mapped to the capability of the solution?", AnswerType = new YesNoAnswer() { } });
        //QuestionAnswers.Add(new Question() { QuestionLabel = "Is there any deviation from the process, and how it can be met?", AnswerType = new YesNoAnswer() { } });
        //QuestionAnswers.Add(new Question() { QuestionLabel = "Are the requirement specifications documented and approved?", AnswerType = new YesNoAnswer() { } });
        //QuestionAnswers.Add(new Question() { QuestionLabel = "Are the functions performed against the use case  definition?", AnswerType = new YesNoAnswer() { } });
        //QuestionAnswers.Add(new Question() { QuestionLabel = "Is there any existing solution across Hollard Group in place to meet this requirement?", AnswerType = new YesNoAnswer() { } });
        //QuestionAnswers.Add(new Question() { QuestionLabel = "Are there differentiating features in this solution, and are these required by business?", AnswerType = new YesNoAnswer() { } });
        //QuestionAnswers.Add(new Question() { QuestionLabel = "Is  functional documentation available? ", AnswerType = new YesNoAnswer() { } });
        //QuestionAnswers.Add(new Question() { QuestionLabel = "Is the solution Tactical or Strategic? (if Tactical is there an action plan for migration to strategic solution?) ", AnswerType = new YesNoAnswer() { } });
        //QuestionAnswers.Add(new Question() { QuestionLabel = "Is a Test Environment required and available?", AnswerType = new YesNoAnswer() { } });
        //QuestionAnswers.Add(new Question() { QuestionLabel = "Are there any legal considerations regarding the solution, hosting region, or data?", AnswerType = new YesNoAnswer() { } });
        //QuestionAnswers.Add(new Question() { QuestionLabel = "Is there any tax legislation that could affect the solution, hosting region, or data?", AnswerType = new YesNoAnswer() { } });


        return QuestionAnswers;
    }

    private List<QuestionDto> GetChoiceQuestions()
    {
        var QuestionAnswers = new List<QuestionDto>();
        QuestionAnswers.Add(new QuestionDto() { QuestionLabel = "Is access to the Raw Data available on request? (Y/N) ", AnswerType = new YesNoAnswerDto() { } });
        QuestionAnswers.Add(new QuestionDto() { QuestionLabel = "What is the cost of providing the raw data if any?", AnswerType = new YesNoAnswerDto() { } });
        QuestionAnswers.Add(new QuestionDto() { QuestionLabel = "Cost of getting the data back and cost associated to the growth of the data?", AnswerType = new YesNoAnswerDto() { } });
        QuestionAnswers.Add(new QuestionDto() { QuestionLabel = "Is there a defined Exit Strategy covering the return of our data to Hollard in a usable form, in the event that we wish to part ways with the service provider?", AnswerType = new YesNoAnswerDto() { } });
        QuestionAnswers.Add(new QuestionDto() { QuestionLabel = "Does the system supply 'out of the box' reports that meet your needs? (Y/N)", AnswerType = new YesNoAnswerDto() { } });
        QuestionAnswers.Add(new QuestionDto() { QuestionLabel = "List out standard/operational reports comes with the solution?", AnswerType = new YesNoAnswerDto() { } });
        QuestionAnswers.Add(new QuestionDto() { QuestionLabel = "What skills are required to understand the data? Easy to absorb and bring into Hollard’s world?", AnswerType = new YesNoAnswerDto() { } });
        QuestionAnswers.Add(new QuestionDto() { QuestionLabel = "Is it an automatable process? (Can we get the automated reports?)", AnswerType = new YesNoAnswerDto() { } });
        QuestionAnswers.Add(new QuestionDto() { QuestionLabel = "Does the solution act as a true source of data? Are there other sources of data? Are you aware of Golden source of Utilization?  Is the solution a System of record or System of truth?", AnswerType = new YesNoAnswerDto() { } });
        QuestionAnswers.Add(new QuestionDto() { QuestionLabel = "Have you considered Master Data Management principles in case of multiple sources of truth?", AnswerType = new YesNoAnswerDto() { } });
        QuestionAnswers.Add(new QuestionDto() { QuestionLabel = "Is there any issue of data ownership?  Who owns the data? ", AnswerType = new YesNoAnswerDto() { } });
        QuestionAnswers.Add(new QuestionDto() { QuestionLabel = "Who owns the IP and the data in the scenario of POC and in Final Solution?", AnswerType = new YesNoAnswerDto() { } });
        QuestionAnswers.Add(new QuestionDto() { QuestionLabel = "Data classification: Is the data that is going to be stored Sensitive, Public, or Private?", AnswerType = new YesNoAnswerDto() { } });
        QuestionAnswers.Add(new QuestionDto() { QuestionLabel = "Data retention policy: how long do we need to keep data - consider both business purpose and regulatory purpose?", AnswerType = new YesNoAnswerDto() { } });
        QuestionAnswers.Add(new QuestionDto() { QuestionLabel = "What are the consideration for data destruction after the retention period?", AnswerType = new YesNoAnswerDto() { } });
        QuestionAnswers.Add(new QuestionDto() { QuestionLabel = "Can any third party use our data (directly/indirectly)? ", AnswerType = new YesNoAnswerDto() { } });
        QuestionAnswers.Add(new QuestionDto() { QuestionLabel = "How do we ensure the data from the solution is accurate? (Have to ensure validations on data).", AnswerType = new YesNoAnswerDto() { } });
        QuestionAnswers.Add(new QuestionDto() { QuestionLabel = "Security around the data (is the data encrypted at rest and during movement)?", AnswerType = new YesNoAnswerDto() { } });
        QuestionAnswers.Add(new QuestionDto() { QuestionLabel = "Data back ups (Frequency and location)?", AnswerType = new YesNoAnswerDto() { } });

        return QuestionAnswers;
    }
}
