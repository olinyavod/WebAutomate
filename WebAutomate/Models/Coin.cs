namespace WebAutomate.Models
{
	public class Coin : EntityBase
	{
		public decimal Nominal { get; set; }

		public int Count { get; set; }

		public bool IsBlocked { get; set; }
	}
}