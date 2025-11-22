using LMS.Architecture.Tests.Utils;

namespace LMS.Architecture.Tests.Tests;

public class ModifiersTests
{
    public static TheoryData<string, Assembly> AllAssemblies = SolutionUtils.AllAssemblies;

    [Theory]
    [MemberData(nameof(AllAssemblies))]
    public void All_Utils_Classes_Should_Be_Static(string _, Assembly project)
    {
        TestResult? result = Types.InAssembly(project)
            .That()
            .HaveNameEndingWith("Utils")
            .Should()
            .BeStatic()
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    [Theory]
    [MemberData(nameof(AllAssemblies))]
    public void All_Helpers_Should_Be_Sealed(string _, Assembly project)
    {
        TestResult? result = Types.InAssembly(project)
            .That()
            .AreClasses()
            .And()
            .HaveNameEndingWith("Helper")
            .Should()
            .BeSealed()
            .GetResult();

        result.FailingTypes.Should().BeEmpty();
    }
}