using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Outlier.Mattermost.Models
{
	
	public class Action
	{

		[JsonPropertyName("id")]
		public string Id { get; set; }


		[JsonPropertyName("name")]
		public string Name { get; set; }


		[JsonPropertyName("options")]
		public List<Option> Options { get; set; }

		/// <summary>
		/// type = select
		/// </summary>
		[JsonPropertyName("type")]
		public string Type { get; set; }


		[JsonPropertyName("integration")]
		public Integration Integration { get; set; }


		public Action(string id, string name, string url, string action, List<Option> options = null)
		{
			this.Id = id;
			this.Name = name;
			this.Integration = new Integration()
			{
				Url = url,
				Context = new Context()
				{
					Action = action
				}
			};

			if (options != null && options.Count > 0)
			{
				this.Type = "select";
				this.Options = options;
			}
		}

	}

	public class Integration
	{

		[JsonPropertyName("url")]
		public string Url { get; set; }


		[JsonPropertyName("context")]
		public Context Context { get; set; }

	}


	public class Context
	{
		[JsonPropertyName("action")]
		public string Action { get; set; }
	}


	public class Option
	{

		public Option()
		{

		}

		public Option(string text, string value)
		{
			this.Text = text;
			this.Value = value;
		}



		[JsonPropertyName("text")]
		public string Text { get; set; }


		[JsonPropertyName("value")]
		public string Value { get; set; }

	}

}
