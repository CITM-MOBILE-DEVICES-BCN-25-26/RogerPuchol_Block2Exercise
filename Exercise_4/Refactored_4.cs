namespace Assignment.Exercise_4;

// ---- UI component declaration ----

public interface IUIClickable
{
	void OnClick();
}

public interface IUIHoverable
{
	void OnHover();
}

public interface IUIDraggable
{
	void OnDrag();
}

// ---- UI component definition ----

public class InventoryButton : IUIClickable, IUIHoverable
{
	public void OnClick()
	{
		Console.WriteLine("Inventory button clicked");
	}

	public void OnHover()
	{
		Console.WriteLine("Inventory button hover");
	}
}

public class InventoryItemSlot : IUIHoverable, IUIDraggable
{

	public void OnHover()
	{
		Console.WriteLine("Item slot hover");
	}

	public void OnDrag()
	{
		Console.WriteLine("Dragging item slot");
	}
}

// ---- Program entry point ----

public static class Program
{
	public static void EntryPoint()
	{
		InventoryButton button = new InventoryButton();
		button.OnClick();
		button.OnHover();
		
		InventoryItemSlot slot = new InventoryItemSlot();
		slot.OnHover();
		slot.OnDrag();
	}
}