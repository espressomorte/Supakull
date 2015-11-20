using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupakullTrackerServices;
using TrelloNet;
using TrelloNet.Extensions;
using TrelloTestApp;

namespace TrelloManagerApp
{
    public class TrelloManager : IAdapter
    {
        private static Trello _trello = new Trello(Constants.trelloAppToken);

        public TrelloManager(string userToken)
        {
            _trello.Authorize(userToken);
        }

        public IList<ITask> GetAllTasks()
        {
            var boards = _trello.Boards.ForMe();
            var tasks = new List<ITask>();

            foreach (var board in boards)
            {
                if ((!board.Closed) && !(board.Name == "Welcome Board"))
                {
                    var cards = _trello.Cards.ForBoard(board);
                    foreach (var card in cards)
                    {
                        tasks.Add(GetTasksFromCard(card));
                    }
                }
            }

            return tasks;

        }

        public IAccountSettings TestAccount(IAccountSettings accountnForTest)
        {
            throw new NotImplementedException();
        }

        //IList<ITask> IAdapter.GetAllItems()
        //{
        //    throw new NotImplementedException();
        //}

        ITask IAdapter.GetTask(int index)
        {
            throw new NotImplementedException();
        }

        private ITask GetTasksFromCard(Card card)
        {
            var task = new TaskMain();
            try
            {
                task.TaskID = card.Name.Substring(card.Name.IndexOf("<") + 1, card.Name.IndexOf(">") - card.Name.IndexOf("<") - 1);
                task.Summary = card.Name.Remove(card.Name.IndexOf("<"), card.Name.IndexOf(">") - card.Name.IndexOf("<") + 1);
            }
            catch (System.ArgumentOutOfRangeException)
            {
                task.TaskID = "Please enter TaskId in brackets(<>)";
                task.Summary = card.Name;
            }
            task.Assigned = null;
            //foreach (var member in _trello.Members.ForCard(card))
            //{
            //    task.Assigned.Add(member.FullName);
            //}
            task.Description = card.Desc;
            task.Status = _trello.Lists.ForCard(card).Name;
            task.Project = _trello.Boards.ForCard(card).Name;
            task.Priority = card.Badges.Votes.ToString();
            task.TargetVersion = card.Due.ToString();
            var comments = _trello.Actions
                 .AutoPaged(Paging.MaxLimit)
                 .ForCard(card, new[] { ActionType.CommentCard })
                 .OfType<CommentCardAction>();
            foreach (var comment in comments)
            {
                task.Comments = task.Comments + comment.Data.Text + " :By "+ comment.MemberCreator.FullName+" At: "+comment.Date.ToString()+"; ";
            }
            task.LinkToTracker = Sources.Trello;
            return task;
        }
    }
}

