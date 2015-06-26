namespace ConsoleForum.Commands
{
    using System.Linq;
    using System.Runtime.InteropServices.ComTypes;

    using ConsoleForum.Contracts;

    public class OpenQuestionCommand : AbstractCommand
    {
        public OpenQuestionCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            int id = int.Parse(this.Data[1]);
            if (!(this.Forum.Questions.Any(s=>s.Id == id)))
            {
                throw new CommandException(Messages.NoQuestion);
            }
            this.Forum.CurrentQuestion = this.Forum.Questions.First(s => s.Id == id);

            this.Forum.Output.Append(ShowQuestionsCommand.PrintQuestion(this.Forum.CurrentQuestion));
        }
    }
}
