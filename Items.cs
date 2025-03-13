using Godot;

public partial class Items : Node
{
	public struct Item(string name, bool disposable, int amount)
    {
        public string Name { get; } = name;
        public bool Disposable { get; } = disposable;
        public int Amount { get; set; } = amount;

        public void IncreaseAmount()
		{
			Amount++;
		}

		public void DecreaseAmount()
		{
			Amount--;
		}

	}

	public Item Gun = new("gun", true, 1);
	public Item Flashlight = new("flashlight", true, 1);

	public Item Bullet = new("bullet", false, 1);
	public Item Medicine = new("medicine", false, 1);

	public Item Crowbar = new("crowbar", true, 1);
	public Item AquaRegia = new("aqua regia", true, 1);
	public Item TestTube = new("test tube", true, 1); 

	public Item SpecialSolution = new("special solution", false, 1);
	public Item LostBook = new("lost book", false, 1);
	public Item StrangeMushroom = new("strange mushroom", false, 1);
	public Item GhostOrchid = new("ghost orchid", false, 1);
}
