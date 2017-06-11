# Workflow
* For most applications the following workflow will work best. (That is use the nuget package at https://www.nuget.org/packages/LamedalCore)

![Kiku](/src/Designs/Lamedal_Usage_Workflow1.png)

* If you require the source code in your project then use the following workflow:

![Kiku](/src/Designs/Lamedal_Usage_Workflow2.png)

(Please note: Do not use the "master" branch in projects that depend on Lamedal as it is used as the main branch for new development.

# Development of Lamedal
Please see [GitHub flow](http://scottchacon.com/2011/08/31/github-flow.html) for an explantion of why a simple workflow on Git is better. The following is a definition of the LamadalCore workflow. 

* Main development will occur on master branch.
* New features will be build directly into the main branch. 
* In times when a release is finilised, new development will not be merged and can be done on feature branches (that can later be merged to master). 
* Test coverage on master branch must be above 95%. (When test coverage goes below this number - then focus will shift to create more and better unit testing.  

# Release
* Once master is release ready (that is all new features are added and all test cases are working) -> Create NuGet package x.x.x-beta1. Note if not all features are completed then release as 'alfa'. Run test cases from Appveyor integration server
  + If not successful-> fix (configuration) problems on master and redeploy NuGet x.x.x Beta2. (Repeat this process until success)
  + If all tests success -> deploy Nuget x.x.x; 
* Once all tests are successful. create 2 release branches from master. Call the first branch 'Release x.x.x' and remove the src folder and use the Nuget package for the test cases. Call the second release branch 'Release x.x.x Source'.
* Ensure test cases build with Appveyor on 'Release x.x.x' and 'Release x.x.x Source'
* Create branch 'Release x.x.x Source' from master

# Forking
* Fork master if you want to use the latest version of the library. This is useful to add new features.
* Fork latest release branches for stable releases. This is useful for use in other projects where a stable Lamedal is needed.

![Kiku](/src/Designs/Lamedal_Workflow.png)

# Motivation of Workflow
* The workflow is optimized to ensure fast development, delivery and enhancements on master.
* With releases branches are created to ensure stability of derived work.
* The master branch will be radically refactored from time to time (in order to ensure good quality of code). It may not be practical to merge back to master (because of the dynamic nature of master).

# Test results & Code coverage: 
![Kiku](/pics/TestCoverage.png)

