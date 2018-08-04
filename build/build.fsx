#load ".fake/build.fsx/intellisense.fsx"
open Fake.Core
open Fake.DotNet
open Fake.IO
open Fake.IO.FileSystemOperators
open Fake.IO.Globbing.Operators
open Fake.Core.TargetOperators

let apiartifacts = "../artifacts.api"
let serviceartifacts = "../artifacts.service"
let packages = "../packages"

Target.create "Clean" (fun _ ->
    !! "../src/**/bin"
    ++ "../src/**/obj"
    ++ apiartifacts
    ++ serviceartifacts
    ++ packages
    |> Shell.cleanDirs 
)

Target.create "Build" (fun _ ->
    !! "../src/**/*.*proj"
    ++ "../tests/**/*.*proj"
    |> Seq.iter (DotNet.build id)
)

Target.create "Test" (fun _ ->
    !! "../tests/**/*.*proj"
    |> Seq.iter (DotNet.test id)
)

Target.create "Publish Api" (fun _ ->
     DotNet.publish (fun c->
        { c with
            Configuration = DotNet.Release
            OutputPath = Some "../../artifacts.api"
        }) "../src/Starveler.Api"
)

Target.create "Publish Service" (fun _ ->
     DotNet.publish (fun c->
        { c with
            Configuration = DotNet.Release
            OutputPath = Some "../../artifacts.service"
        }) "../src/Starveler.Service"
)

Target.create "All" ignore

"Clean"
  ==> "Build"
  ==> "Test"
  ==> "Publish Api"
  ==> "Publish Service"
  ==> "All"

Target.runOrDefault "All"
