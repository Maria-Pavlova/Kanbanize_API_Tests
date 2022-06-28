
using NUnit.Framework;
using RestSharp;
using System;
using System.IO;
using System.Net;
using System.Xml.Serialization;

namespace Kanbanize_API_Tests
{
    public class KanbanizeTests
    {
        const string BaseUrl = "https://job.kanbanize.com/index.php/api/kanbanize";
        private RestClient client;
        private RestRequest request;
        private string id;
        private string taskTitle; 

        [SetUp]
        public void Setup()
        {

            this.client = new RestClient();
        }

        [Test, Order(1)]
        public void Test_Create_Valid_Card()
        {
            request = new RestRequest(BaseUrl + "/create_new_task/", Method.Post);
            request.AddHeader("apikey", "KFUHGLAV3H6aP9RSfsUsxmKmnkVuKm8zQyXbMAx7");

            taskTitle = "New Test task by VS" + DateTime.Now.Ticks;
            string taskDescription = "task description";
            string taskPriority = "High";
            string assignee = "Maria";
            string taskColumn = "Requested";
            string taskPosition = "1";


            var body = new
            {
                boardid = "1",
                title = taskTitle,
                description = taskDescription,
                priority = taskPriority,
                assignee = assignee,
                column = taskColumn,
                position = taskPosition
            };

            request.AddJsonBody(body);
            var response = client.Execute(request);
            XmlSerializer serializer = new XmlSerializer(typeof(Xml));
            StringReader sr = new StringReader(response.Content);
            Xml XmlData = (Xml)serializer.Deserialize(sr);

            id = XmlData.Id.ToString();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var requestDetails = new RestRequest(BaseUrl + "/get_task_details/", Method.Post);
            requestDetails.AddHeader("apikey", "KFUHGLAV3H6aP9RSfsUsxmKmnkVuKm8zQyXbMAx7");
          
            var bodyDetails = new
            {
                boardid = "1",
                taskid = id
            };

            requestDetails.AddJsonBody(bodyDetails);
            var responseDetails = client.Execute(requestDetails);

            XmlSerializer serializerD = new XmlSerializer(typeof(Xml));
            StringReader stringReader = new StringReader(responseDetails.Content);
            Xml XmlDetails = (Xml)serializerD.Deserialize(stringReader);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(taskTitle, XmlDetails.Title);
            Assert.AreEqual(taskDescription, XmlDetails.Description);
            Assert.AreEqual(taskPriority, XmlDetails.Priority);
            Assert.AreEqual(taskColumn, XmlDetails.Columnname);
            Assert.AreEqual(taskPosition, XmlDetails.Position);
          
        }

       
     

        [Test, Order(2)]
        public void Test_Move_Card()
        {
            request = new RestRequest(BaseUrl + "/move_task/", Method.Post);
            request.AddHeader("apikey", "KFUHGLAV3H6aP9RSfsUsxmKmnkVuKm8zQyXbMAx7");

            var body = new
            {
                boardid = "1",
                taskid = id,
                position = "2",
                
            };

            request.AddJsonBody(body);
            var response = client.Execute(request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var requestDetails = new RestRequest(BaseUrl + "/get_task_details/", Method.Post);
            requestDetails.AddHeader("apikey", "KFUHGLAV3H6aP9RSfsUsxmKmnkVuKm8zQyXbMAx7");

            var bodyDetails = new
            {
                boardid = "1",
                taskid = id
            };

            requestDetails.AddJsonBody(bodyDetails);
            var responseDetails = client.Execute(requestDetails);

            XmlSerializer serializerD = new XmlSerializer(typeof(Xml));
            StringReader stringReader = new StringReader(responseDetails.Content);
            Xml XmlDetails = (Xml)serializerD.Deserialize(stringReader);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(taskTitle, XmlDetails.Title);
            Assert.AreEqual("2", XmlDetails.Position);
        }

        [Test, Order(3)]
        public void Test_Delete_Task()
        {
            request = new RestRequest(BaseUrl + "/delete_task/", Method.Post);
            request.AddHeader("apikey", "KFUHGLAV3H6aP9RSfsUsxmKmnkVuKm8zQyXbMAx7");

            var body = new
            {
                boardid = "1",
                taskid = id

            };

            request.AddJsonBody(body);
            var response = client.Execute(request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }


        [Test, Order(4)]
        public void Test_Check_Card_Deleted()
        {
            request = new RestRequest(BaseUrl + "/get_task_details/", Method.Post);
            request.AddHeader("apikey", "KFUHGLAV3H6aP9RSfsUsxmKmnkVuKm8zQyXbMAx7");

            var body = new
            {
                boardid = "1",
                taskid = id

            };

            request.AddJsonBody(body);
            var response = client.Execute(request);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.That(response.Content.Contains("The specified task does not exist."));
        }
    }
}