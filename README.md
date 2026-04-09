# NukeBuildAutomation

A minimal .NET 10 sample project that demonstrates how to automate common development workflows with [NUKE](https://nuke.build/).

This repository includes:
- A small ASP.NET Core app (`/ping` endpoint)
- A unit test project (NUnit)
- A NUKE build pipeline for clean, restore, compile, run, and test-with-coverage tasks

## Project Layout

```text
.
|- build/                      # NUKE build project
|  |- Build.cs                 # Core targets: Clean, Restore, Compile, Run
|  |- Build.Tests.cs           # TestWithCoverage target
|  |- _build.csproj
|- src/
|  |- MyProject/               # ASP.NET Core app
|- tests/
|  |- MyProject.Tests.Unit/    # NUnit test project
|- global.json                 # Pinned .NET SDK version
```

## Prerequisites

- .NET SDK `10.0` (see `global.json`)
- NUKE CLI (`nuke` command)

Install NUKE if needed:

```powershell
dotnet tool install Nuke.GlobalTool --global
```

## Quick Start

### 1) Restore and build via NUKE

```bash
nuke Restore
nuke Compile
```

### 2) Run the web app

```bash
nuke Run
```

Once running, test the endpoint:

- `GET /ping` -> `Hello, World!`

## Build Targets

Defined in `build/Build.cs` and `build/Build.Tests.cs`:

- `Clean` - Removes `bin/obj` folders from `src` and `tests`, recreates `output/`
- `Restore` - Restores NuGet packages for the solution
- `Compile` - Builds solution (default target)
- `Run` - Runs `src/MyProject`
- `TestWithCoverage` - Runs all `*.Tests*` projects with XPlat code coverage and TRX output

Example:

```bash
nuke TestWithCoverage --configuration Debug
```

## Output and Artifacts

- Build outputs are directed to `output/` (configured in project files)
- Test results from `TestWithCoverage` are written under `output/test-results`

## Notes

- Local builds default to `Debug`; CI/server builds default to `Release`.
- The default NUKE target is `Compile`.

