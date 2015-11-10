using NUnit.Framework;
using SupakullTrackerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestServices.Converters
{
    [TestFixture]
    public class ConverterDAOtoDomainTest
    {
        [Test]
        public void ConverterDAOtoDomain_ReturnCorrectData()
        {
            TaskMainDAO taskMainDAO1 = GetTaskMainDAOItem("1");

            TaskMainDAO taskMainDAO2 = GetTaskMainDAOItem("2");
            UserDAO userDAO1 = GetUserDaoItem("1");
            IList<UserDAO> assigned = new List<UserDAO>();
            assigned.Add(userDAO1);

            taskMainDAO1.Assigned = assigned;
            taskMainDAO1.TaskParent = taskMainDAO2;
            
            IList<TaskMainDAO> taskMainDaoCollection = new List<TaskMainDAO>();
            taskMainDaoCollection.Add(taskMainDAO1);

            // Actual Item
            IList<ITask> taskMainCollection = SupakullTrackerServices.ConverterDAOtoDomain.TaskMainDaoToTaskMainCollection(taskMainDaoCollection);
            ITask taskMainActual = taskMainCollection[0];

            StringAssert.Contains(taskMainDAO1.TaskID, taskMainActual.TaskID, "TaskID is not correct");
            StringAssert.Contains(taskMainDAO1.TargetVersion, taskMainActual.TargetVersion, "TargetVersion is not correct");
            StringAssert.Contains(taskMainDAO1.Summary, taskMainActual.Summary, "Summary is not correct");
            StringAssert.Contains(taskMainDAO1.SubtaskType, taskMainActual.SubtaskType, "SubtaskType is not correct");
            StringAssert.Contains(taskMainDAO1.Status, taskMainActual.Status, "Status is not correct");
            StringAssert.Contains(taskMainDAO1.Project, taskMainActual.Project, "Project is not correct");
            StringAssert.Contains(taskMainDAO1.Product, taskMainActual.Product, "Product is not correct");
            StringAssert.Contains(taskMainDAO1.Priority, taskMainActual.Priority, "Priority is not correct");
            StringAssert.Contains(taskMainDAO1.LinkToTracker.ToString(), taskMainActual.LinkToTracker.ToString(), "LinkToTracker is not correct");
            StringAssert.Contains(taskMainDAO1.Estimation, taskMainActual.Estimation, "Estimation is not correct");
            StringAssert.Contains(taskMainDAO1.Description, taskMainActual.Description, "Description is not correct");
            StringAssert.Contains(taskMainDAO1.CreatedDate, taskMainActual.CreatedDate, "CreatedDate is not correct");
            StringAssert.Contains(taskMainDAO1.CreatedBy, taskMainActual.CreatedBy, "CreatedBy is not correct");
            StringAssert.Contains(taskMainDAO1.Comments, taskMainActual.Comments, "Comments is not correct");

            User userActual = taskMainActual.Assigned[0];
            StringAssert.Contains(userDAO1.UserId, userActual.UserId, "UserId is not correct");
            StringAssert.Contains(userDAO1.UserName, userActual.UserName, "UserName is not correct");

            ITask taskParentActual = taskMainActual.TaskParent;
            StringAssert.Contains(taskMainDAO2.TaskID, taskParentActual.TaskID, "TaskID is not correct");
            StringAssert.Contains(taskMainDAO2.TargetVersion, taskParentActual.TargetVersion, "TargetVersion is not correct");
            StringAssert.Contains(taskMainDAO2.Summary, taskParentActual.Summary, "Summary is not correct");
            StringAssert.Contains(taskMainDAO2.SubtaskType, taskParentActual.SubtaskType, "SubtaskType is not correct");
            StringAssert.Contains(taskMainDAO2.Status, taskParentActual.Status, "Status is not correct");
            StringAssert.Contains(taskMainDAO2.Project, taskParentActual.Project, "Project is not correct");
            StringAssert.Contains(taskMainDAO2.Product, taskParentActual.Product, "Product is not correct");
            StringAssert.Contains(taskMainDAO2.Priority, taskParentActual.Priority, "Priority is not correct");
            StringAssert.Contains(taskMainDAO2.LinkToTracker.ToString(), taskParentActual.LinkToTracker.ToString(), "LinkToTracker is not correct");
            StringAssert.Contains(taskMainDAO2.Estimation, taskParentActual.Estimation, "Estimation is not correct");
            StringAssert.Contains(taskMainDAO2.Description, taskParentActual.Description, "Description is not correct");
            StringAssert.Contains(taskMainDAO2.CreatedDate, taskParentActual.CreatedDate, "CreatedDate is not correct");
            StringAssert.Contains(taskMainDAO2.CreatedBy, taskParentActual.CreatedBy, "CreatedBy is not correct");
            StringAssert.Contains(taskMainDAO2.Comments, taskParentActual.Comments, "Comments is not correct");
        }

        private TaskMainDAO GetTaskMainDAOItem(string postfix)
        {
            TaskMainDAO taskMainDAO = new TaskMainDAO();
            taskMainDAO.TaskID = string.Format("ID{0}", postfix);
            taskMainDAO.TargetVersion = string.Format("TargetVersion{0}", postfix);
            taskMainDAO.Summary = string.Format("Summary{0}", postfix);
            taskMainDAO.SubtaskType = string.Format("SubtaskType{0}", postfix);
            taskMainDAO.Status = string.Format("Status{0}", postfix);
            taskMainDAO.Project = string.Format("Project{0}", postfix);
            taskMainDAO.Product = string.Format("Product{0}", postfix);
            taskMainDAO.Priority = string.Format("Priority{0}", postfix);
            taskMainDAO.LinkToTracker = Sources.DataBase;
            taskMainDAO.Estimation = string.Format("Estimation{0}", postfix);
            taskMainDAO.Description = string.Format("Description{0}", postfix);
            taskMainDAO.CreatedDate = string.Format("CreatedDate{0}", postfix);
            taskMainDAO.CreatedBy = string.Format("CreatedBy{0}", postfix);
            taskMainDAO.Comments = string.Format("Comments{0}", postfix);
            return taskMainDAO;
        }

        private UserDAO GetUserDaoItem(string postfix)
        {
            string userId = string.Format("UserId{0}", postfix);
            string userName = string.Format("UserName{0}", postfix);
            UserDAO userDAO = new UserDAO(userId, userName);
            
            return userDAO;
        }
    }
}
