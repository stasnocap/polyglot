using System.Diagnostics.CodeAnalysis;
using EngQuest.Domain.Users;
using FluentAssertions;
using Xunit.Abstractions;

namespace EngQuest.Domain.UnitTests.Users;

public class LevelTests(ITestOutputHelper testOutputHelper)
{
    [Fact]
    [SuppressMessage("Blocker Code Smell", "S2699:Tests should include assertions")]
    public void GainExperience()
    {
        var level = new Level(1);
        int[] quests = Enumerable.Range(1, 30).ToArray();

        foreach (int quest in quests)
        {
            for (int i = 1; i <= 1000; i++)
            {
                if (!level.GainExperience(quest))
                {
                    continue;
                }

                testOutputHelper.WriteLine($"Complete quest({quest}) {i} times to achieve level {level.Value}");
                break;
            }
        }
    }

    [Fact]
    public void GainExperience_Should_NotGain_IfLevelSurpassesQuest()
    {
        // Arrange
        var level = new Level(2);

        // Act
        level.GainExperience(1);

        // Assert
        level.Experience.Should().Be(0);
    }
}
