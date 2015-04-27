// --------------------------------------------------------------------------------------
// FAKE build script
// --------------------------------------------------------------------------------------

#r @"packages/FAKE/tools/FakeLib.dll"

open System
open System.IO
open Fake
 
Environment.CurrentDirectory <- __SOURCE_DIRECTORY__
 
// Step 2. Use the packages
 
#r "packages/Suave/lib/net40/Suave.dll"
#r "packages/FSharp.Data/lib/net40/FSharp.Data.dll"
#r "packages/FSharp.Charting/lib/net40/FSharp.Charting.dll"
 
let ctxt = FSharp.Data.WorldBankData.GetDataContext()
 
let data = ctxt.Countries.Algeria.Indicators.``GDP (current US$)``
 
open Suave // always open suave
open Suave.Http.Successful // for OK-result
open Suave.Web // for config
open Suave.Types
open System.Net

let port = Sockets.Port.Parse <| getBuildParamOrDefault "port" "8083" 

let serverConfig = 
    { defaultConfig with
       bindings = [ HttpBinding.mk HTTP IPAddress.Loopback port ]
    }
 
startWebServer serverConfig (OK (sprintf "Hello World! In 2010 Algeria earned %f " data.[2010]))