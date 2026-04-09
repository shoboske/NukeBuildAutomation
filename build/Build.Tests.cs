using System.Collections.Generic;
using System.Linq;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Tools.DotNet;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

partial class Build
{
    IEnumerable<Nuke.Common.ProjectModel.Project> TestProjects =>
        Solution.AllProjects.Where(x => x.Name.Contains(".Tests"));

    Target TestWithCoverage => _ => _
        .DependsOn(Compile)
        .Executes(() =>
        {
            var testProjects = TestProjects.ToList();
            if (!testProjects.Any())
                throw new System.Exception("No test projects found in solution.");

            testProjects.ForEach(testProject =>
                DotNet($"test \"{testProject.Path}\" --configuration {Configuration} --no-build --results-directory \"{OutputDirectory / "test-results"}\" --logger trx --collect:\"XPlat Code Coverage\""));
        });
}
