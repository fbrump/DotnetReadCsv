# DotnetReadCsv
Challenge

## How to use

Get all employees:

```csharp

dotnet run --project DotnetHomeChallenge/DotnetHomeChallenge.csproj
# or
dotnet run --project DotnetHomeChallenge/DotnetHomeChallenge.csproj search

```

Filter employees by text using command `search` and parameter `-t` or `--text`:

```csharp

dotnet run --project DotnetHomeChallenge/DotnetHomeChallenge.csproj search -t 

```

There's a possibility to search by multiple texts using `;` as a separator:

```csharp

dotnet run --project DotnetHomeChallenge/DotnetHomeChallenge.csproj search -t ena,inc,ian,eir,br,non  

```
Whether there's more than 5 separators the app will consider only first 5:

```csharp

dotnet run --project DotnetHomeChallenge/DotnetHomeChallenge.csproj search -t ena,inc,ian,eir,br,non  

```