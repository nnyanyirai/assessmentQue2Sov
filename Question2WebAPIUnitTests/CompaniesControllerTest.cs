using Microsoft.AspNetCore.Mvc.Testing;
using SingleDotNetCoreWebApp.Controllers;
using SingleDotNetCoreWebApp.Models;
using SingleDotNetCoreWebApp.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using static Xunit.Assert;
using Question2WebAPI.Controllers;

namespace SingleDotNetCoreWebAppUnitTests
{
    public class CompaniesControllerTest : IClassFixture<WebApplicationFactory<CompaniesController>>
    {
        // IClassFixture<CustomWebApplicationFactory<Startup>>
        //: IClassFixture<WebApplicationFactory<AccountController>>
        // private readonly HttpClient _client;


        private readonly WebApplicationFactory<CompaniesController> factory;

        public CompaniesControllerTest(WebApplicationFactory<CompanyController> factory)
        {
            this.factory = factory;
        }
        [Fact]
        public async Task GetCompanies_ReturnsJsonResult_WithOneAccount()
        {
            
            var client = factory.CreateClient();
            var url = "http://localhost:63211/api/Company";

           
            var response = await client.DoGetAsync<Company>(url);

           
            Equal("NGO", response.BusinessType);
        }
    }
}
