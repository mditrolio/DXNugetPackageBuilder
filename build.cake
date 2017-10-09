var target = Argument("target", "Default");

Task("Package-Restore")
	.Does(() =>
{
	StartProcess("dotnet", new ProcessSettings{
      WorkingDirectory = ".",
      Arguments = "restore"
   });
});


Task("Clean")
	.Does(() =>
{
	CleanDirectories("./src/**/bin/debug");
});


Task("Build")
	.IsDependentOn("Clean")
	.IsDependentOn("Package-Restore")
	.Does(() =>
{
	DotNetBuild("./DXNugetPackageBuilder.sln");
});


Task("Default").IsDependentOn("Build");

RunTarget(target);