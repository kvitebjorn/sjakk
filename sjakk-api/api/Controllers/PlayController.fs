namespace api.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open api

[<ApiController>]
[<Route("api/[controller]")>]
type PlayController (logger : ILogger<PlayController>) =
    inherit ControllerBase()

    [<HttpGet>]
    member _.Get() =
        { Message = "hi" }
