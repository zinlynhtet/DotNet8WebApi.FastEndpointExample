using DotNet8WebApi.FastEndpointExample.Models;
using FastEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8WebApi.FastEndpointExample.Controllers
{
    public class MyEndpoint : Endpoint<MyRequestModel, MyResponseModel>
    {
        public override void Configure()
        {
            Post("/api/user/create");
            AllowAnonymous();
        }
        public override async Task HandleAsync(MyRequestModel req, CancellationToken ct)
        {
            await SendAsync(new()
            {
                FullName = req.FirstName + " " + req.LastName,
                IsOver18 = req.Age > 18
            });
        }
    }

}
