﻿ using Dataaccesslayer;

using hospitalIrepreatory;

using hospitalUtilities;

using hospitalVm;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using PagedList;

using System.Linq.Expressions;

namespace hospitalservess
{

    public  class PaginationHelper <T>: IPaginationHelper<T> where T : class
    {
        public  IPagedList<T> GetPagedData<T>(IEnumerable<T> data, int pageNumber)
        {
            int pageSize = 10; // Set the page size to 10
            int totalItemCount = data.Count();
            int totalPages = (int)Math.Ceiling(totalItemCount / (double)pageSize);

            pageNumber = Math.Max(1, Math.Min(totalPages, pageNumber));

            int startIndex = (pageNumber - 1) * pageSize;
            int endIndex = Math.Min(startIndex + pageSize - 1, totalItemCount - 1);

            var pagedData = data.Skip(startIndex).Take(pageSize).ToList();

            return new StaticPagedList<T>(pagedData, pageNumber, pageSize, totalItemCount);


        }
    }




}






