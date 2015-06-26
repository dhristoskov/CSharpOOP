namespace ConsoleForum.Commands
{
    using System.Linq;
    using System.Net;

    using ConsoleForum.Contracts;
    using ConsoleForum.Entities.Posts;

    public class MakeBestAnswerCommand : AbstractCommand
    {
        public MakeBestAnswerCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            if (!this.Forum.IsLogged)
            {
                throw new CommandException(Messages.NotLogged);
            }
            if (this.Forum.CurrentQuestion == null)
            {
                throw new CommandException(Messages.NoQuestionOpened);
            }

            int id = int.Parse(this.Data[1]);
            if (!(this.Forum.CurrentQuestion.Answers.Any(s => s.Id == id)))
            {
                throw new CommandException(Messages.NoAnswer);

            }

            if (this.Forum.CurrentUser != this.Forum.CurrentQuestion.Author)
            {
                if (this.Forum.CurrentUser is IAdministrator)
                {
                    //
                }
                else
                {
                    throw new CommandException(Messages.NoPermission);
                }
            }
            


            var question = this.Forum.CurrentQuestion as Question;
            if (question == null)
            {
                throw new CommandException(Messages.NoQuestionOpened);
            }
            question.BestAnswerId = id;
            this.Forum.Output.AppendFormat(Messages.BestAnswerSuccess, id).AppendLine();
        }
    }
}
