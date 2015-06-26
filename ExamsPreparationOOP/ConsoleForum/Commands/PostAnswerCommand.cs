namespace ConsoleForum.Commands
{
    using System.Linq;

    using ConsoleForum.Contracts;
    using ConsoleForum.Entities.Posts;

    public class PostAnswerCommand : AbstractCommand
    {
        public PostAnswerCommand(IForum forum)
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
            int id = ++Answer.AnswerCount;
            string body = this.Data[1];
            
            Answer answer = new Answer(id, body,this.Forum.CurrentUser);
            this.Forum.CurrentQuestion.Answers.Add(answer);
            this.Forum.Output.AppendFormat(Messages.PostAnswerSuccess, id).AppendLine();
        }
    }
}
