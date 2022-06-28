
using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace Kanbanize_API_Tests
{
	[XmlRoot(ElementName = "xml")]
	public class Xml
	{
		[XmlElement(ElementName = "id")]
		public string Id { get; set; }
		[XmlElement(ElementName = "taskid")]
		public string Taskid { get; set; }
		[XmlElement(ElementName = "boardid")]
		public string Boardid { get; set; }
		[XmlElement(ElementName = "title")]
		public string Title { get; set; }
		[XmlElement(ElementName = "description")]
		public string Description { get; set; }
		[XmlElement(ElementName = "type")]
		public string Type { get; set; }
		[XmlElement(ElementName = "assignee")]
		public string Assignee { get; set; }
		[XmlElement(ElementName = "subtasks")]
		public string Subtasks { get; set; }
		[XmlElement(ElementName = "subtaskscomplete")]
		public string Subtaskscomplete { get; set; }
		[XmlElement(ElementName = "color")]
		public string Color { get; set; }
		[XmlElement(ElementName = "priority")]
		public string Priority { get; set; }
		[XmlElement(ElementName = "size")]
		public string Size { get; set; }
		[XmlElement(ElementName = "deadline")]
		public string Deadline { get; set; }
		[XmlElement(ElementName = "deadlineoriginalformat")]
		public string Deadlineoriginalformat { get; set; }
		[XmlElement(ElementName = "extlink")]
		public string Extlink { get; set; }
		[XmlElement(ElementName = "tags")]
		public string Tags { get; set; }
		[XmlElement(ElementName = "leadtime")]
		public string Leadtime { get; set; }
		[XmlElement(ElementName = "blocked")]
		public string Blocked { get; set; }
		[XmlElement(ElementName = "blockedreason")]
		public string Blockedreason { get; set; }
		[XmlElement(ElementName = "columnname")]
		public string Columnname { get; set; }
		[XmlElement(ElementName = "lanename")]
		public string Lanename { get; set; }
		[XmlElement(ElementName = "subtaskdetails")]
		public string Subtaskdetails { get; set; }
		[XmlElement(ElementName = "columnid")]
		public string Columnid { get; set; }
		[XmlElement(ElementName = "laneid")]
		public string Laneid { get; set; }
		[XmlElement(ElementName = "position")]
		public string Position { get; set; }
		[XmlElement(ElementName = "workflow")]
		public string Workflow { get; set; }
		[XmlElement(ElementName = "workflow_id")]
		public string Workflow_id { get; set; }
		[XmlElement(ElementName = "attachments")]
		public string Attachments { get; set; }
		[XmlElement(ElementName = "columnpath")]
		public string Columnpath { get; set; }
		[XmlElement(ElementName = "customfields")]
		public string Customfields { get; set; }
		[XmlElement(ElementName = "updatedat")]
		public string Updatedat { get; set; }
		[XmlElement(ElementName = "loggedtime")]
		public string Loggedtime { get; set; }
		[XmlElement(ElementName = "reporter")]
		public string Reporter { get; set; }
	}

}
