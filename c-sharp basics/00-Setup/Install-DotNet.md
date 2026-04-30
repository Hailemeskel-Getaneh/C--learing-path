# Setting Up: .NET SDK

Before writing any C# code, you need the .NET SDK installed. It includes everything — the compiler, the runtime, and the CLI tools.

## Steps

1. Go to [dotnet.microsoft.com/download](https://dotnet.microsoft.com/download)
2. Download the latest LTS version (Long Term Support — the stable one)
3. Run the installer and follow the prompts
4. Once done, open a terminal and run:

```powershell
dotnet --info
```

If it prints version information and system details, you're good to go. If nothing happens, close and reopen your terminal — it sometimes needs a fresh session to pick up the new PATH.

## Why LTS?

LTS versions are supported for 3 years. The latest "preview" versions are fine for experimenting but can have breaking changes. For learning, LTS is safer.
