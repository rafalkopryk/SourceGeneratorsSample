using System.IO;
using System.Linq;
using SourceGenerators.Tests.Utils;
using Microsoft.CodeAnalysis.CSharp;
using Xunit;

namespace SourceGenerators.Tests;

public class CurrencyIso4217SourceGeneratorTests
{
    private const string CurrencyIso4217RegistryText = """
    <?xml version="1.0" encoding="UTF-8" standalone="yes"?>
    <ISO_4217 Pblshd="2024-06-25">
        <CcyTbl>
            <CcyNtry>
                <CtryNm>POLAND</CtryNm>
                <CcyNm>Zloty</CcyNm>
                <Ccy>PLN</Ccy>
                <CcyNbr>985</CcyNbr>
                <CcyMnrUnts>2</CcyMnrUnts>
            </CcyNtry>
            <CcyNtry>
                <CtryNm>UNITED STATES OF AMERICA (THE)</CtryNm>
                <CcyNm>US Dollar</CcyNm>
                <Ccy>USD</Ccy>
                <CcyNbr>840</CcyNbr>
                <CcyMnrUnts>2</CcyMnrUnts>
            </CcyNtry>	
            <CcyNtry>
                <CtryNm>GERMANY</CtryNm>
                <CcyNm>Euro</CcyNm>
                <Ccy>EUR</Ccy>
                <CcyNbr>978</CcyNbr>
                <CcyMnrUnts>2</CcyMnrUnts>
            </CcyNtry>
        </CcyTbl>
    </ISO_4217>                                        
    """;

    private const string ExpectedGeneratedClassText = @"// <auto-generated/>

using System;
using System.Collections.Generic;

namespace Currencies;

public partial record Currency(string Name, string Code, string Number, int MinorUnits)
{
    public static readonly Currency PLN = new Currency(""Zloty"", ""PLN"", ""985"", 2);
    public static readonly Currency USD = new Currency(""US Dollar"", ""USD"", ""840"", 2);
    public static readonly Currency EUR = new Currency(""Euro"", ""EUR"", ""978"", 2);

    public static readonly IEnumerable<Currency> Items =
    [
         PLN,
         USD,
         EUR,
    ];
}
";
    
    [Fact]
    public void GenerateClassesBasedOnCurrencyIso4217Registry()
    {
        // Create an instance of the source generator.
        var generator = new CurrencyIso4217SourceGenerator();

        // Source generators should be tested using 'GeneratorDriver'.
        var driver = CSharpGeneratorDriver.Create(new[] { generator },
            new[]
            {
                // Add the additional file separately from the compilation.
                new TestAdditionalFile("./ISO-4217.xml", CurrencyIso4217RegistryText)
            });

        // To run generators, we can use an empty compilation.
        var compilation = CSharpCompilation.Create(nameof(CurrencyIso4217SourceGeneratorTests));

        // Run generators. Don't forget to use the new compilation rather than the previous one.
        driver.RunGeneratorsAndUpdateCompilation(compilation, out var newCompilation, out _);

        // Retrieve all files in the compilation.
        var generatedFileSyntax = newCompilation.SyntaxTrees
            .FirstOrDefault();

        var generatedFileName = Path.GetFileName(generatedFileSyntax.FilePath);
        var file = generatedFileSyntax.GetText().ToString();
        
        // In this case, it is enough to check the file name.
        Assert.Equal("Currency.g.cs", generatedFileName);
        
        // Complex generators should be tested using text comparison.
        Assert.Equal(ExpectedGeneratedClassText, generatedFileSyntax.GetText().ToString(),
            ignoreLineEndingDifferences: true);
    }
}