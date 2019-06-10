using git.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace git.Model.Model
{
    public class PagingSortingModel
    {
        public  int PageSize { get; set; } = AppConstants.DefaultPageSize;
        public  int PageNumber { get; set; } = AppConstants.DefaultPageNumber;
        public  string SortProperty { get; set; } = AppConstants.DefaultSortProperty;
        public  string SortOrder { get; set; } = AppConstants.DefaultSortOrder;
        public  bool SortAscending { get; set; } = false;
        public  bool SortDescending { get; set; } = true;



    }
}
