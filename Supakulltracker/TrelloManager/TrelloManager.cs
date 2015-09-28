using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrelloNet;
using TrelloNet.Extensions;

namespace TrelloTestApp
{


    public class TrelloManager
    {
        private static Trello _trello = new Trello("6cdb008c803b149196437bf4a8df94a8");

        public TrelloManager(string userToken)
        {
            _trello.Authorize(userToken);
        }

        public List<ITask> GetTasks()
        {
            var boards = _trello.Boards.ForMe();
            var tasks = new List<ITask>();

            foreach (var board in boards)
            {
                if (!board.Closed)
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

        private ITask GetTasksFromCard(Card card)
        {
            var task = new TrelloTask();
            //task.TaskID = card.Name.Substring(card.Name.IndexOf("<")+1,card.Name.IndexOf(">") - card.Name.IndexOf("<")-1);
            //task.Summary = card.Name.Remove(card.Name.IndexOf("<"), card.Name.IndexOf(">") - card.Name.IndexOf("<"));
            foreach (var member in _trello.Members.ForCard(card))
            {
                task.Assigned.Add(member.FullName);
            }
            task.Description = card.Desc;
            task.Status = _trello.Lists.ForCard(card).Name;
            task.Project = _trello.Boards.ForCard(card).Name;
            task.Priority = card.Badges.Votes.ToString();

            task.TargetVersion = card.Due.ToString();
          /*  var comments = _trello.Actions
                 .AutoPaged(Paging.MaxLimit) 
                 .ForCard(card, new[] { ActionType.CommentCard })
                 .OfType<CommentCardAction>()
                 .Select(a => a.Data.Text);
            var strMgs = "Activities:<br/>" + string.Join("<br/>", comments);*/
            task.LinkToTracker = "Trello";
            return task;
        }
    }




   /* class TrelloManager
    {

        #region Fields
        private const string APP_TOKEN = "6cdb008c803b149196437bf4a8df94a8";
        #endregion

        #region Properties
        public ITrello Trello { get; }
        public Uri AuthorizationUrl
        {
            get
            {
                return Trello.GetAuthorizationUrl("TestTrelloApp", Scope.ReadWrite, Expiration.Never);
            }
        }
        #endregion Properties

        #region CTOR
        public TrelloManager()
        {
            Trello = new Trello(APP_TOKEN);
        }
        #endregion

        public void Authorize(string userToken)
        {
            Trello.Authorize(userToken);
            //checking user token
            var me = Trello.Members.Me();
        }

        public void GetData(string userToken)
        {
            var manager = new TrelloManager();
            manager.Authorize(userToken);

        }
    }*/
 /*   class TrelloData : ITask
        {
            private const string APP_TOKEN = "6cdb008c803b149196437bf4a8df94a8";
            public string _TaskID;
            public string _SubtaskType;
            public string _Summary;
            public string _Description;
            public ITask _TaskParent;
            public string _Status;
            public string _Priority;
            public string _Product;
            public string _Project;
            public string[] _Assigned;
            public string _CreatedDate;
            public string _CreatedBy;
            public string _LinkToTracker;
            public string _Estimation;
            public string _TargetVersion;
            public string _Comments;

            public string[] Assigned
            {
                get
                {
                    return _Assigned;
                }

                set
                {
                    value = Assigned;
                }
            }

            public string Comments
            {
                get
                {
                    return _Comments;
                }

                set
                {
                    value = Comments;
                }
            }

            public string CreatedBy
            {
                get
                {
                    return _CreatedBy;
                }

                set
                {
                    value = CreatedBy;
                }
            }

            public string CreatedDate
            {
                get
                {
                    return _CreatedDate;
                }

                set
                {
                    value = CreatedDate;
                }
            }

            public string Description
            {
                get
                {
                    return _Description;
                }

                set
                {
                    value = Description;
                }
            }

            public string Estimation
            {
                get
                {
                    return _Estimation;
                }

                set
                {
                    value = Estimation;
                }
            }

            public string LinkToTracker
            {
                get
                {
                    return _LinkToTracker;
                }

                set
                {
                    value = LinkToTracker;
                }
            }

            public string Priority
            {
                get
                {
                    return _Priority;
                }

                set
                {
                    value = Priority;
                }
            }

            public string Product
            {
                get
                {
                    return _Product;
                }

                set
                {
                    value = Product;
                }
            }

            public string Project
            {
                get
                {
                    return _Project;
                }

                set
                {
                    value = Project;
                }
            }

            public string Status
            {
                get
                {
                    return _Status;
                }

                set
                {
                    value = Status;
                }
            }

            public string SubtaskType
            {
                get
                {
                    return _SubtaskType;
                }

                set
                {
                    value = SubtaskType;
                }
            }

            public string Summary
            {
                get
                {
                    return _Summary;
                }

                set
                {
                    value = Summary;
                }
            }

            public string TargetVersion
            {
                get
                {
                    return _TargetVersion;
                }

                set
                {
                    value = TargetVersion;
                }
            }

            public string TaskID
            {
                get
                {
                    return _TaskID;
                }

                set
                {
                    value = TaskID;
                }
            }

            public ITask TaskParent
            {
                get
                {
                    return _TaskParent;
                }

                set
                {
                    value = TaskParent;
                }
            }
        }
        public  void TrelloData (string userToken)
        {

        }*/
}

