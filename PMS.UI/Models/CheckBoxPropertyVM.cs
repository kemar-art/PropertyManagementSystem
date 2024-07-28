namespace PMS.UI.Models
{
    public class CheckBoxPropertyVM
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public bool IsChecked { get; set; } = false;
    }
}
