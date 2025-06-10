using FluentAssertions.Execution;

namespace SiteGround.Tests.Infrastructure.Assertions
{
    public static class Verify
    {
        public static void All(Action action)
        {
            using (new AssertionScope())
            {
                action();
            }
        }

        public static async Task All(Task<Action> action)
        {
            using (new AssertionScope())
            {
                await action;
            }
        }
    }
}
