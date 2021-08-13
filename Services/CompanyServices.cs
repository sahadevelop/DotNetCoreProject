using System;
using System.Linq;


namespace TMIDotNetCoreFinalProject.Services
{
    //فراخوانی و درج اطلاعات از طریق سرویس محیا شده که فقط توسط کنترلر صدا زده میشود
    public class CompanyServices:Object
    {
        private static System.Collections.Generic.IList<Models.MyProjectClass.Company> Companies;
        public CompanyServices():base()
        {

        }
        #region Get All --تابع بازگردانی لیست تمامی شرکت ها
        /// <summary>
        /// بازگردانی لیست تمام کاربران
        /// </summary>
        /// <returns>List Of Users</returns>
        public System.Collections.Generic.IList<Models.MyProjectClass.Company> GetAllCompanies()
        {
            System.Collections.Generic.IList<Models.MyProjectClass.Company> companyList = null;


            companyList = Companies.OrderByDescending(x => x.Id).ToList();


            return companyList;

        }
        #endregion 

        #region Get By Id  -- تابع بازگردانی شرکت بر اساس ای دی جدول
        /// <summary>
        /// تابع بازگردانی کاربر بر اساس ای دی جدول
        /// </summary>
        /// <returns>Single User</returns>

        public Models.MyProjectClass.Company GetCompanyById(int? id)
        {
            Models.MyProjectClass.Company company = null;


            return company = Companies.FirstOrDefault(x => x.Id == id);

        }
        #endregion 

        #region Create New Company  -- تابع ایجاد شرکت جدید
        /// <summary>
        /// ایجاد کابر جدید
        /// </summary>
        /// <returns>Create New User</returns>

        public Models.MyProjectClass.Company CreateCompany(Models.MyProjectClass.Company company)
        {

            int incrementId = Companies.Max(x => x.Id) + 1;

            var addedCompany = new Models.MyProjectClass.Company
            {
                Id = incrementId,
                Image = company.Image,
                Fax = company.Fax,
                Address = company.Address,
                Title = company.Title,
                Phone = company.Phone,
                Managers = company.Managers,
                Country = company.Country,
            };


            Companies.Add(addedCompany);
            return addedCompany;

        }
        #endregion

        #region Update By Id Method -- تابع بروزرسانی اطلاعات شرکت بر اساس ای دی جدول
        /// <summary>
        /// تابع بازگردانی اطلاعات شرکت بر اساس ای دی جدول
        /// </summary>
        /// <returns>Single User</returns>

        public Models.MyProjectClass.Company UpdateCompanyById(Models.MyProjectClass.Company company)
        {

            var findedCompany = Companies.FirstOrDefault(x => x.Id == company.Id);
            if (findedCompany != null)
            {



                findedCompany.Image = company.Image;
                findedCompany.Fax = company.Fax;
                findedCompany.Address = company.Address;
                findedCompany.Title = company.Title;
                findedCompany.Phone = company.Phone;
                findedCompany.Managers = company.Managers;
                findedCompany.Country = company.Country;

                //ذخیره تغییرات در دیتابیس
                //SaveChange();
                return findedCompany;
            }
            else
            {
                return findedCompany = null;
            }

        }
        #endregion

        #region Delete Company By Id -- تابع حذف اطلاعات کاربر 
        /// <summary>
        /// تابع حذف اطلاعات شرکت بر اساس ای دی جدول
        /// </summary>
        /// <returns>Single User</returns>

        public Models.MyProjectClass.Company DeleteById(int? id)
        {

            var findedCompany = Companies.FirstOrDefault(x => x.Id == id);
            var companyList = GetAllCompanies();
            if (findedCompany != null && companyList.Count > 0)
            {


                companyList.Remove(findedCompany);

                //ذخیره تغییرات در دیتابیس
                //SaveChange();
                return findedCompany;
            }
            else
            {
                return findedCompany = null;
            }

        }
        #endregion 
    }
}
