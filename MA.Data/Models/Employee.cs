﻿
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MA.Data.Models
{
	public class Employee
	{
		public int Id { get; set; }

		[Required]
		[StringLength(20)]
		public string emptagno { get; set; }

		[Required]
		[StringLength(50)]
		public string firstname { get; set; }

		[Required]
		[StringLength(50)]
		public string lastname { get; set; }

		[Required]
		[EmailAddress]
		[StringLength(100)]
		public string email { get; set; }

		[Required]
		[JsonConverter(typeof(JsonStringEnumConverter))]
		public Department department { get; set; }

		[Required]
		public DateTime birthdate { get; set; }

		[Required]
		[JsonConverter(typeof(JsonStringEnumConverter))]
		public Designation designation { get; set; }
	}
}
