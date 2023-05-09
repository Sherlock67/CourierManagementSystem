using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierSystemDataLayer.Model
{
    public class Paging<T> : List<T> 
    { 
        public int PageIndex { get; set; }

        public int TotalPages { get; set; }

        public Paging(List<T> items ,int count,int pageIndex,int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);
        }

        public bool HasPrevious => (PageIndex > 1);

        public bool HasNext => (PageIndex < TotalPages);
        public static Paging<T> Create(List<T> source, int pageIndex,int pageSize)
        {
            var count = source.Count;
            var items = source.Skip((pageIndex - 1)*pageSize).Take(pageSize).ToList();
        
            return new Paging<T>(items, count, pageIndex, pageSize);
        }


    }
    
}
