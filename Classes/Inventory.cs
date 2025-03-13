using Godot;
using System.Collections.Generic;

public partial class Inventory : Node
{
	public List<Items.Item> Storage;

	public void AddItem(Items.Item item)
	{
		if (Storage.Contains(item)) item.IncreaseAmount();
		else Storage.Add(item);
	}

	public bool UseItem(Items.Item item)
	{
		if (Storage.Contains(item))
		{
			if (item.Disposable == false)
			{
				return true;
			}
			else
			{
				if (item.Amount > 1)
				{
					item.DecreaseAmount();
					Storage[Storage.FindIndex((i) =>
					{
						return i.Name == item.Name;
					})] = item;
				}
				else
				{
					Storage.Remove(item);
				}
				return true;
			}
		}
		else return false;
	}
}
