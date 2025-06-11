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

        public static Task All(Func<Task> action)
        {
            using (new AssertionScope())
            {
                return action();
            }
        }
    }
}
