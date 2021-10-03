namespace fs_aspsample.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open fs_aspsample

[<ApiController>]
[<Route("[controller]")>]
type WeatherForecastController(logger: ILogger<WeatherForecastController>) =
    inherit ControllerBase()

    let rng = System.Random()

    let summaries =
        [| "Freezing"
           "Bracing"
           "Chilly"
           "Cool"
           "Mild"
           "Warm"
           "Balmy"
           "Hot"
           "Sweltering"
           "Scorching" |]

    [<HttpGet>]
    member _.Get() =
        async {
            let value = rng.Next(0, 1000)
            do! Async.Sleep(value)

            return
                [| for index in 0 .. 4 ->
                       { Date = DateTime.Now.AddDays(float index)
                         TemperatureC = rng.Next(-20, 55)
                         Summary = summaries.[rng.Next(summaries.Length)] } |]
        }
