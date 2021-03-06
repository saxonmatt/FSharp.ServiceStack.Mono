﻿module HelloService

    open ServiceStack.ServiceHost
    open ServiceStack.WebHost.Endpoints
    open ServiceStack.ServiceInterface


    [<CLIMutable>]
    type HelloResponse = { Text : string }


    [<Route("/hello", "GET")>]
    type HelloRequest() = 
        interface IReturn<HelloResponse>


    type HelloService() =
        inherit Service()

        member this.Get(helloRequest: HelloRequest) = 
            { Text = "Hello, world!" }


    type HelloServiceHost() = 
        inherit AppHostBase("Hello Service", typeof<HelloService>.Assembly)
        override this.Configure container = 
            container |> ignore