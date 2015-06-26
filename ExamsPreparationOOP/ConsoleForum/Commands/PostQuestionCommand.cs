namespace ConsoleForum.Commands
{
    using System;

    using ConsoleForum.Contracts;
    using ConsoleForum.Entities.Posts;

    public class PostQuestionCommand : AbstractCommand
    {
        public PostQuestionCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            if (!this.Forum.IsLogged)
            {
                throw new CommandException(Messages.NotLogged);
            }

            string title = this.Data[1];
            string body = this.Data[2];

            this.Forum.Questions.Add(new Question(++Question.QuestionCount, body,this.Forum.CurrentUser,title));
            this.Forum.Output.AppendFormat(Messages.PostQuestionSuccess, this.Forum.Questions.Count).AppendLine();
        }
    }
}
