namespace Abc.Domain.Common {

    public interface IFiltering {
        string SearchString { get; set; }
        string CurrentFilter { get; set; }
        string FixedFilter { get; set; }
        string FixedValue { get; set; }
    }
}