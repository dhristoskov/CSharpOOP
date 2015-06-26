namespace ConsoleForum.Commands
{
    using System;

    using ConsoleForum.Contracts;

    public class ExitCommand : AbstractCommand
    {
        public ExitCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            Environment.Exit(1);
        }
    }
}
