using OnlineShoppingStore.DAL;
using OnlineShoppingStore.Repository;
using PagedList;
using PagedList.Mvc;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore.Models.Home
{
    public class HomeIndexViewModel
    {
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();

        dbMyOnlineShoppingEntities context = new dbMyOnlineShoppingEntities();

        public IPagedList<Tbl_Product> ListOfProducts { get; set; }

        public HomeIndexViewModel CreateModel(string search, int PageSize, int? page)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@search",search??(object)DBNull.Value)
            };
            IPagedList<Tbl_Product> data = context.Database.SqlQuery<Tbl_Product>("GetBySearch @search", param).ToList().ToPagedList(page ?? 1, PageSize);
            return new HomeIndexViewModel()
            {
                ListOfProducts = data
            };
        }
    }
}