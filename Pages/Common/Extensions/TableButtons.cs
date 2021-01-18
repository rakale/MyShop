namespace Abc.Pages.Common.Extensions {
    public class TableButtons {

        public TableButtons(string select, string edit, string details, string delete) {
            Select = select;
            Edit = edit;
            Details = details;
            Delete = delete;
        }
        public string Select { get; private set; }
        public string Edit { get; private set; }
        public string Details { get; private set; }
        public string Delete { get; private set; }
    }
}