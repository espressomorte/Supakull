using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupakullTrackerServices;

namespace TrelloTestApp
{

    public class TrelloTask : ITask
    {
        #region Fields
        private string _taskID;
        private string _subtaskType;
        private string _summary;
        private string _description;
        private ITask _taskParent;
        private string _status;
        private string _priority;
        private string _product;
        private string _project;
        private List<string> _assigned = new List<string>();
        private string _createdDate;
        private string _createdBy;
        private string _linkToTracker;
        private string _estimation;
        private string _targetVersion;
        private string _comments;
        private List<ITask> _tasks = new List<ITask>();
        #endregion

        #region Properties
        //public List<string> Assigned
        //{
        //    get
        //    {
        //        return _assigned;
        //    }

        //    set
        //    {
        //        _assigned = value;
        //    }
        //}

        public string Comments
        {
            get
            {
                return _comments;
            }

            set
            {
                _comments = value;
            }
        }

        public string CreatedBy
        {
            get
            {
                return _createdBy;
            }

            set
            {
                _createdBy = value;
            }
        }

        public string CreatedDate
        {
            get
            {
                return _createdDate;
            }

            set
            {
                _createdDate = value;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
            }
        }

        public string Estimation
        {
            get
            {
                return _estimation;
            }

            set
            {
                _estimation = value;
            }
        }

        public string LinkToTracker
        {
            get
            {
                return _linkToTracker;
            }

            set
            {
                _linkToTracker = value;
            }
        }

        public string Priority
        {
            get
            {
                return _priority;
            }

            set
            {
                _priority = value;
            }
        }

        public string Product
        {
            get
            {
                return _product;
            }

            set
            {
                _product = value;
            }
        }

        public string Project
        {
            get
            {
                return _project;
            }

            set
            {
                _project = value;
            }
        }

        public string Status
        {
            get
            {
                return _status;
            }

            set
            {
                _status = value;
            }
        }

        public string SubtaskType
        {
            get
            {
                return _subtaskType;
            }

            set
            {
                _subtaskType = value;
            }
        }

        public string Summary
        {
            get
            {
                return _summary;
            }

            set
            {
                _summary = value;
            }
        }

        public string TargetVersion
        {
            get
            {
                return _targetVersion;
            }

            set
            {
                _targetVersion = value;
            }
        }

        public string TaskID
        {
            get
            {
                return _taskID;
            }

            set
            {
                _taskID = value;
            }
        }

        public ITask TaskParent
        {
            get
            {
                return _taskParent;
            }

            set
            {
                _taskParent = value;
            }
        }

        public IList<User> Assigned { get; set; }
        

        //public IList<UsersList> Assigned
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }

        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
        #endregion
    }

}
