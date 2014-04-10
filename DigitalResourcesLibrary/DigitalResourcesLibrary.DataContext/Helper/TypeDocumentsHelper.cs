using System;
using DigitalResourcesLibrary.DataContext.Enums;

namespace DigitalResourcesLibrary.DataContext.Helper
{
    public static class TypeDocumentsHelper
    {
        private const string Article = "article";
        private const string Store = "store";

        public static TypeDocument GeTypeDocument(string typeDocumentsString)
        {
            if (String.Compare(typeDocumentsString, Article, StringComparison.CurrentCultureIgnoreCase) == 0)
            {
                return TypeDocument.Article;
            }
            return TypeDocument.Store;
        }

        public static string GeTypeDocument(TypeDocument typeDocuments)
        {
            if (typeDocuments == TypeDocument.Article)
            {
                return Article;
            }
            return Store;
        }
    }
}
