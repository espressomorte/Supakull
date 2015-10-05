using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupakullTrackerServices
{
    public class DBAdapter : IAdapter
    {
        public IList<ITask> GetAllTasks()
        {
            IList<ITask> tasks = new List<ITask>();

            var clientFactory = new NhibernateSessionFactory("Client.hibernate.cfg.xml").SessionFactory;
            using (var session = clientFactory.OpenSession())
            {
                List<Issue> issues = session.Query<Issue>().ToList<Issue>();
                foreach (Issue issue in issues)
                {
                    TaskMain task = new TaskMain();
                    task.TaskID = issue.issueUFID;
                    task.Summary = issue.summary;
                    task.SubtaskType = issue.type;
                    task.Status = issue.status;
                    task.Priority = issue.priority;
                    tasks.Add(task);
                }
            }
            return tasks;
        }

        public ITask GetTask(int index)
        {
            throw new NotImplementedException();
        }
    }
}