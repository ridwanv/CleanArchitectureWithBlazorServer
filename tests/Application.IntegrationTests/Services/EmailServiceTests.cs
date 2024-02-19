using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorShared.Services;
using CleanArchitecture.Application.IntegrationTests;
using NUnit.Framework;

namespace CleanArchitecture.Blazor.Application.IntegrationTests.Services;
public class EmailServiceTests: TestBase
{
    private  IEmailService _emailService;

    [SetUp]
    public async Task InitData()
    {
        _emailService = new EmailService();
    }
    [Test]
    public async Task ShouldLoadDataSource()
    {
        _emailService.SendEmail(new EmailDto() { To = "ridz01@gmail.com",Body="Test", Subject="Test"});

    }

}
