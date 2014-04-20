namespace DigitalResourcesLibrary.DataContext.Helper
{
    public static class DocumentsHelper
    {
        private static int _count = 10;

        public static int CountNewsOnPage
        {
            get { return _count; } 
            set { _count = value; }
        }
    }
}
