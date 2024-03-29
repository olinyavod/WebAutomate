﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAutomate.Models
{
	public class Product : EntityBase
	{
		public string Name { get; set; }

		public string ImageUrl { get; set; }

		public decimal Price { get; set; }

		public int Count { get; set; }
	}
}
