﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MySqlContext.Entities;

namespace MySqlContext.Interface.Articles
{
    public interface IArticleRepository
    {
        /// <summary>
        /// Data context entity for Article table
        /// </summary>
        DbSet<article> Entity
        {
            get;
        }

        /// <summary>
        /// Data context entity for ArticleLocate table
        /// </summary>
        DbSet<articleloc> EntityArticlesLocate
        {
            get;
        }

        /// <summary>
        /// Search all article by category
        /// </summary>
        /// <param name="categoryesId">Identificaion category</param>
        /// <returns>Article model</returns>
        IQueryable<article> FindByCategoryes(List<long> categoryesId);

        /// <summary>
        /// Search all article by date
        /// </summary>
        /// <param name="date">Date create record in article table</param>
        /// <returns>Article model</returns>
        IQueryable<article> FindByDate(DateTime date);

        /// <summary>
        /// Search all article by List Ids
        /// </summary>
        /// <param name="articleIds">List all article search Id</param>
        /// <returns>Article model</returns>
        IQueryable<article> FindByIds(List<int> articleIds);
    }
}
