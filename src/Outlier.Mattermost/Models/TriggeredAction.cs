using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Outlier.Mattermost.Models
{

	public class TriggeredAction
	{

		[JsonPropertyName("channel_id")]
		public string ChannelId { get; set; }


		[JsonPropertyName("channel_name")]
		public string ChannelName { get; set; }


		[JsonPropertyName("context")]
		public TriggeredActionContextBase Context { get; set; }


		[JsonPropertyName("data_source")]
		public string DataSource { get; set; }


		[JsonPropertyName("post_id")]
		public string PostId { get; set; }


		[JsonPropertyName("team_domain")]
		public string TeamDomain { get; set; }


		[JsonPropertyName("team_id")]
		public string TeamId { get; set; }


		[JsonPropertyName("trigger_id")]
		public string TriggerId { get; set; }


		[JsonPropertyName("type")]
		public string Type { get; set; }


		[JsonPropertyName("user_id")]
		public string UserId { get; set; }


		[JsonPropertyName("user_name")]
		public string UserName { get; set; }

	}


	/// <summary>
	/// TriggeredAction que puede recibir un context como objeto genérico
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class TriggeredAction<T> : TriggeredAction
	{

		/// <summary>
		/// Para hacerlo más simple puede heredar de TriggeredActionContextBase
		/// </summary>
		[JsonPropertyName("context")]
		public new T Context { get; set; }

	}


	public class TriggeredActionContextBase
	{

		[JsonPropertyName("action")]
		public string Action { get; set; }


		[JsonPropertyName("selected_option")]
		public string SelectedOption { get; set; }

	}

}
