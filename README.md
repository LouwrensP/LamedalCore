# LamedalCore v1.1.6-alfa2
* Project : https://sites.google.com/site/lamedalwiki/
* Lamedal Nuget package: https://www.nuget.org/packages/LamedalCore/
* PM> Install-Package LamedalCore
* The "master" branch is not stable. Click on [Workflow](docs/Workflow.md) to see the workflow of the project.

## State
Platform            | Build      |Tests| Status | Server
--------------------|------------|-----|--------|---------
Windows 10.0 VS2017 |Debug       | -   | ![alt tag](https://ci.appveyor.com/api/projects/status/5tt4c9sj7dpv5xx5?svg=true) | [AppVeyor](https://ci.appveyor.com/projects)
Windows 10.0 VS2017 |Debug       | yes | ![alt tag](https://ci.appveyor.com/api/projects/status/s8ox68g39xc9tfne?svg=true) | [AppVeyor](https://ci.appveyor.com/projects)
Windows 10.0 VS2017 |Release     | yes | ![alt tag](https://ci.appveyor.com/api/projects/status/9t93y3013de1ktwg?svg=true) | [AppVeyor](https://ci.appveyor.com/projects)
Windows 10.0 VS2017 |tests run   | yes | ![alt tag](https://ci.appveyor.com/api/projects/status/r64leqcijlqfj24h?svg=true) | [AppVeyor artifacts](https://ci.appveyor.com/project/perezLamed/lamedalcore/build/artifacts)
Linux Ubuntu 14.04  |dotnet build| -   | ![alt tag](https://travis-ci.org/perezLamed/LamedalCore.svg?branch=master) | [Travis](https://travis-ci.org/perezLamed/LamedalCore)
OSX Darwin 10.11-x64|dotnet build| -   | ![alt tag](https://travis-ci.org/perezLamed/LamedalCore.svg?branch=master)| [Travis](https://travis-ci.org/perezLamed/LamedalCore)
Linux Ubuntu 14.04  |dotnet build| yes | (todo) | [Travis](https://travis-ci.org/perezLamed/LamedalCore)               
Static Analysis     |analysis    | -   | ![alt tag](https://scan.coverity.com/projects/12604/badge.svg?flat=1) | [Coverity Scan](https://scan.coverity.com/projects/perezlamed-lamedalcore?tab=overview)
Code Coverage       |dotCover    | yes | ![Result](https://rawgithub.com/perezLamed/LamedalCore/master/pics/badge.svg) | [Report Generator](https://github.com/danielpalme/ReportGenerator)

## Background
-------------------------------------------------------------------------------------
> <i> The **best programmers** in the world can deliver software before deadlines, under budget, 
> and address 100% of the requirements. Sadly there are just too many deadlines and in order 
> to stay afloat code is copied and pasted all over the place. No time is available to spend 
> on code quality. There is never time to focus on writing code for one simple specific thing, 
> that do one thing and do that one thing very well. The fact of life is that there is never 
> an opportunity to create these "perfect little snowflakes" of code. 
>
> The continues pressures of "crunching" out code will ... [see more](https://sites.google.com/site/lamedalwiki/)
--------------------------------------------------------------------------------------------

## Roadmap
* *Create a simple but functional .NET Core library. (Done)*
* *Create test cases with at least 95% code coverage of the library. (Done)* 
* *Create workflow process to ensure library stability and usability. (Done)*
* *Integrate with Appveyor (Done)*
* **Create a simple c# code parser to evaluate code on a macro scale. (In progress - 4 June 2017)**
* Create Visual Studio Tools to support the Lamedal framework. (Future)
* Use Lamedal tools to refactor and optimise source code. (Future)
* Publish Lamedal Blueprint rule framework methodology. (Future)
* Demo's to illustrate how Blueprint tools is used to create Lamedal extensions. (Future)

## Setup
* Click on [Setup](docs/Setup.md) to see how to setup and use the library.

## License
Apache License Version 2.0
