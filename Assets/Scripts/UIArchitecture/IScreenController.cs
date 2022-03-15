public interface IScreenController<TProperty>
{
    public void Show();
    public void Show(TProperty property);
    public void Hide();
    public string GetId();
    public bool GetActive();
}
