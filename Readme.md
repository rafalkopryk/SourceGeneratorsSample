# Roslyn Source Generators Sample

A set of three projects that illustrates Roslyn source generators. Enjoy this template to learn from and modify source generators for your own needs.

## Content
### SourceGenerators
A .NET Standard project with implementations of sample source generators.
**You must build this project to see the result (generated code) in the IDE.**

- [CurrencyIso4217SourceGenerator.cs](SourceGenerators/SourceGenerators/CurrencyIso4217SourceGenerator.cs): A source generator that creates C# class based on a text file (in this case, currency https://www.six-group.com/dam/download/financial-information/data-center/iso-currrency/lists/list-one.xml registry).
- [SmartEnumIncrementalSourceGenerator.cs](SourceGenerators/SourceGenerators/SmartEnumIncrementalSourceGenerator.cs): A source generator that creates `Items` property based on record properties. The target class should be annotated with the `SmartEnumGenerators.SmartEnumGeneratorAttribute` attribute.

### SourceGenerators.Sample
A project that references source generators. Note the parameters of `ProjectReference` in [SourceGenerators.Sample.csproj](SourceGenerators/SourceGenerators.Sample/SourceGenerators.Sample.csproj), they make sure that the project is referenced as a set of source generators. 

### SourceGenerators.Tests
Unit tests for source generators. The easiest way to develop language-related features is to start with unit tests.

## How To?
### How to debug?
- Use the [launchSettings.json](SourceGenerators/SourceGenerators/Properties/launchSettings.json) profile.
- Debug tests.

### How can I determine which syntax nodes I should expect?
Consider installing the Roslyn syntax tree viewer plugin [Rossynt](https://plugins.jetbrains.com/plugin/16902-rossynt/).

### How to learn more about wiring source generators?
Watch the walkthrough video: [Let’s Build an Incremental Source Generator With Roslyn, by Stefan Pölz](https://youtu.be/azJm_Y2nbAI)
The complete set of information is available in [Source Generators Cookbook](https://github.com/dotnet/roslyn/blob/main/docs/features/source-generators.cookbook.md).