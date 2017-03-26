namespace Store.ViewModels
{
    using System.Collections.Generic;

    public class BaseViewModel
    {
        public BaseViewModel()
        {
            this.Init();
        }

        public List<KeyValuePair<string, string>> ValidationErrors { get; set; }

        public string Mode { get; set; }

        public bool IsValid { get; set; }

        public string EventCommand { get; set; }

        public string EventArgument { get; set; }

        public bool IsDetailAreaVisible { get; set; }

        public bool IsListAreaVisible { get; set; }

        public bool IsSearchAreaVisible { get; set; }

        protected virtual void Init()
        {
            this.EventCommand = "List";
            this.EventArgument = string.Empty;
            this.ValidationErrors = new List<KeyValuePair<string, string>>();

            this.ListMode();
        }

        protected virtual void Get()
        {
        }

        public virtual void HandleRequest()
        {
            switch (this.EventCommand.ToLower())
            {
                case "list":
                case "search":
                    this.Get();
                    break;

                case "add":
                    this.Add();
                    break;

                case "edit":
                    this.IsValid = true;
                    this.Edit();
                    break;

                case "delete":
                    this.ResetSearch();
                    this.Delete();
                    break;

                case "save":
                    this.Save();
                    this.Get();
                    break;

                case "cancel":
                    this.ListMode();
                    this.Get();
                    break;

                case "resetsearch":
                    this.ResetSearch();
                    this.Get();
                    break;
            }
        }

        protected virtual void ListMode()
        {
            this.IsValid = true;
            this.IsDetailAreaVisible = false;
            this.IsListAreaVisible = true;
            this.IsSearchAreaVisible = true;

            this.Mode = "List";
        }

        protected virtual void AddMode()
        {
            this.IsDetailAreaVisible = true;
            this.IsListAreaVisible = false;
            this.IsSearchAreaVisible = false;

            this.Mode = "Add";
        }

        protected virtual void EditMode()
        {
            this.IsDetailAreaVisible = true;
            this.IsListAreaVisible = false;
            this.IsSearchAreaVisible = false;
            
            this.Mode = "Edit";
        }

        protected virtual void Add()
        {
            this.AddMode();
        }

        protected virtual void Edit()
        {
            this.EditMode();
        }

        protected virtual void Delete()
        {
            this.ListMode();
        }

        protected virtual void Save()
        {
            if (this.ValidationErrors.Count > 0)
            {
                this.IsValid = false;
            }

            if (!this.IsValid)
            {
                if (this.Mode == "Add")
                {
                    this.AddMode();
                }
                else
                {
                    this.EditMode();
                }
            }
        }

        protected virtual void ResetSearch()
        {
        }
    }
}
