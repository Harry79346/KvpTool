// Ein minimaler, aber „sinnvoller“ Unit-Test, der zeigt,
// wie du Domänen-Code testest. Ziel: sofort grün & lesbar.

using Xunit;

namespace KvpTool.UnitTests;

// Dummy-Domänenobjekt, das wir gleich testen.
// (In echt liegt das im KvpTool.Domain-Projekt.)
file static class Calculator
{
    // Addiert zwei Ganzzahlen – simpel, aber gut zum Demonstrieren von Tests.
    public static int Add(int a, int b) => a + b;
}

public class CalculatorTests
{
    [Fact] // Kennzeichnet einen ausführbaren Testfall
    public void Add_ReturnsSum_WhenGivenTwoIntegers()
    {
        // Arrange: Testdaten vorbereiten
        var a = 2;
        var b = 3;

        // Act: Methode aufrufen
        var result = Calculator.Add(a, b);

        // Assert: Ergebnis prüfen
        Assert.Equal(5, result);
    }
}
