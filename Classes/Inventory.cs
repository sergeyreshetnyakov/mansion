using Godot;
using System;
using System.Collections.Generic;

public partial class Inventory : Node
{
	public List<string> Storage;

	public void AddItem(string item) {
		Storage.Add(item);
	}

	public void UseItem(string item) {
	}
}
