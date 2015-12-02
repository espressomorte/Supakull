using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupakullTrackerServices;
using TrelloNet;
using TrelloNet.Extensions;
using TrelloTestApp;

namespace SupakullTrackerServices
{
    public class TrelloManager : IAdapter
    {
        private static Trello _trello = new Trello(Constants.trelloAppToken);
        private string BoardID { get; set; }
        private string UserToken { get; set; }

        public IAdapter GetAdapter(IAccountSettings account)
        {
            TrelloAccountSettings accountForTestTrello = (TrelloAccountSettings)account;
            TrelloAccountToken Token = accountForTestTrello.Tokens.FirstOrDefault();
            TrelloManager adapter = new TrelloManager();
            adapter.UserToken = Token.UserToken;
            adapter.BoardID = Token.BoardID;
            return adapter;
        }


        //public TrelloManager(ServiceAccountDTO account)
        //{
        //    _trello.Authorize(account.UserAccountToken);
        //    foreach (var token in account.Tokens)
        //    {
        //        string IdBoard = (from tok in token.Tokens where tok.Key == "IdBoard" select tok.Value).SingleOrDefault();
        //        boards.Add(_trello.Boards.WithId(IdBoard));
        //    }
        //}

        public IList<ITask> GetAllTasks()
        {
            _trello.Authorize("ded104e76f80e7dbe0c3f9ecc8f3591ee32af8fdfa90d32441380ccb1fcd35ee");
            var tasks = new List<ITask>();
            
            var board = _trello.Boards.WithId("5602aee31ad8c2c5de6fedb9");
            // var board = _trello.Boards.WithId(boardId);
            var cards = _trello.Cards.ForBoard(board);
            foreach (var card in cards)
                {
                   tasks.Add(GetTasksFromCard(card));
                }
            return tasks;

        }

        public IAccountSettings TestAccount(IAccountSettings accountnForTest)
        {
            TrelloAccountSettings accountForTestTrello = (TrelloAccountSettings)accountnForTest;
            TrelloAccountToken testToken = accountForTestTrello.Tokens.FirstOrDefault();
            accountForTestTrello.Tokens.Clear();
            _trello.Authorize(testToken.UserToken);
            try
            {
                accountForTestTrello.TestResult = true;
                accountForTestTrello.Source = Sources.Trello;
                var boards = _trello.Boards.ForMe();
                foreach (var board in boards)
                {
                    TrelloAccountToken newToken = new TrelloAccountToken();
                    newToken.BoardID = board.Id;
                    newToken.TokenName = board.Name;
                    newToken.UserToken = testToken.UserToken;
                    newToken.DateCreation = DateTime.Now;
                    accountForTestTrello.Tokens.Add(newToken);
                }
            }
            catch (Exception)
            {

                accountForTestTrello.TestResult = false;
            }
            
            return accountForTestTrello;
        }

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

